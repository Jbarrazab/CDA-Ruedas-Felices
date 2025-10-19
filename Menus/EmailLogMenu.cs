using RuedasFelices.Services;

namespace RuedasFelices.Menus;

public static class EmailLogMenu
{
    public static void Show(EmailService emailService)
    {
        Console.Clear();
        Console.WriteLine("=== EMAIL LOG ===");
        emailService.ShowAllLogs();
        Console.WriteLine("\nPress any key to return...");
        Console.ReadKey();
    }
}
