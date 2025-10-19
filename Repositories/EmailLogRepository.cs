using RuedasFelices.Data;
using RuedasFelices.Interfaces;
using RuedasFelices.Models;

namespace RuedasFelices.Repositories;

public class EmailLogRepository : IEmailLog
{
    private readonly List<EmailLog> _emailLogs = Database.EmailLogs;

    // Add a new email log entry
    public void Add(EmailLog emailLog)
    {
        _emailLogs.Add(emailLog);
    }

    // Get all email logs
    public List<EmailLog> GetAll()
    {
        return _emailLogs.ToList();
    }

    // Get email logs by reference (e.g., Appointment Id)
    public List<EmailLog> GetByReference(Guid referenceId)
    {
        return _emailLogs
            .Where(e => e.ReferenceId == referenceId)
            .ToList();
    }
}
