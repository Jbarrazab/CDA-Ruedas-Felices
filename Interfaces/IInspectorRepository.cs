using RuedasFelices.Models;

namespace RuedasFelices.Interfaces;

public interface IInspectorRepository
{
    // Add a new inspector
    void Add(Inspector inspector);

    // Update inspector data
    void Update(Inspector inspector);

    // Delete inspector by Id
    void Delete(Guid id);

    // Get inspector by Id
    Inspector? GetById(Guid id);

    // Get inspector by Identification
    Inspector? GetByIdentification(string identification);

    // Get all inspectors
    List<Inspector> GetAll();

    // Get inspectors by inspection type
    List<Inspector> GetByInspectionType(InspectionType inspectionType);
}
