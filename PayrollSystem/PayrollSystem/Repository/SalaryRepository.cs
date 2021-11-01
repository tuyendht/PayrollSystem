using PayrollSystem.IRepository;
using PayrollSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollSystem.Repository
{
    public class SalaryRepository : ISalaryRepository, IDisposable
    {
        private PayrollSystemContext context;
        public SalaryRepository(PayrollSystemContext context)
        {
            this.context = context;
        }

        public void DeleteSalary(int Id)
        {
            Salary salary = context.Salaries.Find(Id);
            context.Salaries.Remove(salary);
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

        public IEnumerable<Salary> GetSalaries()
        {
            return context.Salaries.ToList();
        }

        public Salary GetSalaryByID(int Id)
        {
            return context.Salaries.Find(Id);
        }

        public void InsertSalary(Salary salary)
        {
            context.Salaries.Add(salary);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateSalary(Salary salary)
        {
            /*context.Entry(salary).State = EntityState.Modified.;*/
            context.Salaries.Update(salary);
            context.SaveChanges();
        }
    }
}
