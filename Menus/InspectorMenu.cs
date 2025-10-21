using RuedasFelices.Models;
using RuedasFelices.Services;

namespace RuedasFelices.Menus;

public static class InspectorMenu
{
    public static void Show(InspectorService inspectorService)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("==============================================");
            Console.WriteLine("           INSPECTOR MANAGEMENT MENU");
            Console.WriteLine("==============================================");
            Console.WriteLine("1. Add new inspector");
            Console.WriteLine("2. Update inspector information");
            Console.WriteLine("3. List all inspectors");
            Console.WriteLine("4. List inspectors by inspection type");
            Console.WriteLine("0. Back to Main Menu");
            Console.WriteLine("Option number (0-4)");
            Console.WriteLine("==============================================");
            Console.Write("Select an option: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    AddInspector(inspectorService);
                    break;
                case "2":
                    UpdateInspector(inspectorService);
                    break;
                case "3":
                    inspectorService.ShowAll();
                    break;
                case "4":
                    ListByType(inspectorService);
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

    private static void AddInspector(InspectorService inspectorService)
    {
        Console.Clear();
        Console.WriteLine("=== Add New Inspector ===");

        Console.Write("Name: ");
        var name = Console.ReadLine() ?? "";

        Console.Write("Last Name: ");
        var lastName = Console.ReadLine() ?? "";

        Console.Write("Identification: ");
        var id = Console.ReadLine() ?? "";

        Console.Write("Email: ");
        var email = Console.ReadLine() ?? "";

        Console.Write("Phone: ");
        var phone = Console.ReadLine() ?? "";

        Console.WriteLine("Select inspection type: 1) Light  2) Heavy  3) Motorcycles");
        var typeOption = Console.ReadLine();
        var type = typeOption switch
        {
            "1" => InspectionType.Light,
            "2" => InspectionType.Heavy,
            "3" => InspectionType.Motorcycles,
            _ => InspectionType.Light
        };

        var inspector = new Inspector(name, lastName, id, email, phone, type);
        inspectorService.Add(inspector);
    }

    private static void UpdateInspector(InspectorService inspectorService)
    {
        Console.Clear();
        Console.WriteLine("=== Update Inspector Information ===");

        Console.Write("Enter inspector identification: ");
        var id = Console.ReadLine() ?? "";

        var inspector = inspectorService.GetByIdentification(id);
        if (inspector == null)
        {
            Console.WriteLine("Error: Inspector not found.");
            return;
        }

        Console.Write($"Name ({inspector.Name}): ");
        var name = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(name)) inspector.Name = name;

        Console.Write($"Last Name ({inspector.LastName}): ");
        var lastName = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(lastName)) inspector.LastName = lastName;

        Console.Write($"Email ({inspector.Email}): ");
        var email = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(email)) inspector.Email = email;

        Console.Write($"Phone ({inspector.Phone}): ");
        var phone = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(phone)) inspector.Phone = phone;

        inspectorService.Update(inspector);
    }

    private static void ListByType(InspectorService inspectorService)
    {
        Console.Clear();
        Console.WriteLine("Select inspection type: 1) Light  2) Heavy  3) Motorcycles");
        var option = Console.ReadLine();
        var type = option switch
        {
            "1" => InspectionType.Light,
            "2" => InspectionType.Heavy,
            "3" => InspectionType.Motorcycles,
            _ => InspectionType.Light
        };

        inspectorService.ShowByInspectionType(type);
    }
}
