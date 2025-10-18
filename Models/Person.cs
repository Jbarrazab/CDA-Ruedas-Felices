namespace RuedasFelices.Models
{
    public class Person
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Identification { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        // Constructor to initialize the personal information of the person
        public Person(string name, string lastName, string identification, string email, string phone)
        {
            Id = Guid.NewGuid();
            Name = name;
            LastName = lastName;
            Identification = identification;
            Email = email;
            Phone = phone;
        }

        // Method to display Person information
        public virtual void ShowInformation()
        {
            Console.WriteLine(
                $"ID: {Id}, Name: {Name} {LastName}, Identification: {Identification}, Email: {Email}, Phone: {Phone}");
        }
    }
}
