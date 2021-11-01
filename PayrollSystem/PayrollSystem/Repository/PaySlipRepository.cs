using PayrollSystem.IRepository;
using PayrollSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollSystem.Repository
{
    public class PaySlipRepository : IPaySlipRepository, IDisposable
    {
        private PayrollSystemContext context;
        public PaySlipRepository(PayrollSystemContext context)
        {
            this.context = context;
        }

        public void DeletePaySlip(int Id)
        {
            PaySlip paySlip = context.PaySlips.Find(Id);
            context.PaySlips.Remove(paySlip);
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

        public IEnumerable<PaySlip> GetPaySlips()
        {
            return context.PaySlips.ToList();
        }

        public PaySlip GetPaySlipByID(int Id)
        {
            return context.PaySlips.Find(Id);
        }

        public void InsertPaySlip(PaySlip paySlip)
        {
            context.PaySlips.Add(paySlip);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdatePaySlip(PaySlip paySlip)
        {
            /*context.Entry(paySlip).State = EntityState.Modified.;*/
            context.PaySlips.Update(paySlip);
            context.SaveChanges();
        }
    }
}
