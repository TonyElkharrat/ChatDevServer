using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;


namespace ChatDev.Services
{
    public enum EmailType{
        Welcome,
        ForgotPassword
    }
    public class EmailSender
    {
        private readonly  IConfiguration _configuration;

        public  EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public  void SendEmail(string recipientEmail,EmailType emailType)
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
                    to: new MailAddress(recipientEmail)
                    ))
                {

                    message.Subject = "Hello from code!";
                    message.Body = _configuration.GetSection("EmailBody")[emailType.ToString()]; ;

                    client.Send(message);
                }
            }
        }
    }
}
