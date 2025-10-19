using RuedasFelices.Data;
using RuedasFelices.Interfaces;
using RuedasFelices.Models;

namespace RuedasFelices.Repositories;

public class AppointmentRepository : IAppointment
{
    private readonly List<Appointment> _appointments = Database.Appointments;
    private readonly List<Vehicle> _vehicles = Database.Vehicles;

    // Add a new appointment
    public void Add(Appointment appointment)
    {
        _appointments.Add(appointment);
    }

    // Update appointment information
    public void Update(Appointment appointment)
    {
        var existing = _appointments.FirstOrDefault(a => a.Id == appointment.Id);
        if (existing != null)
        {
            existing.VehicleId = appointment.VehicleId;
            existing.InspectorId = appointment.InspectorId;
            existing.Date = appointment.Date;
            existing.Status = appointment.Status;
        }
    }

    // Delete appointment by Id
    public void Delete(Guid id)
    {
        var appointment = _appointments.FirstOrDefault(a => a.Id == id);
        if (appointment != null)
        {
            _appointments.Remove(appointment);
        }
    }

    // Get appointment by Id
    public Appointment? GetById(Guid id)
    {
        return _appointments.FirstOrDefault(a => a.Id == id);
    }

    // Get all appointments
    public List<Appointment> GetAll()
    {
        return _appointments.ToList();
    }

    // Get appointments by Client Id
    public List<Appointment> GetByClient(Guid clientId)
    {
        var clientVehicles = _vehicles.Where(v => v.ClientId == clientId).Select(v => v.Id).ToList();
        return _appointments.Where(a => clientVehicles.Contains(a.VehicleId)).ToList();
    }

    // Get appointments by Vehicle Id
    public List<Appointment> GetByVehicle(Guid vehicleId)
    {
        return _appointments.Where(a => a.VehicleId == vehicleId).ToList();
    }

    // Get appointments by Inspector Id
    public List<Appointment> GetByInspector(Guid inspectorId)
    {
        return _appointments.Where(a => a.InspectorId == inspectorId).ToList();
    }
}
