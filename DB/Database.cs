using CDA_Ruedas_Felices.Models;
using RuedasFelices.Models;

namespace CDA_Ruedas_Felices.DB
{
    public class Database
    {
        public static List<Client> Clients = [];
        public static List<Inspector> inspectors = [];
        public static List<Vehicle> Vehicle = [];
        public static List<Appointment> appointments = [];
        public static List<EmailLog> EmailLogs = [];
    }
}
