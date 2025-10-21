using RuedasFelices.Models;
using RuedasFelices.Services;

namespace RuedasFelices.Menus;

public static class ClientMenu
{
    public static void Show(ClientService clientService)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("==============================================");
            Console.WriteLine("           CLIENT MANAGEMENT MENU");
            Console.WriteLine("==============================================");
            Console.WriteLine("1. Add new client");
            Console.WriteLine("2. Update client information");
            Console.WriteLine("3. List all clients");
            Console.WriteLine("0. Back to Main Menu");
            Console.WriteLine("Option number (0-3)");
            Console.WriteLine("==============================================");
            Console.Write("Select an option: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    AddClient(clientService);
                    break;
                case "2":
                    UpdateClient(clientService);
                    break;
                case "3":
                    clientService.ShowAll();
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

    private static void AddClient(ClientService clientService)
    {
        Console.Clear();
        Console.WriteLine("=== Add New Client ===");

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

        Console.Write("Address: ");
        var address = Console.ReadLine() ?? "";

        var client = new Client(name, lastName, id, email, phone, address);
        clientService.Add(client);
    }

    private static void UpdateClient(ClientService clientService)
    {
        Console.Clear();
        Console.WriteLine("=== Update Client Information ===");

        Console.Write("Enter client identification: ");
        var identification = Console.ReadLine() ?? "";

        var client = clientService.GetByIdentification(identification);
        if (client == null)
        {
            Console.WriteLine("Error: Client not found.");
            return;
        }

        Console.Write($"Name ({client.Name}): ");
        var name = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(name)) client.Name = name;

        Console.Write($"Last Name ({client.LastName}): ");
        var lastName = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(lastName)) client.LastName = lastName;

        Console.Write($"Email ({client.Email}): ");
        var email = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(email)) client.Email = email;

        Console.Write($"Phone ({client.Phone}): ");
        var phone = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(phone)) client.Phone = phone;

        Console.Write($"Address ({client.Address}): ");
        var address = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(address)) client.Address = address;

        clientService.Update(client);
    }
}
