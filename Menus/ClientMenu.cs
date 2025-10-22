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
            Console.WriteLine("4. Delete client by identification");
            Console.WriteLine("0. Back to Main Menu");
            Console.WriteLine("Option number (0-4)");
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
                case "4":
                    DeleteClient(clientService);
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
        try
        {
            Console.Write("Name: ");
            var name = Console.ReadLine()?.Trim() ?? "";
            if (string.IsNullOrWhiteSpace(name) || !name.All(char.IsLetter))
            {
                Console.WriteLine(" Error: Name must contain only letters.");
                return;
            }

            Console.Write("Last Name: ");
            var lastName = Console.ReadLine()?.Trim() ?? "";
            if (string.IsNullOrWhiteSpace(lastName) || !lastName.All(char.IsLetter))
            {
                Console.WriteLine(" Error: Last name must contain only letters.");
                return;
            }

            Console.Write("Identification: ");
            var id = Console.ReadLine()?.Trim() ?? "";
            if (string.IsNullOrWhiteSpace(id) || !id.All(char.IsDigit))
            {
                Console.WriteLine(" Error: Identification must contain only numbers.");
                return;
            }

            Console.Write("Email: ");
            var email = Console.ReadLine()?.Trim() ?? "";

            Console.Write("Phone: ");
            var phone = Console.ReadLine()?.Trim() ?? "";
            if (string.IsNullOrWhiteSpace(phone) || !phone.All(char.IsDigit))
            {
                Console.WriteLine(" Error: Phone must contain only numbers.");
                return;
            }

            Console.Write("Address: ");
            var address = Console.ReadLine()?.Trim() ?? "";
            if (string.IsNullOrWhiteSpace(address))
            {
                Console.WriteLine("Error: Address cannot be empty.");
                return;
            }

            var client = new Client(name, lastName, id, email, phone, address);
            clientService.Add(client);
        }
        catch (Exception ex)
        {
            Console.WriteLine($" Unexpected error: {ex.Message}");
        }
    }

    private static void UpdateClient(ClientService clientService)
    {
        Console.Clear();
        Console.WriteLine("=== Update Client Information ===");

        try
        {
            Console.Write("Enter client identification: ");
            var identification = Console.ReadLine()?.Trim() ?? "";

            var client = clientService.GetByIdentification(identification);
            if (client == null)
            {
                Console.WriteLine("Error: Client not found.");
                return;
            }

            Console.Write($"Name ({client.Name}): ");
            var name = Console.ReadLine()?.Trim();
            if (!string.IsNullOrWhiteSpace(name))
            {
                if (!name.All(char.IsLetter))
                {
                    Console.WriteLine("Error: Name must contain only letters.");
                    return;
                }
                client.Name = name;
            }

            Console.Write($"Last Name ({client.LastName}): ");
            var lastName = Console.ReadLine()?.Trim();
            if (!string.IsNullOrWhiteSpace(lastName))
            {
                if (!lastName.All(char.IsLetter))
                {
                    Console.WriteLine("Error: Last name must contain only letters.");
                    return;
                }
                client.LastName = lastName;
            }

            Console.Write($"Email ({client.Email}): ");
            var email = Console.ReadLine()?.Trim();
            if (!string.IsNullOrWhiteSpace(email)) client.Email = email;

            Console.Write($"Phone ({client.Phone}): ");
            var phone = Console.ReadLine()?.Trim();
            if (!string.IsNullOrWhiteSpace(phone))
            {
                if (!phone.All(char.IsDigit))
                {
                    Console.WriteLine("Error: Phone must contain only numbers.");
                    return;
                }
                client.Phone = phone;
            }

            Console.Write($"Address ({client.Address}): ");
            var address = Console.ReadLine()?.Trim();
            if (!string.IsNullOrWhiteSpace(address))
            {
                if (string.IsNullOrWhiteSpace(address))
                {
                    Console.WriteLine("Error: Address cannot be empty.");
                    return;
                }
                client.Address = address;
            }

            clientService.Update(client);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }
    }
    private static void DeleteClient(ClientService clientService)
    {
        Console.Clear();
        Console.WriteLine("=== Delete Client ===");

        Console.Write("Enter client identification: ");
        var identification = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(identification))
        {
            Console.WriteLine("Error: Identification cannot be empty.");
            return;
        }

        clientService.DeleteByIdentification(identification);
    }
}