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
            // Load SMTP data from environment
            var host = Environment.GetEnvironmentVariable("SMTP_HOST");
            var portStr = Environment.GetEnvironmentVariable("SMTP_PORT");
            var user = Environment.GetEnvironmentVariable("SMTP_USER");
            var pass = Environment.GetEnvironmentVariable("SMTP_PASS");

            // Validate
            if (string.IsNullOrWhiteSpace(host) ||
                string.IsNullOrWhiteSpace(user) ||
                string.IsNullOrWhiteSpace(pass))
            {
                Console.WriteLine(" Email configuration is missing in .env file. Email not sent.");
                return false;
            }

            int port = int.TryParse(portStr, out var p) ? p : 587;

            using var smtp = new SmtpClient(host, port)
            {
                Credentials = new NetworkCredential(user, pass),
                EnableSsl = true
            };

            using var message = new MailMessage
            {
                From = new MailAddress(user),
                Subject = subject,
                Body = body,
                IsBodyHtml = false
            };

            message.To.Add(to);
            smtp.Send(message);

            Console.WriteLine($" Email sent successfully to {to}");
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($" Error sending email: {ex.Message}");
            return false;
        }
    }
}
