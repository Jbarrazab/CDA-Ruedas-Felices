using RuedasFelices.Data;
using RuedasFelices.Interfaces;
using RuedasFelices.Models;

namespace RuedasFelices.Repositories;

public class VehicleRepository : IVehicle
{
    private readonly List<Vehicle> _vehicles = Database.Vehicles;

    // Add a new vehicle
    public void Add(Vehicle vehicle)
    {
        _vehicles.Add(vehicle);
    }

    // Update vehicle information
    public void Update(Vehicle vehicle)
    {
        var existing = _vehicles.FirstOrDefault(v => v.Id == vehicle.Id);
        if (existing != null)
        {
            existing.Plate = vehicle.Plate;
            existing.Brand = vehicle.Brand;
            existing.Model = vehicle.Model;
            existing.Year = vehicle.Year;
            // VehicleType property does not exist on Vehicle model; skip assignment
            existing.ClientId = vehicle.ClientId;
        }
    }

    // Delete vehicle by Id
    public void Delete(Guid id)
    {
        var vehicle = _vehicles.FirstOrDefault(v => v.Id == id);
        if (vehicle != null)
        {
            _vehicles.Remove(vehicle);
        }
    }

    // Get vehicle by Id
    public Vehicle? GetById(Guid id)
    {
        return _vehicles.FirstOrDefault(v => v.Id == id);
    }

    // Get vehicle by Plate
    public Vehicle? GetByPlate(string plate)
    {
        return _vehicles.FirstOrDefault(v => v.Plate == plate);
    }

    // Get all vehicles
    public List<Vehicle> GetAll()
    {
        return _vehicles.ToList();
    }

    // Get vehicles by Client Id
    public List<Vehicle> GetByClient(Guid clientId)
    {
        return _vehicles.Where(v => v.ClientId == clientId).ToList();
    }
}
