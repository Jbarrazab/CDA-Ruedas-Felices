namespace RuedasFelices.Models
{
    public enum AppointmentStatus
    {
        Scheduled,
        Cancelled,
        Completed
    }

    public class Appointment
    {
        public Guid Id { get; set; }
        public Guid VehicleId { get; set; }
        public Guid InspectorId { get; set; }
        public DateTime Date { get; set; }
        public AppointmentStatus Status { get; set; }

        // Constructor to initialize appointment information
        public Appointment(Guid vehicleId, Guid inspectorId, DateTime date)
        {
            Id = Guid.NewGuid();
            VehicleId = vehicleId;
            InspectorId = inspectorId;
            Date = date;
            Status = AppointmentStatus.Scheduled;
        }

        // Method to display appointment information
        public void ShowInformation()
        {
            Console.WriteLine(
                $"ID: {Id}, Vehicle ID: {VehicleId}, Inspector ID: {InspectorId}, Date: {Date}, Status: {Status}");
        }
    }
}
