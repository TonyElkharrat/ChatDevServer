using System;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;


namespace ChatDev.Services
{

    public class EmailSender
    {
        public static void SendWelcomeEmail(string recipientEmail, string recipientName)
        {
            // Set up your SMTP client
            using (var client = new SmtpClient())
            {
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("chatdevc@gmail.com", "macj ieof mpzh vmwh\r\n");
                using (var message = new MailMessage(
                    from: new MailAddress("chatdevc@gmail.com", "ChatDev"),
                    to: new MailAddress(recipientEmail, recipientName)
                    ))
                {

                    message.Subject = "Hello from code!";
                    message.Body = GetWelcomeEmailHtml(recipientName);

                    client.Send(message);
                }
            }
        }

        private static string GetWelcomeEmailHtml(string recipientName)
        {
            // Generate the HTML content for the welcome email
            string htmlBody = $@"
            <html>
                <head>
                    <title>Welcome to Our Website</title>
                </head>
                <body>
                    <h1>Dear {recipientName},</h1>
                    <p>Thank you for joining Chat Dev!</p>
                    <p>We are thrilled to have you as a member of our community.</p>
                    <p>Best regards,<br>Your Website Team</p>
                </body>
            </html>";

            return htmlBody;
        }
    }

}
