using RuedasFelices.Models;
namespace RuedasFelices.Interfaces
{
    public interface IEmailLog
    {
        void Add(EmailLog emailLog);
        List<EmailLog> GetAll();
        List<EmailLog> GetByReference(Guid referenceId);
    }
}
