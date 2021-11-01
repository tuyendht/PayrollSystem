using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PayrollSystem.IRepository;
using PayrollSystem.Models;
using PayrollSystem.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using static PayrollSystem.Controllers.EmployeeController;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PayrollSystem.Controllers
{
    [Route("api/companies")]
    [ApiController]
/*    [Authorize]*/
    public class CompanyController : ControllerBase
    {
        private ICompanyRepository companyRepository;
        private readonly PayrollSystemContext _payRollDBCotext;
        public CompanyController(PayrollSystemContext payRollDBCotext)
        {
            this.companyRepository = new CompanyRepository(new PayrollSystemContext());
            _payRollDBCotext = payRollDBCotext;
        }
        [HttpGet(template: "get")]
        public IEnumerable<Company> Get(string name, int page, int pagesize)
        {
            if (name == null) name = "";
            IEnumerable<Company> companies = companyRepository.GetCompanies().Skip(page * pagesize).Take(pagesize)
                .Where(s => s.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
            if (companies != null)
            {
                return companies;
            }
            return null;
        }

        [HttpGet(template: "find/{id}")]
        public Company Get(int id)
        {
            Company company = companyRepository.GetCompanyByID(id);
            if (company != null)
            {
                return company;
            }
            return null;
        }

        [HttpPost(template:"add")]
        public String Post([FromBody] Company company)
        {
            companyRepository.InsertCompany(company);
            companyRepository.Save();
            return "Add Success";
        }

        // PUT api/<CompanyController>/5
        [HttpPut(template: "update")]
        public String Put([FromBody] Company company)
        {
            try
            {
                companyRepository.UpdateCompany(company);
            }
            catch (DataException)
            {
                return "Update Failed";
            }
            return "Update Success";
        }

        [HttpDelete(template:"delete/{id}")]
        public String Delete(int id)
        {
            try
            {
                Company findCompany = companyRepository.GetCompanyByID(id);
                if (findCompany != null)
                {
                    companyRepository.DeleteCompany(id);
                    companyRepository.Save();
                    return "Delete Success";
                }
                return "Delete Failed";
            }
            catch (Exception e)
            {
                return "Delete Failed";
            }
        }
    }
}
