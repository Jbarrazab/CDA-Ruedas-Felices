using RuedasFelices.Models;

namespace RuedasFelices.Interfaces;

public interface IAppointmentRepository
{
    // Add a new appointment
    void Add(Appointment appointment);

    // Update appointment information
    void Update(Appointment appointment);

    // Delete appointment by Id
    void Delete(Guid id);

    // Get an appointment by Id
    Appointment? GetById(Guid id);

    // Get all appointments
    List<Appointment> GetAll();

    // Get appointments by client Id
    List<Appointment> GetByClient(Guid clientId);

    // Get appointments by vehicle Id
    List<Appointment> GetByVehicle(Guid vehicleId);

    // Get appointments by inspector Id
    List<Appointment> GetByInspector(Guid inspectorId);
}
