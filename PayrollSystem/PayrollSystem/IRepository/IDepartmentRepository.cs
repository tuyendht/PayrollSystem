using PayrollSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollSystem.IRepository
{
    public interface IDepartmentRepository: IDisposable
    {
        IEnumerable<Department> GetDepartments();
        Department GetDepartmentByID(int Id);
        void InsertDepartment(Department department);
        void DeleteDepartment(int id);
        void UpdateDepartment(Department department);
        void Save();
    }
}
