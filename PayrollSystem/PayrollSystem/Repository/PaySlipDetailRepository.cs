using PayrollSystem.IRepository;
using PayrollSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollSystem.Repository
{
    public class PaySlipDetailRepository : IPaySlipDetailRepository, IDisposable
    {
        private PayrollSystemContext context;
        public PaySlipDetailRepository(PayrollSystemContext context)
        {
            this.context = context;
        }

        public void DeletePaySlipDetail(int Id)
        {
            PaySlipDetail PaySlipDetail = context.PaySlipDetails.Find(Id);
            context.PaySlipDetails.Remove(PaySlipDetail);
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

        public IEnumerable<PaySlipDetail> GetPaySlipDetails()
        {
            return context.PaySlipDetails.ToList();
        }

        public PaySlipDetail GetPaySlipDetailByID(int Id)
        {
            return context.PaySlipDetails.Find(Id);
        }

        public void InsertPaySlipDetail(PaySlipDetail PaySlipDetail)
        {
            context.PaySlipDetails.Add(PaySlipDetail);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdatePaySlipDetail(PaySlipDetail PaySlipDetail)
        {
            /*context.Entry(PaySlipDetail).State = EntityState.Modified.;*/
            context.PaySlipDetails.Update(PaySlipDetail);
            context.SaveChanges();
        }
    }
}
