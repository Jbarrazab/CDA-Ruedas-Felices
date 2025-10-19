using RuedasFelices.Models;

namespace RuedasFelices.Interfaces;

public interface IEmailLogRepository
{
    // Add a new email log
    void Add(EmailLog emailLog);

    // Get all email logs
    List<EmailLog> GetAll();

    // Get email logs by reference (e.g., Appointment Id)
    List<EmailLog> GetByReference(Guid referenceId);
}
