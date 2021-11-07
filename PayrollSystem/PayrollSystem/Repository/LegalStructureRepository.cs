using PayrollSystem.IRepository;
using PayrollSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollSystem.Repository
{
    public class LegalStructureRepository : ILegalStructureRepository, IDisposable
    {
        private PayrollSystemContext context;
        public LegalStructureRepository(PayrollSystemContext context)
        {
            this.context = context;
        }

        public void DeleteLegalStructure(int Id)
        {
            LegalStructure legalStructure = context.LegalStructures.Find(Id);
            context.LegalStructures.Remove(legalStructure);
        }
        private bool disposed = false;
        private PayrollSystemContext payrollSystemContext;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<LegalStructure> GetLegalStructures()
        {
            return context.LegalStructures.ToList();
        }

        public LegalStructure GetLegalStructureByID(int Id)
        {
            return context.LegalStructures.Find(Id);
        }

        public void InsertLegalStructure(LegalStructure legalStructure)
        {
            context.LegalStructures.Add(legalStructure);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateLegalStructure(LegalStructure legalStructure)
        {
            /*context.Entry(legalStructure).State = EntityState.Modified.;*/
            context.LegalStructures.Update(legalStructure);
            context.SaveChanges();
        }
    }
}
