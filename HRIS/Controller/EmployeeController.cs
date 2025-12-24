using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using MySqlConnector;
using HRIS.Model;
using HRIS.Helper;

namespace HRIS.Controller
{
    public class EmployeeController : Database
    {
        private readonly Database db = new Database();

        // =====================================================
        // ===================== AUTH ==========================
        // =====================================================

        // LOGIN
        // ==============================
        // LOGIN USER
        // ==============================
        public UserSession Login(string username, string password)
        {
            // Membuka koneksi ke database menggunakan helper GetConnection()
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open(); // Membuka koneksi database

                // Query SQL untuk mengambil data user beserta data relasi employee, posisi, dan departemen
                string sql = @"
            SELECT 
                u.user_id,
                u.role,
                u.password_hash,
                e.employee_id,
                e.full_name,
                p.position_name,
                d.department_name
            FROM users u
            JOIN employees e ON u.employee_id = e.employee_id
            JOIN positions p ON e.position_id = p.position_id
            JOIN departments d ON e.department_id = d.department_id
            WHERE u.username = @u
              AND u.is_active = 1
              AND e.is_active = 1
            LIMIT 1";

                // Menyiapkan command SQL
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                // Parameter username (mencegah SQL Injection)
                cmd.Parameters.AddWithValue("@u", username);

                // Eksekusi query dan baca hasilnya
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    // Jika data tidak ditemukan, login gagal
                    if (!rd.Read()) return null;

                    // Verifikasi password input dengan hash BCrypt di database
                    if (!BCrypt.Net.BCrypt.Verify(password, rd.GetString("password_hash")))
                        return null;

                    // Jika valid, kembalikan session user
                    return new UserSession
                    {
                        UserId = rd.GetInt32("user_id"),
                        EmployeeId = rd.GetInt64("employee_id"),
                        FullName = rd.GetString("full_name"),
                        Position = rd.GetString("position_name"),
                        Department = rd.GetString("department_name"),
                        Role = rd.GetString("role")
                    };
                }
            }
        }


        // ==============================
        // REGISTER USER
        // ==============================
        public void Register(string nik, string email, string passwordPlain)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open(); // Membuka koneksi database

                // Query untuk mencari data employee berdasarkan NIK
                string employeeSql = @"
            SELECT employee_id, full_name
            FROM employees
            WHERE nik = @nik AND is_active = 1
            LIMIT 1";

                long employeeId;
                string fullName;

                // Eksekusi query employee
                using (MySqlCommand cmd = new MySqlCommand(employeeSql, conn))
                {
                    cmd.Parameters.AddWithValue("@nik", nik);

                    using (MySqlDataReader rd = cmd.ExecuteReader())
                    {
                        // Jika NIK tidak ditemukan, proses dihentikan
                        if (!rd.Read())
                            throw new Exception("NIK tidak terdaftar");

                        // Ambil data employee
                        employeeId = rd.GetInt64("employee_id");
                        fullName = rd.GetString("full_name");
                    }
                }

                // Generate username otomatis
                string username = GenerateUsername(fullName, employeeId);

                // Hash password menggunakan BCrypt
                string passwordHash = BCrypt.Net.BCrypt.HashPassword(passwordPlain);

                // Query insert user baru
                string insertSql = @"
            INSERT INTO users
            (employee_id, username, email, password_hash, role, is_active)
            VALUES
            (@eid, @u, @e, @p, 'USER', 1)";

                // Eksekusi insert user
                using (MySqlCommand cmd = new MySqlCommand(insertSql, conn))
                {
                    cmd.Parameters.AddWithValue("@eid", employeeId);
                    cmd.Parameters.AddWithValue("@u", username);
                    cmd.Parameters.AddWithValue("@e", email);
                    cmd.Parameters.AddWithValue("@p", passwordHash);
                    cmd.ExecuteNonQuery();
                }

                // Kirim email notifikasi pendaftaran akun
                EmailHelper.SendEmail(
                        email,
                        "Your Account Registration – Mip Blue Tech",
                        $@"
            <html>
            <body style='font-family:Segoe UI, Arial, sans-serif; font-size:14px; color:#333;'>
                <p>Dear <b>{fullName}</b>,</p>

                <p>
                    Thank you for registering with <b>Mip Blue Tech</b>.
                </p>

                <p>
                    We are pleased to inform you that your account has been successfully created.
                    Below are your account details:
                </p>

                <p>
                    <b>Username:</b> {username}
                </p>

                <p>
                    For security reasons, please keep your login credentials confidential.
                    If you did not register for this account, please contact our support team immediately.
                </p>

                <p>
                    You may now log in using the username above and the password you created during registration.
                </p>

                <br />

                <p>
                    Kind regards,<br />
                    <b>Mip Blue Tech</b><br />
                </p>
            </body>
            </html>"
                    );
            }
        }


        // ==============================
        // GENERATE USERNAME
        // ==============================
        private string GenerateUsername(string fullName, long employeeId)
        {
            // Ambil nama depan dari full name
            string firstName = fullName.Split(' ')[0].ToLower();

            // Ambil 4 digit terakhir dari employee_id
            string last4 = employeeId.ToString().Substring(employeeId.ToString().Length - 4);

            // Gabungkan menjadi username
            return firstName + last4;
        }


        // ==============================
        // REQUEST RESET PASSWORD
        // ==============================
        public void RequestPasswordReset(string email)
        {
            using (var conn = GetConnection())
            {
                conn.Open(); // Buka koneksi database

                int userId;

                // 1. Validasi apakah email terdaftar
                using (var cmdUser = new MySqlCommand(
                    "SELECT user_id FROM users WHERE email=@e AND is_active=1 LIMIT 1",
                    conn))
                {
                    cmdUser.Parameters.AddWithValue("@e", email);

                    var result = cmdUser.ExecuteScalar();
                    if (result == null)
                        throw new Exception("Email tidak terdaftar");

                    userId = Convert.ToInt32(result);
                }

                // 2. Hapus token lama (1 user hanya boleh 1 token aktif)
                using (var cmdDelete = new MySqlCommand(
                    "DELETE FROM password_resets WHERE user_id=@id",
                    conn))
                {
                    cmdDelete.Parameters.AddWithValue("@id", userId);
                    cmdDelete.ExecuteNonQuery();
                }

                // 3. Generate OTP 6 digit
                Random rnd = new Random();
                string token = rnd.Next(100000, 999999).ToString();

                // 4. Simpan token ke database dengan masa berlaku 10 menit
                using (var cmdInsert = new MySqlCommand(
                    @"INSERT INTO password_resets (user_id, token, expired_at)
              VALUES (@id, @t, DATE_ADD(NOW(), INTERVAL 10 MINUTE))",
                    conn))
                {
                    cmdInsert.Parameters.AddWithValue("@id", userId);
                    cmdInsert.Parameters.AddWithValue("@t", token);
                    cmdInsert.ExecuteNonQuery();
                }

                // 5. Template email reset password
                string emailBody = $@"
            <!DOCTYPE html>
            <html>
            <body style='font-family:Segoe UI, Arial, sans-serif; font-size:14px; background-color:#f5f6f8; padding:20px;'>
                ...
                {token}
                ...
            </body>
            </html>";

                // 6. Kirim email OTP
                EmailHelper.SendEmail(
                    email,
                    "Password Reset Verification Code",
                    emailBody
                );
            }
        }


        // ==============================
        // RESET PASSWORD
        // ==============================
        public void ResetPassword(int userId, string newPassword)
        {
            using (var conn = GetConnection())
            {
                conn.Open(); // Buka koneksi database

                // Hash password baru
                string hash = BCrypt.Net.BCrypt.HashPassword(newPassword);

                // Update password user
                new MySqlCommand(
                    "UPDATE users SET password_hash=@p WHERE user_id=@id", conn)
                {
                    Parameters =
            {
                new MySqlParameter("@p", hash),
                new MySqlParameter("@id", userId)
            }
                }.ExecuteNonQuery();

                // Hapus token reset setelah password berhasil diubah
                new MySqlCommand(
                    "DELETE FROM password_resets WHERE user_id=@id", conn)
                {
                    Parameters = { new MySqlParameter("@id", userId) }
                }.ExecuteNonQuery();
            }
        }


        // ==============================
        // VERIFIKASI TOKEN RESET
        // ==============================
        public int VerifyResetToken(string token)
        {
            using (var conn = GetConnection())
            {
                conn.Open(); // Buka koneksi database

                // Cek token dan masa berlakunya
                var cmd = new MySqlCommand(
                    @"SELECT user_id FROM password_resets
              WHERE token=@t AND expired_at > NOW()
              LIMIT 1", conn);

                cmd.Parameters.AddWithValue("@t", token);

                var result = cmd.ExecuteScalar();
                if (result == null)
                    throw new Exception("Token tidak valid atau sudah expired");

                // Kembalikan user_id jika token valid
                return Convert.ToInt32(result);
            }
        }

        // =====================================================
        // ================= EMPLOYEE ==========================
        // =====================================================
        // ==============================
        // AMBIL DATA KARYAWAN BERDASARKAN ID
        // ==============================
        public DataRow GetEmployeeById(long employeeId)
        {
            // DataTable untuk menampung hasil query
            DataTable dt = new DataTable();

            // Membuka koneksi database
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open(); // Buka koneksi

                // Query untuk mengambil data karyawan beserta department dan position
                string sql = @"
        SELECT 
            e.employee_id,
            e.employee_number,
            e.full_name,
            e.birth_place,
            e.birth_date,
            e.gender,
            e.nationality,
            e.address,
            e.phone,
            e.education,
            e.photo,
            d.department_name,
            p.position_name,
            e.join_date,
            e.employment_status
        FROM employees e
        LEFT JOIN departments d ON e.department_id = d.department_id
        LEFT JOIN positions p ON e.position_id = p.position_id
        WHERE e.employee_id = @id";

                // Menyiapkan perintah SQL
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                // Parameter employee_id (aman dari SQL Injection)
                cmd.Parameters.AddWithValue("@id", employeeId);

                // DataAdapter untuk mengisi DataTable
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt); // Eksekusi query dan isi DataTable
            }

            // Jika data ada, kembalikan baris pertama, jika tidak return null
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }


        // ==============================
        // UPDATE DATA PRIBADI KARYAWAN
        // ==============================
        public bool UpdatePersonalData(
            long employeeId,
            string birthPlace,
            DateTime birthDate,
            string gender,
            string nationality,
            string address,
            string phone,
            string education)
        {
            // Membuka koneksi database
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open(); // Buka koneksi

                // Query update data personal karyawan
                string sql = @"
        UPDATE employees SET
            birth_place = @place,
            birth_date = @date,
            gender = @gender,
            nationality = @nation,
            address = @address,
            phone = @phone,
            education = @edu
        WHERE employee_id = @id";

                // Menyiapkan command SQL
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                // Mengisi parameter query
                cmd.Parameters.AddWithValue("@place", birthPlace);
                cmd.Parameters.AddWithValue("@date", birthDate);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@nation", nationality);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@edu", education);
                cmd.Parameters.AddWithValue("@id", employeeId);

                // ExecuteNonQuery mengembalikan jumlah row yang terpengaruh
                // Jika > 0 berarti update berhasil
                return cmd.ExecuteNonQuery() > 0;
            }
        }


        // ==============================
        // UPDATE FOTO PROFIL KARYAWAN
        // ==============================
        public bool UpdateProfilePhoto(long employeeId, string photoFileName)
        {
            // Membuka koneksi database
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open(); // Buka koneksi

                // Query update kolom photo
                                    string sql = @"
                        UPDATE employees
                        SET photo = @photo
                        WHERE employee_id = @id
                    ";

                // Menyiapkan command SQL
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    // Parameter nama file foto
                    cmd.Parameters.AddWithValue("@photo", photoFileName);

                    // Parameter employee_id
                    cmd.Parameters.AddWithValue("@id", employeeId);

                    // Eksekusi update dan kembalikan status berhasil atau tidak
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }


        // =====================================================
        // ================= ABSENSI ===========================
        // =====================================================
        // ===============================
        // CEK HARI LIBUR
        // Mengecek apakah hari ini termasuk hari libur
        // ===============================
        public bool IsHariLibur()
        {
            // Ambil koneksi database
            MySqlConnection conn = db.GetConnection();
            conn.Open();

            // Query untuk menghitung jumlah data libur
            // Jika CURDATE() berada di antara start_date dan end_date
            string sql = @"
        SELECT COUNT(*) 
        FROM holidays
        WHERE CURDATE() BETWEEN start_date AND end_date";

            // Eksekusi query
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            int total = Convert.ToInt32(cmd.ExecuteScalar());

            conn.Close();

            // Jika ada data libur (>0), berarti hari ini libur
            return total > 0;
        }


        // ===============================
        // ABSENSI HARI INI
        // Mengambil jam check-in dan check-out hari ini
        // ===============================
        public (string masuk, string pulang) GetAbsensiHariIni(long employeeId)
        {
            MySqlConnection conn = db.GetConnection();
            conn.Open();

            // Query absensi hari ini
            string sql = @"
        SELECT check_in, check_out
        FROM attendance
        WHERE employee_id = @id
          AND attendance_date = CURDATE()
        LIMIT 1";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", employeeId);

            MySqlDataReader rd = cmd.ExecuteReader();

            // Jika belum ada data absensi hari ini
            if (!rd.Read())
            {
                rd.Close();
                conn.Close();
                return ("Not Checked In", "Not Checked Out");
            }

            // Ambil jam check-in
            string masuk;
            if (rd["check_in"] == DBNull.Value)
                masuk = "Not Checked In";
            else
                masuk = Convert.ToDateTime(rd["check_in"]).ToString("HH:mm");

            // Ambil jam check-out
            string pulang;
            if (rd["check_out"] == DBNull.Value)
                pulang = "Not Checked Out";
            else
                pulang = Convert.ToDateTime(rd["check_out"]).ToString("HH:mm");

            rd.Close();
            conn.Close();

            // Kembalikan jam masuk dan pulang
            return (masuk, pulang);
        }


        // ===============================
        // CEK SUDAH CHECK-IN ATAU BELUM
        // ===============================
        public bool IsAlreadyCheckedIn(long employeeId)
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();

                // Cek apakah sudah check-in hari ini
                string sql = @"
    SELECT 1
    FROM attendance
    WHERE employee_id = @id
      AND attendance_date = CURDATE()
      AND check_in IS NOT NULL
    LIMIT 1";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", employeeId);
                    return cmd.ExecuteScalar() != null;
                }
            }
        }


        // ===============================
        // CEK BOLEH CHECK-OUT ATAU TIDAK
        // ===============================
        public bool CanCheckOut(long employeeId)
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();

                // Hanya boleh check-out jika:
                // - Sudah check-in
                // - Belum check-out
                string sql = @"
    SELECT 1
    FROM attendance
    WHERE employee_id = @id
      AND attendance_date = CURDATE()
      AND check_in IS NOT NULL
      AND check_out IS NULL
    LIMIT 1";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", employeeId);
                    return cmd.ExecuteScalar() != null;
                }
            }
        }


        // ===============================
        // CEK APAKAH DALAM JAM SHIFT
        // ===============================
        public bool IsWithinShift(long employeeId)
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();

                // Ambil jam mulai dan selesai shift hari ini
                string sql = @"
    SELECT ws.start_time, ws.end_time
    FROM employee_schedules es
    JOIN work_schedules ws ON es.schedule_id = ws.schedule_id
    WHERE es.employee_id = @id
      AND es.day_of_week = DAYNAME(CURDATE())
    LIMIT 1";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", employeeId);

                    using (MySqlDataReader rd = cmd.ExecuteReader())
                    {
                        // Jika tidak ada jadwal hari ini
                        if (!rd.Read())
                            return false;

                        TimeSpan start = rd.GetTimeSpan("start_time");
                        TimeSpan end = rd.GetTimeSpan("end_time");
                        TimeSpan now = DateTime.Now.TimeOfDay;

                        // Cek apakah waktu sekarang berada di dalam jam shift
                        return now >= start && now <= end;
                    }
                }
            }
        }


        // ===============================
        // CEK APAKAH ADA SHIFT HARI INI
        // ===============================
        public bool HasShiftToday(long employeeId, out TimeSpan endShift)
        {
            endShift = TimeSpan.Zero;

            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();

                // Ambil jam akhir shift hari ini
                string sql = @"
SELECT ws.start_time, ws.end_time
FROM employee_schedules es
JOIN work_schedules ws ON es.schedule_id = ws.schedule_id
WHERE es.employee_id = @id
  AND es.day_of_week = DAYNAME(CURDATE())
LIMIT 1";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", employeeId);

                    using (MySqlDataReader rd = cmd.ExecuteReader())
                    {
                        // Tidak ada shift hari ini
                        if (!rd.Read())
                            return false;

                        endShift = rd.GetTimeSpan("end_time");
                        return true;
                    }
                }
            }
        }


        // ===============================
        // CEK CUTI / IZIN HARI INI
        // ===============================
        public string GetLeaveToday(long employeeId)
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();

                // Cek apakah ada cuti yang disetujui hari ini
                string sql = @"
    SELECT leave_type 
    FROM leave_requests
    WHERE employee_id = @id
      AND STATUS = 'Approved'
      AND CURDATE() BETWEEN start_date AND end_date
    LIMIT 1";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", employeeId);
                    var result = cmd.ExecuteScalar();
                    return result != null ? result.ToString() : null;
                }
            }
        }


        // ===============================
        // CHECK-IN
        // ===============================
        public void CheckIn(long employeeId)
        {
            // 0️⃣ Cek apakah ada cuti hari ini
            string leaveType = GetLeaveToday(employeeId);
            if (leaveType != null)
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    // Simpan status cuti ke tabel attendance
                    string sql = @"
        INSERT INTO attendance
        (employee_id, attendance_date, attendance_status)
        VALUES (@id, CURDATE(), @status)";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", employeeId);
                        cmd.Parameters.AddWithValue("@status", leaveType);
                        cmd.ExecuteNonQuery();
                    }
                }

                throw new Exception($"You have a leave today ({leaveType}). Check-in is not allowed.");
            }

            // 1️⃣ Hari libur
            if (IsHariLibur())
                throw new Exception("Today is a holiday");

            // 2️⃣ Tidak ada shift
            if (!HasShiftToday(employeeId, out _))
                throw new Exception("You have no shift today");

            // 3️⃣ Di luar jam shift
            if (!IsWithinShift(employeeId))
                throw new Exception("You are outside your shift time");

            // 4️⃣ Sudah check-in
            if (IsAlreadyCheckedIn(employeeId))
                throw new Exception("You have already checked in today");

            // Simpan data check-in
            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();

                string sql = @"
    INSERT INTO attendance
    (employee_id, attendance_date, check_in, attendance_status)
    VALUES
    (@id, CURDATE(), NOW(), 'Present')";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", employeeId);
                    cmd.ExecuteNonQuery();
                }
            }
        }


        // ===============================
        // CHECK-OUT
        // ===============================
        public void CheckOut(long employeeId)
        {
            // 1️⃣ Tidak boleh check-out jika sedang cuti
            string leaveType = GetLeaveToday(employeeId);
            if (leaveType != null)
                throw new Exception($"You are on leave today ({leaveType}). Check-out is not allowed.");

            // 2️⃣ Pastikan sudah check-in dan belum check-out
            if (!CanCheckOut(employeeId))
                throw new Exception("You cannot check out at this time");

            // 3️⃣ Ambil jam akhir shift
            if (!HasShiftToday(employeeId, out TimeSpan endShift))
                throw new Exception("You have no shift today");

            TimeSpan now = DateTime.Now.TimeOfDay;

            // ❌ Belum waktunya pulang
            if (now < endShift)
            {
                throw new Exception(
                    $"You cannot check out before shift ends at {endShift:hh\\:mm}"
                );
            }

            // 4️⃣ Update jam check-out
            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();

                string sql = @"
UPDATE attendance
SET check_out = NOW()
WHERE employee_id = @id
  AND attendance_date = CURDATE()
  AND check_out IS NULL";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", employeeId);
                    cmd.ExecuteNonQuery();
                }
            }
        }


        // ===============================
        // REKAP ABSENSI BULANAN
        // ===============================
        public Dictionary<string, int> GetRekapBulanan(long employeeId)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();

            MySqlConnection conn = db.GetConnection();
            conn.Open();

            // Hitung total absensi per status bulan ini
            string sql = @"
        SELECT attendance_status, COUNT(*) total
        FROM attendance
        WHERE employee_id = @id
          AND MONTH(attendance_date) = MONTH(CURDATE())
          AND YEAR(attendance_date) = YEAR(CURDATE())
        GROUP BY attendance_status";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", employeeId);

            MySqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                string status = rd.GetString("attendance_status");
                int total = rd.GetInt32("total");
                result[status] = total;
            }

            rd.Close();
            conn.Close();

            return result;
        }


        // ===============================
        // RIWAYAT ABSENSI TERAKHIR
        // ===============================
        public DataTable GetRiwayatTerbaru(long employeeId)
        {
            DataTable dt = new DataTable();

            MySqlConnection conn = db.GetConnection();
            conn.Open();

            // Ambil 10 data absensi terakhir
            string sql = @"
        SELECT attendance_date Date,
               check_in CheckIn,
               check_out CheckOut,
               attendance_status Status
        FROM attendance
        WHERE employee_id = @id
        ORDER BY attendance_date DESC
        LIMIT 10";

            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            da.SelectCommand.Parameters.AddWithValue("@id", employeeId);
            da.Fill(dt);

            conn.Close();
            return dt;
        }


        // =====================================================
        // ================= CUTI ==============================
        // =====================================================
        // ================= GET BY EMPLOYEE =================
        // Mengambil seluruh data pengajuan cuti berdasarkan employee_id
        public DataTable GetByEmployee(long employeeId)
        {
            // DataTable untuk menampung hasil query
            DataTable table = new DataTable();

            // Membuka koneksi database
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();

                // Query mengambil data cuti milik karyawan tertentu
                // Diurutkan dari yang terbaru
                string sql =
                    "SELECT leave_id, leave_type, start_date, end_date, total_days, remarks, status " +
                    "FROM leave_requests " +
                    "WHERE employee_id = @emp " +
                    "ORDER BY created_at DESC";

                // Menyiapkan command SQL
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                // Parameter employee_id (aman dari SQL Injection)
                cmd.Parameters.AddWithValue("@emp", employeeId);

                // DataAdapter untuk mengisi DataTable
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(table);
            }

            // Mengembalikan daftar cuti
            return table;
        }


        // ================= GET BY ID =================
        // Mengambil detail satu pengajuan cuti berdasarkan leave_id
        public DataRow GetById(long leaveId)
        {
            DataTable dt = new DataTable();

            // Membuka koneksi database
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();

                // Query mengambil satu data cuti
                string sql =
                    "SELECT leave_id, leave_type, start_date, end_date, total_days, remarks, status " +
                    "FROM leave_requests WHERE leave_id = @id";

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                // Parameter leave_id
                cmd.Parameters.AddWithValue("@id", leaveId);

                // Eksekusi query
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }

            // Jika data ada, kembalikan baris pertama, jika tidak null
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }


        // ================= INSERT =================
        // Menambahkan pengajuan cuti baru
        public bool Insert(
          long employeeId,
          string leaveType,
          DateTime start,
          DateTime end,
          int total,
          string remarks,
          out string error)
        {
            // Pesan error default
            error = "";

            // ❌ Masih ada pengajuan cuti berstatus Pending
            if (HasPendingLeave(employeeId))
            {
                error = "You still have a pending leave request. Please wait for approval.";
                return false;
            }

            // ❌ Validasi tanggal (tanggal akhir tidak boleh lebih kecil)
            if (end.Date < start.Date)
            {
                error = "Tanggal To tidak boleh lebih kecil dari From";
                return false;
            }

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();

                // Query insert data cuti baru dengan status default Pending
                string sql = @"
    INSERT INTO leave_requests
    (employee_id, leave_type, start_date, end_date, total_days, remarks, status)
    VALUES
    (@emp, @type, @start, @end, @total, @remarks, 'Pending')";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    // Parameter input cuti
                    cmd.Parameters.AddWithValue("@emp", employeeId);
                    cmd.Parameters.AddWithValue("@type", leaveType);
                    cmd.Parameters.AddWithValue("@start", start.Date);
                    cmd.Parameters.AddWithValue("@end", end.Date);
                    cmd.Parameters.AddWithValue("@total", total);
                    cmd.Parameters.AddWithValue("@remarks", remarks);

                    try
                    {
                        // Eksekusi insert
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (MySqlException ex) when (ex.Number == 1062)
                    {
                        // ❌ Error duplicate (unique index: 1 request per day)
                        error = "You can only submit one leave request per day";
                        return false;
                    }
                }
            }
        }


        // ================= UPDATE (ONLY PENDING) =================
        // Mengupdate data cuti, hanya jika status masih Pending
        public bool Update(
            long leaveId,
            string leaveType,
            DateTime start,
            DateTime end,
            int total,
            string remarks)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();

                // Query update hanya untuk data Pending
                string sql =
                    "UPDATE leave_requests SET " +
                    "leave_type=@type, start_date=@start, end_date=@end, " +
                    "total_days=@total, remarks=@remarks " +
                    "WHERE leave_id=@id AND status='Pending'";

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                // Parameter update
                cmd.Parameters.AddWithValue("@type", leaveType);
                cmd.Parameters.AddWithValue("@start", start);
                cmd.Parameters.AddWithValue("@end", end);
                cmd.Parameters.AddWithValue("@total", total);
                cmd.Parameters.AddWithValue("@remarks", remarks);
                cmd.Parameters.AddWithValue("@id", leaveId);

                // Jika ada baris terpengaruh, berarti update berhasil
                return cmd.ExecuteNonQuery() > 0;
            }
        }


        // ================= DELETE (ONLY PENDING) =================
        // Menghapus pengajuan cuti jika masih Pending
        public bool Delete(long leaveId)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();

                // Query delete hanya untuk status Pending
                string sql =
                    "DELETE FROM leave_requests " +
                    "WHERE leave_id=@id AND status='Pending'";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", leaveId);

                // Return true jika data berhasil dihapus
                return cmd.ExecuteNonQuery() > 0;
            }
        }


        // ================= DUPLICATE DATE =================
        // Mengecek apakah sudah ada pengajuan cuti pada tanggal yang sama
        private bool HasSameDate(long empId, DateTime date)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();

                string sql =
                    "SELECT 1 FROM leave_requests " +
                    "WHERE employee_id=@emp AND start_date=@date";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@emp", empId);
                cmd.Parameters.AddWithValue("@date", date.Date);

                // Jika ada data, berarti tanggal sudah digunakan
                return cmd.ExecuteScalar() != null;
            }
        }


        // ================= CEK CUTI PENDING =================
        // Mengecek apakah karyawan masih memiliki cuti Pending
        public bool HasPendingLeave(long employeeId)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();

                string sql = @"
                            SELECT 1
                            FROM leave_requests
                            WHERE employee_id = @emp
                              AND status = 'Pending'
                            LIMIT 1";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@emp", employeeId);
                    return cmd.ExecuteScalar() != null;
                }
            }
        }



        // =====================================================
        // ================= VALIDATION ========================
        // =====================================================


        public bool IsNikTerdaftar(string nik, out long employeeId, out string fullName)
        {
            employeeId = 0;
            fullName = "";

            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();

                string sql = @"SELECT employee_id, full_name
                               FROM employees
                               WHERE nik = @nik
                               AND is_active = 1
                               LIMIT 1";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@nik", nik);

                    using (MySqlDataReader rd = cmd.ExecuteReader())
                    {
                        if (!rd.Read()) return false;

                        employeeId = rd.GetInt64("employee_id");
                        fullName = rd.GetString("full_name");
                        return true;
                    }
                }
            }
        }

        public bool IsEmployeeSudahPunyaAkun(long employeeId)
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string sql = "SELECT 1 FROM users WHERE employee_id = @id LIMIT 1";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", employeeId);
                    return cmd.ExecuteScalar() != null;
                }
            }
        }

        public bool IsEmailFormatValid(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        public bool IsEmailSudahDipakai(string email)
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string sql = "SELECT 1 FROM users WHERE email = @email LIMIT 1";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    return cmd.ExecuteScalar() != null;
                }
            }
        }

        public bool IsPasswordValid(string password)
        {
            return password.Length >= 8;
        }

        // =====================================================
        // EDIT PROFILE VALIDATION (FIXED)
        // =====================================================

        // 1️⃣ Birth Place
        public bool ValidateBirthPlace(string birthPlace, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(birthPlace))
            {
                error = "Birth place is required";
                return false;
            }

            string value = birthPlace.Trim();

            if (value.Length < 3 || value.Length > 50)
            {
                error = "Birth place must be between 3 and 50 characters";
                return false;
            }

            if (!Regex.IsMatch(value, @"[a-zA-Z]"))
            {
                error = "Birth place must contain at least one letter";
                return false;
            }

            if (!Regex.IsMatch(value, @"^[a-zA-Z\s\.]+$"))
            {
                error = "Birth place may only contain letters, spaces, and dots";
                return false;
            }

            return true;
        }

        // 2️⃣ Nationality
        public bool ValidateNationality(string nationality, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(nationality))
            {
                error = "Nationality is required";
                return false;
            }

            string value = nationality.Trim().ToLower();
            if (value != "indonesia" && value != "wni")
            {
                error = "Nationality must be Indonesia or WNI";
                return false;
            }

            return true;
        }

        // 3️⃣ Address
        public bool ValidateAddress(string address, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(address))
            {
                error = "Address is required";
                return false;
            }

            string value = address.Trim();

            if (value.Length < 10)
            {
                error = "Address must be at least 10 characters long";
                return false;
            }

            if (!Regex.IsMatch(value, @"[a-zA-Z]"))
            {
                error = "Address must contain at least one letter";
                return false;
            }

            return true;
        }

        // 4️⃣ Phone Number (Indonesia)
        public bool ValidatePhoneIndonesia(string phone, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(phone))
            {
                error = "Phone number is required";
                return false;
            }

            if (!Regex.IsMatch(phone.Trim(), @"^(\+628|08)[0-9]{8,11}$"))
            {
                error = "Phone number must start with 08 or +628 and contain 10–13 digits";
                return false;
            }

            return true;
        }

        // 5️⃣ Education
        public bool ValidateEducation(string education, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(education))
            {
                error = "Education must be selected";
                return false;
            }

            return true;
        }

        // 6️⃣ Gender
        public bool ValidateGender(bool isMaleChecked, bool isFemaleChecked, out string error)
        {
            error = string.Empty;

            if (!isMaleChecked && !isFemaleChecked)
            {
                error = "Gender must be selected";
                return false;
            }

            return true;
        }

        // 7️⃣ FINAL VALIDATION
        public bool ValidateEditProfile(
            string birthPlace,
            string nationality,
            string address,
            string phone,
            string education,
            bool isMaleChecked,
            bool isFemaleChecked,
            out string error)
        {
            if (!ValidateBirthPlace(birthPlace, out error)) return false;
            if (!ValidateNationality(nationality, out error)) return false;
            if (!ValidateAddress(address, out error)) return false;
            if (!ValidatePhoneIndonesia(phone, out error)) return false;
            if (!ValidateEducation(education, out error)) return false;
            if (!ValidateGender(isMaleChecked, isFemaleChecked, out error)) return false;

            error = string.Empty;
            return true;
        }

        // 8️⃣ Helper
        public string GetGenderValue(bool isMaleChecked, bool isFemaleChecked)
        {
            if (isMaleChecked) return "Male";
            if (isFemaleChecked) return "Female";
            return string.Empty;
        }

        // PROFILE PHOTO VALIDATION
        public bool ValidateProfilePhoto(string filePath, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(filePath))
            {
                error = "Please select a photo";
                return false;
            }

            string extension = Path.GetExtension(filePath).ToLower();

            if (extension != ".jpg" && extension != ".jpeg" && extension != ".png")
            {
                error = "Only JPG, JPEG, or PNG images are allowed";
                return false;
            }

            FileInfo fileInfo = new FileInfo(filePath);

            // Max 2MB
            if (fileInfo.Length > 2 * 1024 * 1024)
            {
                error = "Image size must not exceed 2MB";
                return false;
            }

            return true;
        }

        public DataTable GetMyWorkSchedule(long employeeId)
        {
            DataTable dt = new DataTable();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();

                string sql = @"
                    SELECT
                        es.day_of_week        AS Day,
                        ws.schedule_code      AS Code,
                        ws.schedule_name      AS Schedule,
                        ws.start_time         AS StartTime,
                        ws.end_time           AS EndTime,
                        ws.break_time         AS BreakTime,
                        ws.total_hours        AS TotalHours
                    FROM employee_schedules es
                    INNER JOIN work_schedules ws
                        ON es.schedule_id = ws.schedule_id
                    WHERE es.employee_id = @employeeId
                    ORDER BY
                        FIELD(es.day_of_week,
                            'Monday','Tuesday','Wednesday',
                            'Thursday','Friday','Saturday','Sunday'
                        )
                ";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@employeeId", employeeId);

                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }

            return dt;
        }


    }
}