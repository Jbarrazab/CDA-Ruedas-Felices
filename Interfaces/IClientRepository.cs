using RuedasFelices.Models;

namespace RuedasFelices.Interfaces;

public interface IClientRepository
{
    // Add a new client
    void Add(Client client);

    // Update an existing client
    void Update(Client client);

    // Delete a client by Id
    void Delete(Guid id);

    // Get a client by Id
    Client? GetById(Guid id);

    // Get a client by Identification
    Client? GetByIdentification(string identification);

    // Get all clients
    List<Client> GetAll();
}
