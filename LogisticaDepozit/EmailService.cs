using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LogisticaDepozit
{
    public class EmailService
    {
        private string fromEmail;
        private string password;

        public EmailService()
        {
            fromEmail = Environment.GetEnvironmentVariable("EMAIL_ADDRESS");
            password = Environment.GetEnvironmentVariable("EMAIL_PASSWORD");
        }

        public bool SendVerificationCode(string toEmail, string verificationCode)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(fromEmail);
                mail.To.Add(toEmail);
                mail.Subject = "Cod de verificare";
                mail.Body = $"Codul tău de verificare este: {verificationCode}. Codul este valabil timp de 5 minute.";
                mail.IsBodyHtml = false;

                using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtpClient.Credentials = new NetworkCredential(fromEmail, password);
                    smtpClient.EnableSsl = true;
                    smtpClient.Send(mail);
                }

                Console.WriteLine("Email trimis cu succes!");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Eroare la trimiterea email-ului: {ex.Message}");
                return false;
            }
        }
    }
}
