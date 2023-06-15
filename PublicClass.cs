using System.Web;
using System.IO;
using System.Drawing;
using SurucuKursu.Models;
using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace SurucuKursu
{
    public class PublicClass
    {
        public string ImgToBase64(IFormFile img)
        {
            using (var ms = new MemoryStream())
            {
                img.CopyTo(ms);

                var imageBytes = ms.ToArray();

                // Base64'e dönüştürün
                var base64String = Convert.ToBase64String(imageBytes);

                // Veritabanına kaydedin veya başka bir işlem yapın
                return base64String;
            }
        }


        public string SendEmail(string adres, string konu, string mesaj)
        {
            string gmailUsername = "ozguris050@gmail.com";
            string gmailPassword = "ozguris_is";

            // MailMessage nesnesi oluştur
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(gmailUsername);
            mail.To.Add(adres);
            mail.Subject = konu;
            mail.Body = mesaj;

            // SMTP istemci nesnesi oluştur
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(gmailUsername, gmailPassword);

            try
            {
                // E-postayı gönder
                smtpClient.Send(mail);
                return "E posta gönderildi";
            }
            catch (Exception ex)
            {
                return "E-posta gönderme hatası: " + ex.Message;
            }
            finally
            {
                // Nesneleri temizle
                mail.Dispose();
                smtpClient.Dispose();
            }
        }


    }
}
