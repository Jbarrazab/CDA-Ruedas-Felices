using RuedasFelices.Models;

namespace RuedasFelices.Interfaces;

public interface IClient
{
    void Add(Client client);
    void Update(Client client);
    void Delete(Guid id);
    Client? GetById(Guid id);
    Client? GetByIdentification(string identification);
    List<Client> GetAll();
}
