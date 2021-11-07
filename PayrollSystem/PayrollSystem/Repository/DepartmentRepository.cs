using PayrollSystem.IRepository;
using PayrollSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollSystem.Repository
{
    public class DepartmentRepository:IDepartmentRepository, IDisposable
    {
        private PayrollSystemContext context;
        public DepartmentRepository(PayrollSystemContext context)
        {
            this.context = context;
        }

        public void DeleteDepartment(int Id)
        {
            Department department = context.Departments.Find(Id);
            context.Departments.Remove(department);
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

        public IEnumerable<Department> GetDepartments()
        {
            return context.Departments.ToList();
        }

        public Department GetDepartmentByID(int Id)
        {
            return context.Departments.Find(Id);
        }

        public void InsertDepartment(Department department)
        {
            context.Departments.Add(department);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateDepartment(Department department)
        {
            /*context.Entry(company).State = EntityState.Modified.;*/
            context.Departments.Update(department);
            context.SaveChanges();
        }
    }
}
