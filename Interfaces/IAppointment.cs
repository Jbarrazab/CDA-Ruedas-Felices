using RuedasFelices.Models;

namespace RuedasFelices.Interfaces;

public interface IAppointment
{
    void Add(Appointment appointment);
    void Update(Appointment appointment);
    void Delete(Guid id);
    Appointment? GetById(Guid id);
    List<Appointment> GetAll();
    List<Appointment> GetByClient(Guid clientId);
    List<Appointment> GetByVehicle(Guid vehicleId);
    List<Appointment> GetByInspector(Guid inspectorId);
}
