using RuedasFelices.Models;

namespace RuedasFelices.Interfaces;

public interface IVehicleRepository
{
    // Add a new vehicle
    void Add(Vehicle vehicle);

    // Update existing vehicle data
    void Update(Vehicle vehicle);

    // Delete a vehicle by Id
    void Delete(Guid id);

    // Get a vehicle by Id
    Vehicle? GetById(Guid id);

    // Get a vehicle by plate
    Vehicle? GetByPlate(string plate);

    // Get all vehicles
    List<Vehicle> GetAll();

    // Get vehicles belonging to a specific client
    List<Vehicle> GetByClient(Guid clientId);
}