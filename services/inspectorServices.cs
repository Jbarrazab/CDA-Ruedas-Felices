using RuedasFelices.Interfaces;
using RuedasFelices.Models;

namespace RuedasFelices.Services;

public class InspectorService
{
    private readonly IInspectorRepository _inspectorRepository;

    public InspectorService(IInspectorRepository inspectorRepository)
    {
        _inspectorRepository = inspectorRepository;
    }

    // Add a new inspector
    public void Add(Inspector inspector)
    {
        var existing = _inspectorRepository.GetByIdentification(inspector.Identification);
        if (existing != null)
        {
            Console.WriteLine("Error: An inspector with this identification already exists.");
            return;
        }

        _inspectorRepository.Add(inspector);
        Console.WriteLine("Inspector added successfully.");
    }

    // Update inspector information
    public void Update(Inspector inspector)
    {
        var existing = _inspectorRepository.GetById(inspector.Id);
        if (existing == null)
        {
            Console.WriteLine("Error: Inspector not found.");
            return;
        }

        _inspectorRepository.Update(inspector);
        Console.WriteLine("Inspector updated successfully.");
    }

    // List all inspectors
    public void ShowAll()
    {
        var inspectors = _inspectorRepository.GetAll();
        if (inspectors.Count == 0)
        {
            Console.WriteLine("No inspectors registered.");
            return;
        }

        foreach (var inspector in inspectors)
        {
            inspector.ShowInformation();
        }
    }

    // List inspectors by inspection type
    public void ShowByInspectionType(InspectionType type)
    {
        var inspectors = _inspectorRepository.GetByInspectionType(type);
        if (inspectors.Count == 0)
        {
            Console.WriteLine($"No inspectors found for inspection type: {type}");
            return;
        }

        foreach (var inspector in inspectors)
        {
            inspector.ShowInformation();
        }
    }

// Get inspector by identification
    public Inspector? GetByIdentification(string identification)
    {
        return _inspectorRepository.GetByIdentification(identification);
    }
}
