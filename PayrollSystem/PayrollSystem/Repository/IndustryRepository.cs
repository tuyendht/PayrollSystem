using PayrollSystem.IRepository;
using PayrollSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollSystem.Repository
{
    public class IndustryRepository : IIndustryRepository, IDisposable
    {
        private PayrollSystemContext context;
        public IndustryRepository(PayrollSystemContext context)
        {
            this.context = context;
        }

        public void DeleteIndustry(int Id)
        {
            Industry industry = context.Industries.Find(Id);
            context.Industries.Remove(industry);
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

        public IEnumerable<Industry> GetIndustries()
        {
            return context.Industries.ToList();
        }

        public Industry GetIndustryByID(int Id)
        {
            return context.Industries.Find(Id);
        }

        public void InsertIndustry(Industry industry)
        {
            context.Industries.Add(industry);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateIndustry(Industry industry)
        {
            /*context.Entry(industry).State = EntityState.Modified.;*/
            context.Industries.Update(industry);
            context.SaveChanges();
        }
    }
}
