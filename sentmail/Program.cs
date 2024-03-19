using System;
using System.Net;
using System.Net.Mail;
namespace sentmail
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string fromMail = "alasnehith@gmail.com";
                string fromPassword = "pgarvaqkymyrcfbn"; // This is just an example password, replace it with your actual password.

                MailMessage message = new MailMessage();
                message.From = new MailAddress(fromMail);
                message.Subject = "mail with attachment";
                message.To.Add(new MailAddress("sweetysnehith143@gmail.com"));
                message.Body = "<html><body>hi  Test Body </body></html>";
                message.IsBodyHtml = true;
                // Adding an attachment
                string attachmentPath = @"C:\Users\USER\Pictures\as.png"; // Change this to the path of your actual file
                Attachment attachment = new Attachment(attachmentPath);
                message.Attachments.Add(attachment);

                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(fromMail, fromPassword),
                    EnableSsl = true,
                };

                smtpClient.Send(message);
                Console.WriteLine("Email sent successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
