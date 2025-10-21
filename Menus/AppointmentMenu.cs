using RuedasFelices.Models;
using RuedasFelices.Services;

namespace RuedasFelices.Menus;

public static class AppointmentMenu
{
    public static void Show(AppointmentService appointmentService)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("==============================================");
            Console.WriteLine("          APPOINTMENT MANAGEMENT MENU");
            Console.WriteLine("==============================================");
            Console.WriteLine("1. Schedule new appointment");
            Console.WriteLine("2. Cancel appointment");
            Console.WriteLine("3. Complete appointment");
            Console.WriteLine("0. Back to Main Menu");
            Console.WriteLine("==============================================");
            Console.Write("Select an option 0-3: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    AddAppointment(appointmentService);
                    break;
                case "2":
                    CancelAppointment(appointmentService);
                    break;
                case "3":
                    CompleteAppointment(appointmentService);
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Invalid option. Try again and select an option 0-3.");
                    break;
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }

    // =======================
    // Add a new appointment
    // =======================
    private static void AddAppointment(AppointmentService appointmentService)
    {
        Console.Clear();
        Console.WriteLine("=== Schedule New Appointment ===");

        try
        {
            Console.Write("Vehicle ID: ");
            Guid vehicleId = Guid.Parse(Console.ReadLine() ?? "");

            Console.Write("Inspector ID: ");
            Guid inspectorId = Guid.Parse(Console.ReadLine() ?? "");

            Console.Write("Date and Time (yyyy-MM-dd HH:mm): ");
            DateTime date = DateTime.Parse(Console.ReadLine() ?? "");

            // Create appointment
            var appointment = new Appointment(vehicleId, inspectorId, date);

            // Add appointment (service validates conflicts and duration)
            appointmentService.Add(appointment);
        }
        catch (FormatException)
        {
            Console.WriteLine("Error: Invalid data format. Please check IDs and date format.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }
    }

    // =======================
    // Cancel appointment
    // =======================
    private static void CancelAppointment(AppointmentService appointmentService)
    {
        Console.Clear();
        Console.WriteLine("=== Cancel Appointment ===");

        Console.Write("Enter Appointment ID: ");
        if (Guid.TryParse(Console.ReadLine(), out Guid appointmentId))
        {
            appointmentService.Cancel(appointmentId);
        }
        else
        {
            Console.WriteLine("Error: Invalid Appointment ID.");
        }
    }

    // =======================
    // Complete appointment
    // =======================
    private static void CompleteAppointment(AppointmentService appointmentService)
    {
        Console.Clear();
        Console.WriteLine("=== Complete Appointment ===");

        Console.Write("Enter Appointment ID: ");
        if (Guid.TryParse(Console.ReadLine(), out Guid appointmentId))
        {
            appointmentService.Complete(appointmentId);
        }
        else
        {
            Console.WriteLine("Error: Invalid Appointment ID.");
        }
    }
}
