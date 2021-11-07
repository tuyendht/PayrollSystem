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
    [Route("api/paystatuses")]
    [ApiController]
    public class PayStatusController : ControllerBase
    {
        private IPayStatusRepository payStatusRepository;
        private readonly PayrollSystemContext _payRollDBCotext;
        public PayStatusController(PayrollSystemContext payRollDBCotext)
        {
            this.payStatusRepository = new PayStatusRepository(new PayrollSystemContext());
            _payRollDBCotext = payRollDBCotext;
        }
        [HttpGet(template: "get")]
        public IEnumerable<PayStatus> Get(string name, int page, int pagesize)
        {
            if (name == null) name = "";
                IEnumerable<PayStatus> payStatuses = payStatusRepository.GetPayStatuses().Skip(page * pagesize).Take(pagesize);
                if (payStatuses != null)
                {
                    return payStatuses;
                }
            return null;
        }
        [HttpGet(template: "find/{id}")]
        public PayStatus Get(int id)
        {
            PayStatus payStatus = payStatusRepository.GetPayStatusByID(id);
            return payStatus;
            /*return _payRollDBCotext.Companies.SingleOrDefault(x => x.Id == id);*/
        }

        // POST api/<CompanyController>
        [HttpPost(template: "add")]
        public void Post([FromBody] PayStatus payStatus)
        {
            payStatusRepository.InsertPayStatus(payStatus);
            payStatusRepository.Save();
            /*_payRollDBCotext.Companies.Add(company);
            _payRollDBCotext.SaveChanges();*/
        }

        // PUT api/<CompanyController>/5
        [HttpPut(template: "update")]
        public HttpStatusCode Put([FromBody] PayStatus payStatus)
        {
            try
            {
                payStatusRepository.UpdatePayStatus(payStatus);
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
            PayStatus findPayStatus = payStatusRepository.GetPayStatusByID(id);

            /*var item = _payRollDBCotext.Companies.FirstOrDefault(x => x.Id == id);*/
            if (findPayStatus != null)
            {
                payStatusRepository.DeletePayStatus(id);
                payStatusRepository.Save();
                /*_payRollDBCotext.Companies.Remove(item);
                _payRollDBCotext.SaveChanges();*/
            }
        }
    }
}
