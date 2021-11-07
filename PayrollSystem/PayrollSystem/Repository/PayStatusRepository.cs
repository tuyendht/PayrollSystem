using PayrollSystem.IRepository;
using PayrollSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollSystem.Repository
{
    public class PayStatusRepository : IPayStatusRepository, IDisposable
    {
        private PayrollSystemContext context;
        public PayStatusRepository(PayrollSystemContext context)
        {
            this.context = context;
        }

        public void DeletePayStatus(int Id)
        {
            PayStatus paySlip = context.PayStatuses.Find(Id);
            context.PayStatuses.Remove(paySlip);
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

        public IEnumerable<PayStatus> GetPayStatuses()
        {
            return context.PayStatuses.ToList();
        }

        public PayStatus GetPayStatusByID(int Id)
        {
            return context.PayStatuses.Find(Id);
        }

        public void InsertPayStatus(PayStatus paySlip)
        {
            context.PayStatuses.Add(paySlip);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdatePayStatus(PayStatus paySlip)
        {
            /*context.Entry(paySlip).State = EntityState.Modified.;*/
            context.PayStatuses.Update(paySlip);
            context.SaveChanges();
        }
    }
}
