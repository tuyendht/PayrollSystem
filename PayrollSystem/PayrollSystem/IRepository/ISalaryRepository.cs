using PayrollSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollSystem.IRepository
{
    public interface ISalaryRepository : IDisposable
    {
        IEnumerable<Salary> GetSalaries();
        Salary GetSalaryByID(int Id);
        void InsertSalary(Salary paySlip);
        void DeleteSalary(int id);
        void UpdateSalary(Salary paySlip);
        void Save();
    }
}
