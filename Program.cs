using DotNetEnv;
using RuedasFelices.Menus;

namespace RuedasFelices;

class Program
{
    static void Main()
    {
        // Load environment variables from .env
        Env.Load();

        // Launch the main menu
        MainMenu.Show();
    }
}
