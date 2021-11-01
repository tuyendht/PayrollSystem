using PayrollSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollSystem.IRepository
{
    public interface IPayStatusRepository : IDisposable
    {
        IEnumerable<PayStatus> GetPayStatuses();
        PayStatus GetPayStatusByID(int Id);
        void InsertPayStatus(PayStatus payStatus);
        void DeletePayStatus(int id);
        void UpdatePayStatus(PayStatus payStatus);
        void Save();
    }
}
