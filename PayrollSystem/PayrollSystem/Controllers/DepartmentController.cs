using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PayrollSystem.IRepository;
using PayrollSystem.Models;
using PayrollSystem.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using static PayrollSystem.Controllers.EmployeeController;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PayrollSystem.Controllers
{
    [Route("api/departments")]
    [ApiController]
/*    [Authorize]*/
    public class DepartmentController : ControllerBase
    {
        private IDepartmentRepository departmentRepository;
        private readonly PayrollSystemContext _payRollDBCotext;
        public DepartmentController(PayrollSystemContext payRollDBCotext)
        {
            this.departmentRepository = new DepartmentRepository(new PayrollSystemContext());
            _payRollDBCotext = payRollDBCotext;
        }
        [HttpGet(template: "get")]
        public IEnumerable<Department> Get(string name, int page, int pagesize)
        {
            if (name == null) name = "";
            IEnumerable<Department> departments = departmentRepository.GetDepartments().Skip(page * pagesize).Take(pagesize)
                .Where(s => s.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
            if (departments != null)
            {
                return departments;
            }
            return null;
        }

        [HttpGet(template: "find/{id}")]
        public Department Get(int id)
        {
            Department department = departmentRepository.GetDepartmentByID(id);
            if (department != null)
            {
                return department;
            }
            return null;
        }

        [HttpPost(template: "add")]
        public String Post([FromBody] Department company)
        {
            try
            {
                departmentRepository.InsertDepartment(company);
                departmentRepository.Save();
            }
            catch (Exception)
            {
                return "Add Failed";
            }
            return "Add Success";
        }

        // PUT api/<DepartmentController>/5
        [HttpPut(template: "update")]
        public String Put([FromBody] Department company)
        {
            try
            {
                departmentRepository.UpdateDepartment(company);
            }
            catch (DataException)
            {
                return "Update Failed";
            }
            return "Update Success";
        }

        [HttpDelete(template: "delete/{id}")]
        public String Delete(int id)
        {
            Department findDepartment = departmentRepository.GetDepartmentByID(id);
            if (findDepartment != null)
            {
                departmentRepository.DeleteDepartment(id);
                departmentRepository.Save();
                return "Delete Success";
            }
            return "Delete Failed";

        }
    }
}
