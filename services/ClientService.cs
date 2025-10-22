using RuedasFelices.Interfaces;
using RuedasFelices.Models;

namespace RuedasFelices.Services;

public class ClientService
{
    private readonly IClientRepository _clientRepository;

    public ClientService(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    // Add a new client
    public void Add(Client client)
    {
        var existing = _clientRepository.GetByIdentification(client.Identification);
        if (existing != null)
        {
            Console.WriteLine("Error: A client with this identification already exists.");
            return;
        }

        _clientRepository.Add(client);
        Console.WriteLine("Client added successfully.");
    }

    // Update client information
    public void Update(Client client)
    {
        var existing = _clientRepository.GetById(client.Id);
        if (existing == null)
        {
            Console.WriteLine("Error: Client not found.");
            return;
        }

        _clientRepository.Update(client);
        Console.WriteLine("Client updated successfully.");
    }

    // Delete client by Identification
    public void DeleteByIdentification(string identification)
    {
        var existing = _clientRepository.GetByIdentification(identification);
        if (existing == null)
        {
            Console.WriteLine("Error: Client not found with that identification.");
            return;
        }

        _clientRepository.Delete(existing.Id);
        Console.WriteLine("Client deleted successfully by identification.");
    }

    // List all clients
    public void ShowAll()
    {
        var clients = _clientRepository.GetAll();
        if (clients.Count == 0)
        {
            Console.WriteLine("No clients registered.");
            return;
        }

        foreach (var client in clients)
        {
            client.ShowInformation();
        }
    }

    // Find client by identification
    public Client? GetByIdentification(string identification)
    {
        return _clientRepository.GetByIdentification(identification);
    }
}
