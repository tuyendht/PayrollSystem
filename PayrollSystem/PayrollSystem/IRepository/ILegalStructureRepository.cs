using PayrollSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollSystem.IRepository
{
    public interface ILegalStructureRepository : IDisposable
    {
        IEnumerable<LegalStructure> GetLegalStructures();
        LegalStructure GetLegalStructureByID(int Id);
        void InsertLegalStructure(LegalStructure legalStructure);
        void DeleteLegalStructure(int id);
        void UpdateLegalStructure(LegalStructure legalStructure);
        void Save();
    }
}
