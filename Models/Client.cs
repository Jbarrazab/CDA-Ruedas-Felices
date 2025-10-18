namespace RuedasFelices.Models
{
    public class Client : Person
    {
        public string Address { get; set; }

        // Constructor to initialize the client with the personal information
        public Client(string name, string lastName, string identification, string email, string phone, string address)
            : base(name, lastName, identification, email, phone)
        {
            Address = address;
        }

        // Method to display client information
        public override void ShowInformation()
        {
            Console.WriteLine(
                $"ID: {Id}, Name: {Name} {LastName}, Identification: {Identification}, Email: {Email}, Phone: {Phone}, Address: {Address}");
        }
    }
}
