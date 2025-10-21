using RuedasFelices.Interfaces;
using RuedasFelices.Models;

namespace RuedasFelices.Services;

public class VehicleService
{
    private readonly IVehicleRepository _vehicleRepository;
    private readonly IClientRepository _clientRepository;

    public VehicleService(IVehicleRepository vehicleRepository, IClientRepository clientRepository)
    {
        _vehicleRepository = vehicleRepository;
        _clientRepository = clientRepository;
    }

    // Add a new vehicle
    public void Add(Vehicle vehicle)
    {
        var existing = _vehicleRepository.GetByPlate(vehicle.Plate);
        if (existing != null)
        {
            Console.WriteLine("Error: A vehicle with this plate already exists.");
            return;
        }

        var client = _clientRepository.GetById(vehicle.ClientId);
        if (client == null)
        {
            Console.WriteLine("Error: The associated client does not exist.");
            return;
        }

        _vehicleRepository.Add(vehicle);
        Console.WriteLine("Vehicle added successfully.");
    }

    // Update vehicle
    public void Update(Vehicle vehicle)
    {
        var existing = _vehicleRepository.GetById(vehicle.Id);
        if (existing == null)
        {
            Console.WriteLine("Error: Vehicle not found.");
            return;
        }

        _vehicleRepository.Update(vehicle);
        Console.WriteLine("Vehicle updated successfully.");
    }

// Get vehicle by plate
    public Vehicle? GetByPlate(string plate)
    {
        return _vehicleRepository.GetByPlate(plate);
    }

    // Show all vehicles
    public void ShowAll()
    {
        var vehicles = _vehicleRepository.GetAll();
        if (vehicles.Count == 0)
        {
            Console.WriteLine("No vehicles registered.");
            return;
        }

        foreach (var vehicle in vehicles)
        {
            Console.WriteLine($"Guid: {vehicle.Id}, Plate: {vehicle.Plate}, Brand: {vehicle.Brand}, Model: {vehicle.Model}, Year: {vehicle.Year}, Type: {vehicle.VehicleType}");
        }
    }

    // Show vehicles by client
    public void ShowByClient(Guid clientId)
    {
        var vehicles = _vehicleRepository.GetByClient(clientId);
        if (vehicles.Count == 0)
        {
            Console.WriteLine("No vehicles found for this client.");
            return;
        }

        foreach (var vehicle in vehicles)
        {
            Console.WriteLine($"Plate: {vehicle.Plate}, Brand: {vehicle.Brand}, Model: {vehicle.Model}, Year: {vehicle.Year}, Type: {vehicle.VehicleType}");
        }
    }
}
