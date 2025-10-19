namespace RuedasFelices.Models;

public enum VehicleType
{
    Car,
    Motorcycle
}

public class Vehicle
{
    public Guid Id { get; set; }
    public Guid ClientId { get; set; }
    public string Plate { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public VehicleType VehicleType { get; set; }  

    public Vehicle(Guid clientId, string plate, string brand, string model, int year, VehicleType vehicleType)
    {
        Id = Guid.NewGuid();
        ClientId = clientId;
        Plate = plate;
        Brand = brand;
        Model = model;
        Year = year;
        VehicleType = vehicleType;
    }

    public void ShowInformation()
    {
        Console.WriteLine(
            $"Plate: {Plate}, Brand: {Brand}, Model: {Model}, Year: {Year}, Type: {VehicleType}");
    }
}
