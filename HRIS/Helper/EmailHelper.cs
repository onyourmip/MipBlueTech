using System.Net;
using System.Net.Mail;

namespace HRIS.Helper
{
    internal class EmailHelper
    {
        public static void SendEmail(string to, string subject, string bodyHtml)
        {
            var smtp = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(
                    "miftahnexuscorp@gmail.com",
                    "bjmcthyzpauazobg"
                ),
                EnableSsl = true
            };

            var mail = new MailMessage
            {
                From = new MailAddress(
                    "miftahnexuscorp@gmail.com",
                    "MBT DIGITAL ID"
                ),
                Subject = subject,
                Body = bodyHtml,
                IsBodyHtml = true
            };

            mail.To.Add(to);
            smtp.Send(mail);
        }
    }
}
