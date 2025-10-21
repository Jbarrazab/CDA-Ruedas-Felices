using RuedasFelices.Models;
using RuedasFelices.Services;

namespace RuedasFelices.Menus;

public static class VehicleMenu
{
    public static void Show(VehicleService vehicleService, ClientService clientService)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("==============================================");
            Console.WriteLine("            VEHICLE MANAGEMENT MENU");
            Console.WriteLine("==============================================");
            Console.WriteLine("1. Add new vehicle");
            Console.WriteLine("2. Update vehicle information");
            Console.WriteLine("3. List all vehicles");
            Console.WriteLine("4. List vehicles by client");
            Console.WriteLine("0. Back to Main Menu");
            Console.WriteLine("Option number (0-4)");
            Console.WriteLine("==============================================");
            Console.Write("Select an option: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    AddVehicle(vehicleService, clientService);
                    break;
                case "2":
                    UpdateVehicle(vehicleService);
                    break;
                case "3":
                    vehicleService.ShowAll();
                    break;
                case "4":
                    ListByClient(vehicleService, clientService);
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

    private static void AddVehicle(VehicleService vehicleService, ClientService clientService)
    {
        Console.Clear();
        Console.WriteLine("=== Add New Vehicle ===");

        Console.Write("Client identification: ");
        var clientIdString = Console.ReadLine() ?? "";
        var client = clientService.GetByIdentification(clientIdString);
        if (client == null)
        {
            Console.WriteLine("Error: Client not found.");
            return;
        }

        Console.Write("Plate: ");
        var plate = Console.ReadLine() ?? "";

        Console.Write("Brand: ");
        var brand = Console.ReadLine() ?? "";

        Console.Write("Model: ");
        var model = Console.ReadLine() ?? "";

        Console.Write("Year: ");
        var yearString = Console.ReadLine();
        int.TryParse(yearString, out var year);

        Console.WriteLine("Select vehicle type: 1) Car  2) Motorcycle");
        var typeOption = Console.ReadLine();
        var type = typeOption == "2" ? VehicleType.Motorcycle : VehicleType.Car;

        var vehicle = new Vehicle(client.Id, plate, brand, model, year, type);
        vehicleService.Add(vehicle);
    }

    private static void UpdateVehicle(VehicleService vehicleService)
    {
        Console.Clear();
        Console.WriteLine("=== Update Vehicle Information ===");

        Console.Write("Enter vehicle plate: ");
        var plate = Console.ReadLine() ?? "";

        var vehicle = vehicleService.GetByPlate(plate);
        if (vehicle == null)
        {
            Console.WriteLine("Error: Vehicle not found.");
            return;
        }

        Console.Write($"Brand ({vehicle.Brand}): ");
        var brand = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(brand)) vehicle.Brand = brand;

        Console.Write($"Model ({vehicle.Model}): ");
        var model = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(model)) vehicle.Model = model;

        Console.Write($"Year ({vehicle.Year}): ");
        var yearString = Console.ReadLine();
        if (int.TryParse(yearString, out var year)) vehicle.Year = year;

        Console.WriteLine("Select vehicle type: 1) Car  2) Motorcycle");
        var typeOption = Console.ReadLine();
        vehicle.VehicleType = typeOption == "2" ? VehicleType.Motorcycle : VehicleType.Car;

        vehicleService.Update(vehicle);
    }

    private static void ListByClient(VehicleService vehicleService, ClientService clientService)
    {
        Console.Clear();
        Console.WriteLine("=== Vehicles by Client ===");

        Console.Write("Client identification: ");
        var clientIdString = Console.ReadLine() ?? "";
        var client = clientService.GetByIdentification(clientIdString);
        if (client == null)
        {
            Console.WriteLine("Error: Client not found.");
            return;
        }

        vehicleService.ShowByClient(client.Id);
    }
}
