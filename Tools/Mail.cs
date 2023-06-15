using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public class Mail
    {
        public void SendMail()
        {
            string fromMail = "test@gmail.com";
            string fromPassword = "asdasdasd";

            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromMail);
            message.Subject = "Test Subject";
            message.To.Add(new MailAddress("test@gmail.com"));
            message.Body = "<html><body> Test Body </body></html>";
            message.IsBodyHtml = true;

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromMail, fromPassword),
                EnableSsl = true,
            };

            smtpClient.Send(message);
        }
    }

    public class MailItem
    {
        public string? Subject { get; set; }
        public string? Body { get; set; }
        public string? From { get; set; }
        public List<string>? To { get; set; }
        public List<string>? CC { get; set; }
        public List<string>? CCO { get; set; }
        public List<MailAttachment>? Attachments { get; set; }
        public bool Asincrono { get; set; } = true;
    }
    public class MailAttachment
    {
        public string? Name { get; set; }
        public string? CID { get; set; }
        public string? Base64Data { get; set; }
    }
}
