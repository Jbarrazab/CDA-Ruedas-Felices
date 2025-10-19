using System.Net;
using System.Net.Mail;
using RuedasFelices.Interfaces;

namespace RuedasFelices.Services;

public class EmailSender : IEmailService
{
    public bool Send(string to, string subject, string body)
    {
        try
        {
            // Read config from .env
            var host = Environment.GetEnvironmentVariable("SMTP_HOST");
            var port = int.Parse(Environment.GetEnvironmentVariable("SMTP_PORT") ?? "587");
            var user = Environment.GetEnvironmentVariable("SMTP_USER");
            var pass = Environment.GetEnvironmentVariable("SMTP_PASS");

            using var smtp = new SmtpClient(host, port)
            {
                Credentials = new NetworkCredential(user, pass),
                EnableSsl = true
            };

            using var message = new MailMessage(user, to, subject, body)
            {
                IsBodyHtml = false
            };

            smtp.Send(message);

            Console.WriteLine($"✅ Email sent successfully to {to}");
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Error sending email: {ex.Message}");
            return false;
        }
    }
}
