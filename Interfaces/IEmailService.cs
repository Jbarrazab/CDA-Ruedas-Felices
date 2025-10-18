namespace RuedasFelices.Interfaces
{
    public interface IEmailService
    {
        // Send an email and return true if sent successfully
        bool Send(string to, string subject, string body);

    }
}