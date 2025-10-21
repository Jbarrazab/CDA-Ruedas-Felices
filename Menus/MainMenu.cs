using RuedasFelices.Services;

namespace RuedasFelices.Menus;

public static class MainMenu
{
    public static void Show()
    {
        // Initialize repositories
        var clientRepository = new RuedasFelices.Repositories.ClientRepository();
        var inspectorRepository = new RuedasFelices.Repositories.InspectorRepository();
        var vehicleRepository = new RuedasFelices.Repositories.VehicleRepository();
        var appointmentRepository = new RuedasFelices.Repositories.AppointmentRepository();
        var emailLogRepository = new RuedasFelices.Repositories.EmailLogRepository();

        // Initialize email components
        var emailSender = new RuedasFelices.Services.EmailSender();
        var emailService = new EmailService(emailSender, emailLogRepository);

        // Initialize business services
        var clientService = new ClientService(clientRepository);
        var inspectorService = new InspectorService(inspectorRepository);
        var vehicleService = new VehicleService(vehicleRepository, clientRepository);
        var appointmentService = new AppointmentService(
            appointmentRepository,
            vehicleRepository,
            inspectorRepository,
            clientRepository,
            emailService);

        while (true)
        {
            Console.Clear();
            Console.WriteLine("==============================================");
            Console.WriteLine("         C.D.A. RUEDAS FELICES SYSTEM");
            Console.WriteLine("==============================================");
            Console.WriteLine("1. Manage Clients");
            Console.WriteLine("2. Manage Inspectors");
            Console.WriteLine("3. Manage Vehicles");
            Console.WriteLine("4. Manage Appointments");
            Console.WriteLine("5. View Email Log");
            Console.WriteLine("0. Exit");
            Console.WriteLine("==============================================");

            try
            {
                Console.Write("Select an option (0-5): ");
                string? input = Console.ReadLine();

                // Validate numeric input
                if (!int.TryParse(input, out int optionNumber))
                {
                    Console.WriteLine("Error: Please enter a valid number between 0 and 5.");
                }
                else if (optionNumber < 0 || optionNumber > 5)
                {
                    Console.WriteLine("Error: Option must be between 0 and 5.");
                }
                else
                {
                    switch (optionNumber)
                    {
                        case 1:
                            ClientMenu.Show(clientService);
                            break;
                        case 2:
                            InspectorMenu.Show(inspectorService);
                            break;
                        case 3:
                            VehicleMenu.Show(vehicleService, clientService);
                            break;
                        case 4:
                            AppointmentMenu.Show(appointmentService);
                            break;
                        case 5:
                            EmailLogMenu.Show(emailService);
                            break;
                        case 0:
                            Console.WriteLine("Exiting system...");
                            return;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
