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

    private static void AddAppointment(AppointmentService appointmentService)
    {
        Console.Clear();
        Console.WriteLine("=== Schedule New Appointment ===");

        Console.Write("Vehicle ID: ");
        var vehicleIdString = Console.ReadLine() ?? "";
        Guid.TryParse(vehicleIdString, out var vehicleId);

        Console.Write("Inspector ID: ");
        var inspectorIdString = Console.ReadLine() ?? "";
        Guid.TryParse(inspectorIdString, out var inspectorId);

        Console.Write("Date (yyyy-mm-dd HH:mm): ");
        DateTime.TryParse(Console.ReadLine(), out var date);

        var appointment = new Appointment(vehicleId, inspectorId, date);
        appointmentService.Add(appointment);
    }

    private static void CancelAppointment(AppointmentService appointmentService)
    {
        Console.Write("Enter Appointment ID: ");
        Guid.TryParse(Console.ReadLine(), out var id);
        appointmentService.Cancel(id);
    }

    private static void CompleteAppointment(AppointmentService appointmentService)
    {
        Console.Write("Enter Appointment ID: ");
        Guid.TryParse(Console.ReadLine(), out var id);
        appointmentService.Complete(id);
    }
}
