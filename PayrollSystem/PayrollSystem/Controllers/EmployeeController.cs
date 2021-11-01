using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PayrollSystem.IRepository;
using PayrollSystem.Models;
using PayrollSystem.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PayrollSystem.Controllers
{
    [Route("api/employees")]
    [ApiController]
/*    [Authorize]*/
    public class EmployeeController : ControllerBase
    {
        private IEmployeeRepository employeeRepository;
        private ICompanyRepository companyRepository;
        private IDepartmentRepository departmentRepository;
        private readonly PayrollSystemContext _payRollDBCotext;
        public EmployeeController(PayrollSystemContext payRollDBCotext)
        {
            this.employeeRepository = new EmployeeRepository(new PayrollSystemContext());
            this.companyRepository = new CompanyRepository(new PayrollSystemContext());
            this.departmentRepository = new DepartmentRepository(new PayrollSystemContext());
            _payRollDBCotext = payRollDBCotext;
        }
        [HttpGet(template: "get")]

        public IEnumerable<Employee> Get(string name, int companyID,int departmentID, int page, int pagesize)
        {
            if (name == null) name = "";
            if (companyID == 0 && departmentID == 0)
            {
                IEnumerable<Employee> employees = employeeRepository.GetEmployees().Skip(page * pagesize).Take(pagesize)
                .Where(s => s.Fullname.Contains(name, StringComparison.OrdinalIgnoreCase));
                if(employees != null) {
                    foreach (Employee employee in employees)
                    {
                        employee.Company = companyRepository.GetCompanyByID(employee.CompanyId);
                        employee.Department = departmentRepository.GetDepartmentByID(employee.DepartmentId);
                    }
                    return employees;
                }
                
            }
            else if (companyID != 0 && departmentID == 0)
            {
                IEnumerable<Employee> employees = employeeRepository.GetEmployees().Skip(page * pagesize).Take(pagesize)
                .Where(s => s.Fullname.Contains(name, StringComparison.OrdinalIgnoreCase))
                .Where(s => s.CompanyId.Equals(companyID));
                if (employees != null)
                {
                    foreach (Employee employee in employees)
                    {
                        employee.Company = companyRepository.GetCompanyByID(employee.CompanyId);
                        employee.Department = departmentRepository.GetDepartmentByID(employee.DepartmentId);
                    }
                    return employees;
                }
            }
            else if (departmentID != 0 && companyID == 0)
            {
                IEnumerable<Employee> employees = employeeRepository.GetEmployees().Skip(page * pagesize).Take(pagesize)
                .Where(s => s.Fullname.Contains(name, StringComparison.OrdinalIgnoreCase))
                .Where(s => s.DepartmentId.Equals(departmentID));
                if (employees != null)
                {
                    foreach (Employee employee in employees)
                    {
                        employee.Company = companyRepository.GetCompanyByID(employee.CompanyId);
                        employee.Department = departmentRepository.GetDepartmentByID(employee.DepartmentId);
                    }
                    return employees;
                }
            }
            else
            {
                IEnumerable<Employee> employees = employeeRepository.GetEmployees().Skip(page * pagesize).Take(pagesize)
                .Where(s => s.Fullname.Contains(name, StringComparison.OrdinalIgnoreCase))
                .Where(s => s.DepartmentId.Equals(departmentID))
                .Where(s => s.CompanyId.Equals(companyID));
                if (employees != null)
                {
                    foreach (Employee employee in employees)
                    {
                        employee.Company = companyRepository.GetCompanyByID(employee.CompanyId);
                        employee.Department = departmentRepository.GetDepartmentByID(employee.DepartmentId);
                    }
                    return employees;
                }
            }
            return null;
        }
        [HttpGet(template:"find/{id}")]

        public Employee Get(int id)
        {
            Employee employee = employeeRepository.GetEmployeeByID(id);
            if(employee != null)
            {
                employee.Company = companyRepository.GetCompanyByID(employee.CompanyId);
                employee.Department = departmentRepository.GetDepartmentByID(employee.DepartmentId);
                return employee;
            }
            return null;
            /*return _payRollDBCotext.Companies.SingleOrDefault(x => x.Id == id);*/
        }

        [HttpGet(template: "getCompanyIdByEmpEmail/{email}")]

        public String Get(String email)
        {
            IEnumerable<Employee> employees = employeeRepository.GetEmployees();
            Employee findEmp = null;
            foreach(Employee employee in employees){
                if (employee.WorkEmailAddress.Equals(email))
                {
                    findEmp = employee;
                }
            }
            if (findEmp != null)
            {
                return findEmp.CompanyId.ToString();
            }
            return "Not Found";
            /*return _payRollDBCotext.Companies.SingleOrDefault(x => x.Id == id);*/
        }

        [HttpGet(template: "findByEmail/{email}")]

        public Employee GetEmp(String email)
        {
            IEnumerable<Employee> employees = employeeRepository.GetEmployees();
            Employee findEmp = null;
            foreach (Employee employee in employees)
            {
                if (employee.WorkEmailAddress.Equals(email))
                {
                    findEmp = employee;
                    findEmp.Company = companyRepository.GetCompanyByID(findEmp.CompanyId);
                    findEmp.Department = departmentRepository.GetDepartmentByID(findEmp.DepartmentId);
                }
            }
            if (findEmp != null)
            {
                return findEmp;
            }
            return null;
            /*return _payRollDBCotext.Companies.SingleOrDefault(x => x.Id == id);*/
        }

        // POST api/<CompanyController>
        [HttpPost(template:"add")]
        public String Post([FromBody] Employee employee)
        {
            try
            {
                employeeRepository.InsertEmployee(employee);
                employeeRepository.Save();
            }
            catch (Exception)
            {
                return "Add Failed";
            }
            return "Add Success";
        }

        // PUT api/<CompanyController>/5
        [HttpPut(template:"update")]
        public String Put([FromBody] Employee employee)
        {
            try
            {
                employeeRepository.UpdateEmployee(employee);
            }
            catch (DataException)
            {
                return "Update Failed";
            }
            return "Update Success";
        }

        // DELETE api/<CompanyController>/5
        [HttpDelete(template:"delete/{id}")]
        public String Delete(int id)
        {
            try
            {
                Employee findEmployee = employeeRepository.GetEmployeeByID(id);
                if (findEmployee != null)
                {
                    employeeRepository.DeleteEmployee(id);
                    employeeRepository.Save();
                    return "Delete Success";
                }
            }
            catch (Exception)
            {
                return "Delete Failed";
            }
            return "Delete Failed";
        }

        public class ResponseResult
        {
            public object ResultValue { get; set; }
            public bool NoData { get; set; }
            public string Message { get; set; }
            public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        }
    }
}
