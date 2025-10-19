using RuedasFelices.Data;
using RuedasFelices.Interfaces;
using RuedasFelices.Repositories;
using RuedasFelices.Services;


namespace RuedasFelices.Menus;

public static class MainMenu
{
    public static void Show()
    {
        // Initialize repositories
        IClientRepository clientRepository = new ClientRepository();
        IInspectorRepository inspectorRepository = new InspectorRepository();
        IVehicleRepository vehicleRepository = new VehicleRepository();
        IAppointmentRepository appointmentRepository = new AppointmentRepository();
        IEmailLogRepository emailLogRepository = new EmailLogRepository();

        // Initialize infrastructure email service
        IEmailService emailSender = new EmailSender();
        EmailService emailService = new EmailService(emailSender, emailLogRepository);

        // Initialize domain services
        ClientService clientService = new ClientService(clientRepository);
        InspectorService inspectorService = new InspectorService(inspectorRepository);
        VehicleService vehicleService = new VehicleService(vehicleRepository, clientRepository);
        AppointmentService appointmentService = new AppointmentService(
            appointmentRepository,
            vehicleRepository,
            inspectorRepository,
            clientRepository,
            emailService
        );

        // Start menu navigation loop
        while (true)
        {
            Console.Clear();
            Console.WriteLine("==============================================");
            Console.WriteLine("       CDA Ruedas Felices - Main Menu");
            Console.WriteLine("==============================================");
            Console.WriteLine("1. Manage Clients");
            Console.WriteLine("2. Manage Inspectors");
            Console.WriteLine("3. Manage Vehicles");
            Console.WriteLine("4. Manage Appointments");
            Console.WriteLine("5. Email Log");
            Console.WriteLine("0. Exit");
            Console.WriteLine("==============================================");
            Console.Write("Select an option: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    ClientMenu.Show(clientService);
                    break;
                case "2":
                    InspectorMenu.Show(inspectorService);
                    break;
                case "3":
                    VehicleMenu.Show(vehicleService, clientService);
                    break;
                case "4":
                    AppointmentMenu.Show(appointmentService);
                    break;
                case "5":
                    EmailLogMenu.Show(emailService);
                    break;
                case "0":
                    Console.WriteLine("Exiting the system...");
                    return;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }

            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey();
        }
    }
}
