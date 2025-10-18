using RuedasFelices.Data;
using RuedasFelices.Interfaces;
using RuedasFelices.Models;

namespace RuedasFelices.Repositories;

public class ClientRepository : IClient
{
    private readonly List<Client> _clients = Database.Clients;

    // Add a new client
    public void Add(Client client)
    {
        _clients.Add(client);
    }

    // Update an existing client
    public void Update(Client client)
    {
        var existing = _clients.FirstOrDefault(c => c.Id == client.Id);
        if (existing != null)
        {
            existing.Name = client.Name;
            existing.LastName = client.LastName;
            existing.Identification = client.Identification;
            existing.Email = client.Email;
            existing.Phone = client.Phone;
            existing.Address = client.Address;
        }
    }

    // Delete a client by Id
    public void Delete(Guid id)
    {
        var client = _clients.FirstOrDefault(c => c.Id == id);
        if (client != null)
        {
            _clients.Remove(client);
        }
    }

    // Get a client by Id
    public Client? GetById(Guid id)
    {
        return _clients.FirstOrDefault(c => c.Id == id);
    }

    // Get a client by Identification
    public Client? GetByIdentification(string identification)
    {
        return _clients.FirstOrDefault(c => c.Identification == identification);
    }

    // Get all clients
    public List<Client> GetAll()
    {
        return _clients.ToList();
    }
}
