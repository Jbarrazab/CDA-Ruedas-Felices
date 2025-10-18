using RuedasFelices.Models;

namespace RuedasFelices.Interfaces;

public interface IInspector
    {
        void Add(Inspector inspector);
        void Update(Inspector inspector);
        void Delete(Guid id);
        Inspector? GetById(Guid id);
        Inspector? GetByIdentification(string identification);
        List<Inspector> GetAll();
        List<Inspector> GetByInspectionType(InspectionType inspectionType);
    }

