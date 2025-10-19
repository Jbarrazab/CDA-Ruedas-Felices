using RuedasFelices.Interfaces;
using RuedasFelices.Models;

namespace RuedasFelices.Services;

public class EmailService
{
    private readonly IEmailService _emailSender;
    private readonly IEmailLogRepository _emailLogRepository;

    public EmailService(IEmailService emailSender, IEmailLogRepository emailLogRepository)
    {
        _emailSender = emailSender;
        _emailLogRepository = emailLogRepository;
    }

    // Send an email and store log result
    public void SendEmail(string to, string subject, string body, Guid? referenceId = null)
    {
        var sent = _emailSender.Send(to, subject, body);
        var log = new EmailLog(to, subject, body, sent ? SendStatus.Sent : SendStatus.NotSent, referenceId);
        _emailLogRepository.Add(log);

        Console.WriteLine(sent
            ? "Email sent successfully."
            : "Error: Email could not be sent.");
    }

    // Show all email logs
    public void ShowAllLogs()
    {
        var logs = _emailLogRepository.GetAll();
        if (logs.Count == 0)
        {
            Console.WriteLine("No email logs found.");
            return;
        }

        foreach (var log in logs)
        {
            log.ShowInformation();
        }
    }
}