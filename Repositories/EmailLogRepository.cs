using RuedasFelices.Data;
using RuedasFelices.Interfaces;
using RuedasFelices.Models;

namespace RuedasFelices.Repositories;

public class EmailLogRepository : IEmailLogRepository
{
    // Reference to the in-memory EmailLogs list in Database
    private readonly List<EmailLog> _emailLogs = Database.EmailLogs;

    // Add a new email log entry
    public void Add(EmailLog emailLog)
    {
        _emailLogs.Add(emailLog);
    }

    // Get all email log entries
    public List<EmailLog> GetAll()
    {
        return _emailLogs.ToList();
    }

    // Get email logs related to a specific reference (for example, Appointment Id)
    public List<EmailLog> GetByReference(Guid referenceId)
    {
        return _emailLogs
            .Where(e => e.ReferenceId == referenceId)
            .ToList();
    }
}
