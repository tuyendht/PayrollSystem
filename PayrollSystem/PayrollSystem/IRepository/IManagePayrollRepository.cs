using PayrollSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollSystem.IRepository
{
    public interface IManagePayrollRepository : IDisposable
    {
        IEnumerable<ManagePayroll> GetManagePayrolls();
        ManagePayroll GetManagePayrollByID(int Id);
        void InsertManagePayroll(ManagePayroll managePayroll);
        void DeleteManagePayroll(int id);
        void UpdateManagePayroll(ManagePayroll managePayroll);
        void Save();
    }
}
