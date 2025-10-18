using RuedasFelices.Data;
using RuedasFelices.Interfaces;
using RuedasFelices.Models;

namespace RuedasFelices.Repositories;

public class InspectorRepository : IInspector
{
    private readonly List<Inspector> _inspectors = Database.Inspectors;

    // Add a new inspector
    public void Add(Inspector inspector)
    {
        _inspectors.Add(inspector);
    }

    // Update inspector information
    public void Update(Inspector inspector)
    {
        var existing = _inspectors.FirstOrDefault(i => i.Id == inspector.Id);
        if (existing != null)
        {
            existing.Name = inspector.Name;
            existing.LastName = inspector.LastName;
            existing.Identification = inspector.Identification;
            existing.Email = inspector.Email;
            existing.Phone = inspector.Phone;
            existing.InspectionType = inspector.InspectionType;
        }
    }

    // Delete inspector by Id
    public void Delete(Guid id)
    {
        var inspector = _inspectors.FirstOrDefault(i => i.Id == id);
        if (inspector != null)
        {
            _inspectors.Remove(inspector);
        }
    }

    // Get inspector by Id
    public Inspector? GetById(Guid id)
    {
        return _inspectors.FirstOrDefault(i => i.Id == id);
    }

    // Get inspector by Identification
    public Inspector? GetByIdentification(string identification)
    {
        return _inspectors.FirstOrDefault(i => i.Identification == identification);
    }

    // Get all inspectors
    public List<Inspector> GetAll()
    {
        return _inspectors.ToList();
    }

    // Get inspectors by InspectionType
    public List<Inspector> GetByInspectionType(InspectionType inspectionType)
    {
        return _inspectors.Where(i => i.InspectionType == inspectionType).ToList();
    }
}
