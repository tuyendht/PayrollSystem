using PayrollSystem.IRepository;
using PayrollSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollSystem.Repository
{
    public class FeedBackRepository : IFeedBackRepository, IDisposable
    {
        private PayrollSystemContext context;
        public FeedBackRepository(PayrollSystemContext context)
        {
            this.context = context;
        }

        public void DeleteFeedBack(int Id)
        {
            FeedBack feedBack = context.FeedBacks.Find(Id);
            context.FeedBacks.Remove(feedBack);
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

        public IEnumerable<FeedBack> GetFeedBacks()
        {
            return context.FeedBacks.ToList();
        }

        public FeedBack GetFeedBackByID(int Id)
        {
            return context.FeedBacks.Find(Id);
        }

        public void InsertFeedBack(FeedBack feedBack)
        {
            context.FeedBacks.Add(feedBack);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateFeedBack(FeedBack feedBack)
        {
            /*context.Entry(feedBack).State = EntityState.Modified.;*/
            context.FeedBacks.Update(feedBack);
            context.SaveChanges();
        }
    }
}
