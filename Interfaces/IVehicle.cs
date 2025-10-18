using RuedasFelices.Models;

namespace RuedasFelices.Interfaces;

public interface IVehicle
{
    void Add(Vehicle vehicle);
    void Update(Vehicle vehicle);
    void Delete(Guid id);
    Vehicle? GetById(Guid id);
    Vehicle? GetByPlate(string plate);
    List<Vehicle> GetAll();
    List<Vehicle> GetByClient(Guid clientId);
}
