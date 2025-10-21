using RuedasFelices.Models;

namespace RuedasFelices.Interfaces;

public interface IAppointmentRepository
{
    // Add a new appointment
    void Add(Appointment appointment);

    // Update appointment details
    void Update(Appointment appointment);

    // Delete appointment by Id
    void Delete(Guid id);

    // Get appointment by Id
    Appointment? GetById(Guid id);

    // Get all appointments
    List<Appointment> GetAll();

    //  Get appointments by Client Id
    List<Appointment> GetByClient(Guid clientId);

    //  Get appointments by Vehicle Id
    List<Appointment> GetByVehicle(Guid vehicleId);

    //  Get appointments by Inspector Id
    List<Appointment> GetByInspector(Guid inspectorId);
}
