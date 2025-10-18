namespace RuedasFelices.Models;

public class EmailLog
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string ToEmail { get; set; }
    public string Subject { get; set; }
    public DateTime SentDate { get; set; }
    public bool SentSuccessfully { get; set; }

    public override string ToString()
    {
        return $"Id: {Id}, To: {ToEmail}, Subject: {Subject}, SentDate: {SentDate}, SentSuccessfully: {SentSuccessfully}";
    }
}
