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
    [Route("api/managerpayrolls")]
    [ApiController]
/*    [Authorize]*/
    public class ManagePayrollController : ControllerBase
    {
        private IManagePayrollRepository managePayrollRepository;
        private readonly PayrollSystemContext _payRollDBCotext;
        public ManagePayrollController(PayrollSystemContext payRollDBCotext)
        {
            this.managePayrollRepository = new ManagePayrollRepository(new PayrollSystemContext());
            _payRollDBCotext = payRollDBCotext;
        }
        [HttpGet(template: "get")]
        public IEnumerable<ManagePayroll> Get(int hrID, int companyID, int page, int pagesize)
        {
            if (hrID == 0 && companyID == 0)
            {
                IEnumerable<ManagePayroll> managePayrolls = managePayrollRepository.GetManagePayrolls().Skip(page * pagesize).Take(pagesize);
                return managePayrolls;
            }
            else if (hrID != 0 && companyID == 0)
            {
                IEnumerable<ManagePayroll> managePayrolls = managePayrollRepository.GetManagePayrolls().Skip(page * pagesize).Take(pagesize)
                .Where(s => s.HrId.Equals(hrID));
                return managePayrolls;
            }
            else if (companyID != 0 && hrID == 0)
            {
                IEnumerable<ManagePayroll> managePayrolls = managePayrollRepository.GetManagePayrolls().Skip(page * pagesize).Take(pagesize)
                .Where(s => s.CompanyId.Equals(companyID));
                return managePayrolls;
            }
            else
            {
                IEnumerable<ManagePayroll> managePayrolls = managePayrollRepository.GetManagePayrolls().Skip(page * pagesize).Take(pagesize)
                .Where(s => s.HrId.Equals(hrID))
                .Where(s => s.CompanyId.Equals(companyID));
                return managePayrolls;
            }
        }
        [HttpGet(template: "find/{id}")]
        public ManagePayroll Get(int id)
        {
            ManagePayroll managePayroll = managePayrollRepository.GetManagePayrollByID(id);
            return managePayroll;
            /*return _payRollDBCotext.Companies.SingleOrDefault(x => x.Id == id);*/
        }

        // POST api/<ManagePayrollController>
        [HttpPost(template: "add")]
        public void Post([FromBody] ManagePayroll managePayroll)
        {
            managePayrollRepository.InsertManagePayroll(managePayroll);
            managePayrollRepository.Save();
            /*_payRollDBCotext.Companies.Add(company);
            _payRollDBCotext.SaveChanges();*/
        }

        // PUT api/<ManagePayrollController>/5
        [HttpPut(template: "update")]
        public HttpStatusCode Put([FromBody] ManagePayroll managePayroll)
        {
            try
            {
                managePayrollRepository.UpdateManagePayroll(managePayroll);
            }
            catch (DataException)
            {
                return HttpStatusCode.NotModified;
            }
            return HttpStatusCode.OK;
        }

        // DELETE api/<ManagePayrollController>/5
        [HttpDelete(template: "delete/{id}")]
        public void Delete(int id)
        {
            ManagePayroll findManagePayroll = managePayrollRepository.GetManagePayrollByID(id);

            /*var item = _payRollDBCotext.Companies.FirstOrDefault(x => x.Id == id);*/
            if (findManagePayroll != null)
            {
                managePayrollRepository.DeleteManagePayroll(id);
                managePayrollRepository.Save();
                /*_payRollDBCotext.Companies.Remove(item);
                _payRollDBCotext.SaveChanges();*/
            }
        }
    }
}
