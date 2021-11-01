using PayrollSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollSystem.IRepository
{
    public interface IPaySlipRepository : IDisposable
    {
        IEnumerable<PaySlip> GetPaySlips();
        PaySlip GetPaySlipByID(int Id);
        void InsertPaySlip(PaySlip paySlip);
        void DeletePaySlip(int id);
        void UpdatePaySlip(PaySlip paySlip);
        void Save();
    }
}
