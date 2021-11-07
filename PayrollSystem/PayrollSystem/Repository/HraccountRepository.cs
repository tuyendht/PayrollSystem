using PayrollSystem.IRepository;
using PayrollSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollSystem.Repository
{
    public class HraccountRepository:IHraccountRepository, IDisposable
    {
        private PayrollSystemContext context;
        public HraccountRepository(PayrollSystemContext context)
        {
            this.context = context;
        }

        public void DeleteHraccount(int Id)
        {
            Hraccount hraccount = context.Hraccounts.Find(Id);
            context.Hraccounts.Remove(hraccount);
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

        public IEnumerable<Hraccount> GetHraccounts()
        {
            return context.Hraccounts.ToList();
        }

        public Hraccount GetHraccountByID(int Id)
        {
            return context.Hraccounts.Find(Id);
        }

        public void InsertHraccount(Hraccount Hraccount)
        {
            context.Hraccounts.Add(Hraccount);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateHraccount(Hraccount Hraccount)
        {
            /*context.Entry(Hraccount).State = EntityState.Modified.;*/
            context.Hraccounts.Update(Hraccount);
            context.SaveChanges();
        }
    }
}
