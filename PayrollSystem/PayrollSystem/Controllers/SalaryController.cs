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
    [Route("api/salaries")]
    [ApiController]
    public class SalaryController : ControllerBase
    {
        private ISalaryRepository paySlipRepository;
        private readonly PayrollSystemContext _payRollDBCotext;
        public SalaryController(PayrollSystemContext payRollDBCotext)
        {
            this.paySlipRepository = new SalaryRepository(new PayrollSystemContext());
            _payRollDBCotext = payRollDBCotext;
        }
        [HttpGet(template: "get")]
        public IEnumerable<Salary> Get(string type, int page, int pagesize)
        {
            if (type == null) type = "";
            IEnumerable<Salary> paySlip = paySlipRepository.GetSalaries().Skip(page * pagesize).Take(pagesize)
            .Where(s => s.Type.Contains(type, StringComparison.OrdinalIgnoreCase));
            if (paySlip != null)
            {
                return paySlip;
            }
            return null;
        }
        [HttpGet(template: "find/{id}")]
        public Salary Get(int id)
        {
            Salary paySlip = paySlipRepository.GetSalaryByID(id);
            return paySlip;
        }

        // POST api/<CompanyController>
        [HttpPost(template: "add")]
        public void Post([FromBody] Salary paySlip)
        {
            paySlipRepository.InsertSalary(paySlip);
            paySlipRepository.Save();
        }

        // PUT api/<CompanyController>/5
        [HttpPut(template: "update")]
        public HttpStatusCode Put([FromBody] Salary paySlip)
        {
            try
            {
                paySlipRepository.UpdateSalary(paySlip);
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
            Salary findSalary = paySlipRepository.GetSalaryByID(id);

            var item = _payRollDBCotext.Companies.FirstOrDefault(x => x.Id == id);
            if (findSalary != null)
            {
                paySlipRepository.DeleteSalary(id);
                paySlipRepository.Save();
                _payRollDBCotext.Companies.Remove(item);
                _payRollDBCotext.SaveChanges();
            }
        }
    }
}
