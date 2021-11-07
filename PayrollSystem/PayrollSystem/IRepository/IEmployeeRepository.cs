using PayrollSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollSystem.IRepository
{
    public interface IEmployeeRepository:IDisposable
    {
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployeeByID(int Id);
        void InsertEmployee(Employee employee);
        void DeleteEmployee(int Id);
        void UpdateEmployee(Employee employee);
        void Save();
    }
}
