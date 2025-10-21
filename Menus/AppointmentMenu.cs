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
            Console.Write("Select an option: ");
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
                    Console.WriteLine("Invalid option. Try again.");
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
            // Ask for vehicle plate
            Console.Write("Vehicle plate: ");
            string? plate = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(plate))
            {
                Console.WriteLine("Error: Plate cannot be empty.");
                return;
            }

            // Search vehicle by plate
            var vehicle = appointmentService.GetVehicleByPlate(plate);
            if (vehicle == null)
            {
                Console.WriteLine("Error: Vehicle not found.");
                return;
            }

            // Ask for inspector identification
            Console.Write("Inspector identification: ");
            string? inspectorId = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(inspectorId))
            {
                Console.WriteLine("Error: Identification cannot be empty.");
                return;
            }

            // Search inspector by identification
            var inspector = appointmentService.GetInspectorByIdentification(inspectorId);
            if (inspector == null)
            {
                Console.WriteLine("Error: Inspector not found.");
                return;
            }

            // Ask for date/time
            Console.Write("Date and Time (yyyy-MM-dd HH:mm): ");
            DateTime date = DateTime.Parse(Console.ReadLine() ?? "");

            // Create and schedule appointment
            var appointment = new Appointment(vehicle.Id, inspector.Id, date);
            appointmentService.Add(appointment);
        }
        catch (FormatException)
        {
            Console.WriteLine("Error: Invalid data format. Please check date/time format.");
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
