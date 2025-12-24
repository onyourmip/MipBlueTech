# MBT ID
# Sistem Informasi Absensi Karyawan – MBT Digital ID

## Deskripsi Sistem
MBT Digital ID adalah aplikasi **Sistem Informasi Sumber Daya Manusia (HRIS)** yang digunakan untuk mengelola absensi karyawan, jadwal kerja (shift), izin (time-off), lembur, serta data karyawan di perusahaan **MBT (Mip Blue Tech)**.

Sistem ini berbasis database dan terintegrasi dengan data karyawan, jadwal kerja, serta kebijakan perusahaan. Aplikasi memungkinkan karyawan melakukan **login**, **check-in / check-out**, **pengajuan izin**, **melihat jadwal kerja**, serta **mengelola profil pribadi** dengan kontrol akses yang aman sesuai peran pengguna.

---

## Fitur Sistem

### 1. Autentikasi User
- Login menggunakan username dan password
- Registrasi user berdasarkan data **NIK karyawan**
- Reset password menggunakan **OTP melalui email**
- Role user: **ADMIN** dan **USER**

### 2. Dashboard (User Home)
- Menampilkan informasi karyawan:
  - Nama
  - Jabatan
- Ringkasan absensi:
  - Present
  - Excused
  - Sick
  - Business Trip
- Akses ke seluruh menu utama aplikasi

### 3. Manajemen Shift (My Shift)
- Menampilkan jadwal kerja karyawan
- Data diambil dari tabel `employee_schedules`
- Mendukung sistem kerja berbasis shift

### 4. Absensi (Check-In / Check-Out)
- Menampilkan waktu real-time
- Check-in hanya dapat dilakukan jika:
  - Memiliki jadwal kerja
  - Tidak sedang cuti / izin
  - Bukan hari libur
- Check-out hanya dapat dilakukan setelah jam kerja berakhir
- Data absensi disimpan pada tabel `attendance`

### 5. Manajemen Time-Off (Izin)
- Menampilkan riwayat pengajuan izin
- Pengajuan izin baru dengan status default **Pending**
- Edit izin hanya diperbolehkan jika status masih **Pending**
- Data tersimpan pada tabel `leave_requests`

### 6. Profil Karyawan
- Menampilkan data pribadi karyawan
- Edit dan update data profil
- Perubahan langsung tersimpan ke tabel `employees`

### 7. ID Card Digital
- Menampilkan identitas karyawan:
  - Nama
  - Jabatan
  - Nomor ID
  - Tanggal bergabung
  - Nomor telepon
  - Foto karyawan
- Dilengkapi **QR Code** sebagai identitas digital

### 8. Logout
- Konfirmasi logout
- Mengakhiri sesi pengguna secara aman

---

## Database & Tabel

Sistem MBT Digital ID terdiri dari **13 tabel utama**, yaitu:

1. **departments** – Data departemen perusahaan  
2. **positions** – Data jabatan karyawan  
3. **employees** – Data master karyawan  
4. **users** – Data akun autentikasi user  
5. **work_schedules** – Master jadwal kerja (shift)  
6. **employee_schedules** – Relasi karyawan dengan jadwal kerja  
7. **attendance** – Data absensi harian  
8. **leave_requests** – Data pengajuan izin (time-off)  
9. **overtime_requests** – Data pengajuan lembur  
10. **holidays** – Data hari libur perusahaan  
11. **company_settings** – Pengaturan umum perusahaan  
12. **password_resets** – Token reset password (OTP)

---

## Relasi Antar Tabel
- `employees` berelasi dengan:
  - `departments`
  - `positions`
- `users` → `employees` (**One-to-One**)
- `employee_schedules`:
  - Many-to-One ke `employees`
  - Many-to-One ke `work_schedules`
- `attendance` → `employees`
- `leave_requests` → `employees`
- `overtime_requests` → `employees`
- `password_resets` → `users`

---

## ERD (Entity Relationship Diagram)
![ERD](./docs/erd.png)

> *ERD dapat dibuat secara digital atau digambar manual lalu difoto sesuai ketentuan.*

---

## Tech Stack

### Bahasa Pemrograman
- **C# (Windows Forms / WinForms)**  
  Digunakan untuk membangun antarmuka pengguna (UI) dan mengelola logika bisnis aplikasi.

### Database
- **MySQL**  
  Digunakan untuk menyimpan data karyawan, absensi, jadwal kerja, izin, dan autentikasi user.

### Database Connector
- **MySQL Connector for .NET**  
  Digunakan untuk menghubungkan aplikasi WinForms dengan database MySQL serta menjalankan query CRUD.

### Security Library
- **BCrypt.Net-Next**  
  Digunakan untuk:
  - Enkripsi password saat registrasi
  - Verifikasi password saat login
  - Menjaga keamanan data autentikasi

### QR Code Library
- **QrCoder**  
  Digunakan untuk pembuatan QR Code pada ID Card Digital karyawan.

### UI Framework
- **Guna.UI2.WinForms**  
  Digunakan untuk membuat tampilan aplikasi lebih modern, interaktif, dan meningkatkan user experience (UX).

---

## Author
Mifta Huljannah Harahap
**MBT Digital ID – Mip Blue Tech**  
Aplikasi HRIS Desktop berbasis WinForms dan MySQL
