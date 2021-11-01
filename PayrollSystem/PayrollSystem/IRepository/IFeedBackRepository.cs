using PayrollSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollSystem.IRepository
{
    public interface IFeedBackRepository : IDisposable
    {
        IEnumerable<FeedBack> GetFeedBacks();
        FeedBack GetFeedBackByID(int Id);
        void InsertFeedBack(FeedBack feedBack);
        void DeleteFeedBack(int id);
        void UpdateFeedBack(FeedBack feedBack);
        void Save();
    }
}
