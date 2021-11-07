using PayrollSystem.IRepository;
using PayrollSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollSystem.Repository
{
    public class EmployeeRepository : IEmployeeRepository, IDisposable
    {
        private PayrollSystemContext context;
        public EmployeeRepository(PayrollSystemContext context)
        {
            this.context = context;
        }
        public void DeleteEmployee(int Id)
        {
            Employee employee = context.Employees.Find(Id);
            context.Employees.Remove(employee);
        }
        private bool disposed = false;
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

        public IEnumerable<Employee> GetEmployees()
        {
            return context.Employees.ToList();
        }

        public Employee GetEmployeeByID(int Id)
        {
            return context.Employees.Find(Id);
        }

        public void InsertEmployee(Employee employee)
        {
            context.Employees.Add(employee);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateEmployee(Employee employee)
        {
            context.Employees.Update(employee);
            context.SaveChanges();
        }
    }
}
