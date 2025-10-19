using RuedasFelices.Interfaces;
using RuedasFelices.Models;
using RuedasFelices.Services;

namespace RuedasFelices.Services;


public class AppointmentService
{
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IVehicleRepository _vehicleRepository;
    private readonly IInspectorRepository _inspectorRepository;
    private readonly IClientRepository _clientRepository;
    private readonly EmailService _emailService;

    public AppointmentService(
        IAppointmentRepository appointmentRepository,
        IVehicleRepository vehicleRepository,
        IInspectorRepository inspectorRepository,
        IClientRepository clientRepository,
        EmailService emailService)
    {
        _appointmentRepository = appointmentRepository;
        _vehicleRepository = vehicleRepository;
        _inspectorRepository = inspectorRepository;
        _clientRepository = clientRepository;
        _emailService = emailService;
    }

    // Schedule a new appointment
    public void Add(Appointment appointment)
    {
        var vehicle = _vehicleRepository.GetById(appointment.VehicleId);
        if (vehicle == null)
        {
            Console.WriteLine("Error: Vehicle not found.");
            return;
        }

        var inspector = _inspectorRepository.GetById(appointment.InspectorId);
        if (inspector == null)
        {
            Console.WriteLine("Error: Inspector not found.");
            return;
        }

        // Validation: Compatibility between vehicle and inspection type
        if (!IsCompatible(inspector.InspectionType, vehicle.VehicleType))
        {
            Console.WriteLine("Error: Inspector type is not compatible with vehicle type.");
            return;
        }

        // Validation: prevent overlapping schedules
        if (HasConflict(inspector.Id, vehicle.Id, appointment.Date))
        {
            Console.WriteLine("Error: Inspector or vehicle already has an appointment at this time.");
            return;
        }

        _appointmentRepository.Add(appointment);
        Console.WriteLine("Appointment added successfully.");

        // Send email confirmation
        var client = _clientRepository.GetById(vehicle.ClientId);
        if (client != null)
        {
            var body = $"Hello {client.Name}, your appointment for vehicle {vehicle.Plate} " +
                       $"is scheduled on {appointment.Date}. Inspector: {inspector.Name} {inspector.LastName}.";
            _emailService.SendEmail(client.Email, "Appointment Confirmation", body, appointment.Id);
        }
    }

    // Cancel an appointment
    public void Cancel(Guid appointmentId)
    {
        var appointment = _appointmentRepository.GetById(appointmentId);
        if (appointment == null)
        {
            Console.WriteLine("Error: Appointment not found.");
            return;
        }

        appointment.Status = AppointmentStatus.Canceled;
        _appointmentRepository.Update(appointment);
        Console.WriteLine("Appointment canceled successfully.");
    }

    // Complete an appointment
    public void Complete(Guid appointmentId)
    {
        var appointment = _appointmentRepository.GetById(appointmentId);
        if (appointment == null)
        {
            Console.WriteLine("Error: Appointment not found.");
            return;
        }

        appointment.Status = AppointmentStatus.Completed;
        _appointmentRepository.Update(appointment);
        Console.WriteLine("Appointment completed successfully.");
    }

    private bool HasConflict(Guid inspectorId, Guid vehicleId, DateTime date)
    {
        return _appointmentRepository.GetAll().Any(a =>
            a.Status == AppointmentStatus.Scheduled &&
            (a.InspectorId == inspectorId || a.VehicleId == vehicleId) &&
            a.Date == date);
    }

    private bool IsCompatible(InspectionType inspectionType, VehicleType vehicleType)
    {
        return (inspectionType == InspectionType.Light && vehicleType == VehicleType.Car)
            || (inspectionType == InspectionType.Motorcycles && vehicleType == VehicleType.Motorcycle);
    }
}
