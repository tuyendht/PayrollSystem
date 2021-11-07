using PayrollSystem.IRepository;
using PayrollSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollSystem.Repository
{
    public class PayScheduleRepository:IDisposable, IPayScheduleRepository
    {
        private PayrollSystemContext context;
        public PayScheduleRepository(PayrollSystemContext context)
        {
            this.context = context;
        }

        public void DeletePaySchedule(int Id)
        {
            PaySchedule paySchedule = context.PaySchedules.Find(Id);
            context.PaySchedules.Remove(paySchedule);
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

        public IEnumerable<PaySchedule> GetPaySchedules()
        {
            return context.PaySchedules.ToList();
        }

        public PaySchedule GetPayScheduleByID(int Id)
        {
            return context.PaySchedules.Find(Id);
        }

        public void InsertPaySchedule(PaySchedule paySchedule)
        {
            context.PaySchedules.Add(paySchedule);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdatePaySchedule(PaySchedule paySchedule)
        {
            /*context.Entry(paySchedule).State = EntityState.Modified.;*/
            context.PaySchedules.Update(paySchedule);
            context.SaveChanges();
        }
    }
}
