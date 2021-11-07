using PayrollSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollSystem.IRepository
{
    public interface IPaySlipDetailRepository : IDisposable
    {
        IEnumerable<PaySlipDetail> GetPaySlipDetails();
        PaySlipDetail GetPaySlipDetailByID(int Id);
        void InsertPaySlipDetail(PaySlipDetail paySlipDetail);
        void DeletePaySlipDetail(int id);
        void UpdatePaySlipDetail(PaySlipDetail paySlipDetail);
        void Save();
    }
}
