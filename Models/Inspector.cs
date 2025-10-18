namespace RuedasFelices.Models
{
    public enum InspectionType
    {
        Light,
        Heavy,
        Motorcycles
    }

    public class Inspector : Person
    {
        public InspectionType InspectionType { get; set; }

        // Constructor to initialize inspector information, inheriting from Person
        public Inspector(string name, string lastName, string identification, string email, string phone, InspectionType inspectionType)
            : base(name, lastName, identification, email, phone)
        {
            InspectionType = inspectionType;
        }

        // Method to display Inspector information
        public override void ShowInformation()
        {
            Console.WriteLine(
                $"ID: {Id}, Name: {Name} {LastName}, Identification: {Identification}, Email: {Email}, Phone: {Phone}, Inspection Type: {InspectionType}");
        }
    }
}