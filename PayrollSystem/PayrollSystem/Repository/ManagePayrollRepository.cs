using PayrollSystem.IRepository;
using PayrollSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollSystem.Repository
{
    public class ManagePayrollRepository : IManagePayrollRepository, IDisposable
    {
        private PayrollSystemContext context;
        public ManagePayrollRepository(PayrollSystemContext context)
        {
            this.context = context;
        }

        public void DeleteManagePayroll(int Id)
        {
            ManagePayroll managePayroll = context.ManagePayrolls.Find(Id);
            context.ManagePayrolls.Remove(managePayroll);
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

        public IEnumerable<ManagePayroll> GetManagePayrolls()
        {
            return context.ManagePayrolls.ToList();
        }

        public ManagePayroll GetManagePayrollByID(int Id)
        {
            return context.ManagePayrolls.Find(Id);
        }

        public void InsertManagePayroll(ManagePayroll managePayroll)
        {
            context.ManagePayrolls.Add(managePayroll);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateManagePayroll(ManagePayroll managePayroll)
        {
            /*context.Entry(managePayroll).State = EntityState.Modified.;*/
            context.ManagePayrolls.Update(managePayroll);
            context.SaveChanges();
        }
    }
}
