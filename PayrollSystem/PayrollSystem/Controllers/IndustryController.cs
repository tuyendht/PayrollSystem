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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PayrollSystem.Controllers
{
    [Route("api/industries")]
    [ApiController]
/*    [Authorize]*/
    public class IndustryController : ControllerBase
    {
        private IIndustryRepository industryRepository;
        private readonly PayrollSystemContext _payRollDBCotext;
        public IndustryController(PayrollSystemContext payRollDBCotext)
        {
            this.industryRepository = new IndustryRepository(new PayrollSystemContext());
            _payRollDBCotext = payRollDBCotext;
        }
        [HttpGet(template: "get")]
        public IEnumerable<Industry> Get(string name, int page, int pagesize)
        {
            if (name == null) name = "";
            IEnumerable<Industry> departments = industryRepository.GetIndustries().Skip(page * pagesize).Take(pagesize)
            .Where(s => s.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
            return departments;
        }
        [HttpGet(template: "find/{id}")]
        public Industry Get(int id)
        {
            Industry department = industryRepository.GetIndustryByID(id);
            return department;
            /*return _payRollDBCotext.Companies.SingleOrDefault(x => x.Id == id);*/
        }

        // POST api/<CompanyController>
        [HttpPost(template: "add")]
        public void Post([FromBody] Industry department)
        {
            industryRepository.InsertIndustry(department);
            industryRepository.Save();
            /*_payRollDBCotext.Companies.Add(company);
            _payRollDBCotext.SaveChanges();*/
        }

        // PUT api/<CompanyController>/5
        [HttpPut(template: "update")]
        public HttpStatusCode Put([FromBody] Industry department)
        {
            try
            {
                industryRepository.UpdateIndustry(department);
            }
            catch (DataException)
            {
                return HttpStatusCode.NotModified;
            }
            return HttpStatusCode.OK;
        }

        // DELETE api/<CompanyController>/5
        [HttpDelete(template: "delete/{id}")]
        public void Delete(int id)
        {
            Industry findIndustry = industryRepository.GetIndustryByID(id);

            /*var item = _payRollDBCotext.Companies.FirstOrDefault(x => x.Id == id);*/
            if (findIndustry != null)
            {
                industryRepository.DeleteIndustry(id);
                industryRepository.Save();
                /*_payRollDBCotext.Companies.Remove(item);
                _payRollDBCotext.SaveChanges();*/
            }
        }
    }
}
