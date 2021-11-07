using PayrollSystem.IRepository;
using PayrollSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollSystem.Repository
{
    public class PayScheduleTypeRepository : IPayScheduleTypeRepository, IDisposable
    {
        private PayrollSystemContext context;
        public PayScheduleTypeRepository(PayrollSystemContext context)
        {
            this.context = context;
        }

        public void DeletePayScheduleType(int Id)
        {
            PayScheduleType payScheduleType = context.PayScheduleTypes.Find(Id);
            context.PayScheduleTypes.Remove(payScheduleType);
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

        public IEnumerable<PayScheduleType> GetPayScheduleTypes()
        {
            return context.PayScheduleTypes.ToList();
        }

        public PayScheduleType GetPayScheduleTypeByID(int Id)
        {
            return context.PayScheduleTypes.Find(Id);
        }

        public void InsertPayScheduleType(PayScheduleType PayScheduleType)
        {
            context.PayScheduleTypes.Add(PayScheduleType);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdatePayScheduleType(PayScheduleType PayScheduleType)
        {
            /*context.Entry(PayScheduleType).State = EntityState.Modified.;*/
            context.PayScheduleTypes.Update(PayScheduleType);
            context.SaveChanges();
        }
    }
}
