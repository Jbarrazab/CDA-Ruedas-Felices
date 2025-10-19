namespace RuedasFelices.Models;

public enum SendStatus
{
    Sent,
    NotSent
}

public class EmailLog
{
    public Guid Id { get; set; }
    public string To { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public DateTime Date { get; set; }
    public SendStatus Status { get; set; }

    // Reference to the entity related to this email (e.g., Appointment Id)
    public Guid? ReferenceId { get; set; }

    public EmailLog(string to, string subject, string body, SendStatus status, Guid? referenceId = null)
    {
        Id = Guid.NewGuid();
        To = to;
        Subject = subject;
        Body = body;
        Date = DateTime.Now;
        Status = status;
        ReferenceId = referenceId;
    }

    public void ShowInformation()
    {
        Console.WriteLine($"ID: {Id}, To: {To}, Subject: {Subject}, Status: {Status}, Date: {Date}, Reference: {ReferenceId}");
    }
}
