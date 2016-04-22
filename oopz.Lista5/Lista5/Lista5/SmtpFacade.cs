using System.IO;
using System.Net.Mail;

namespace Lista5
{
    public class SmtpFacade
    {
        public void Send(string @from, string to,
            string subject, string body,
            Stream attachment, string attachmentMimeType)
        {
            var mail = new MailMessage(@from, to);
            var client = new SmtpClient
            {
                Port = 25,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Host = "smtp.google.com"
            };
            mail.Subject = subject;
            mail.Body = body;
            mail.Attachments.Add(new Attachment(attachment, "attachment", attachmentMimeType));
            client.Send(mail);
        }
    }
}
