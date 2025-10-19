namespace RuedasFelices.Models;

public enum AppointmentStatus
{
    Scheduled,
    Canceled,    
    Completed
}

public class Appointment
{
    public Guid Id { get; set; }
    public Guid VehicleId { get; set; }
    public Guid InspectorId { get; set; }
    public DateTime Date { get; set; }
    public AppointmentStatus Status { get; set; }

    public Appointment(Guid vehicleId, Guid inspectorId, DateTime date)
    {
        Id = Guid.NewGuid();
        VehicleId = vehicleId;
        InspectorId = inspectorId;
        Date = date;
        Status = AppointmentStatus.Scheduled; // default
    }

    public void ShowInformation()
    {
        Console.WriteLine($"Appointment ID: {Id}, Date: {Date}, Status: {Status}");
    }
}
