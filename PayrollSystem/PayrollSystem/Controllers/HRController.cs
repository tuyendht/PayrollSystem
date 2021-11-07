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
    [Route("api/hraccounts")]
    [ApiController]
/*    [Authorize]*/
    public class HRController : ControllerBase
    {
        private IHraccountRepository hRRepository;
        private IManagePayrollRepository managePayrollRepository;
        private readonly PayrollSystemContext _payRollDBCotext;
        public HRController(PayrollSystemContext payRollDBCotext)
        {
            this.hRRepository = new HraccountRepository(new PayrollSystemContext());
            this.managePayrollRepository = new ManagePayrollRepository(new PayrollSystemContext());
            _payRollDBCotext = payRollDBCotext;
        }

        [HttpGet(template: "get")]
        public IEnumerable<Hraccount> Get(string name, int page, int pagesize)
        {
            if (name == null) name = "";
            IEnumerable<Hraccount> hraccounts = hRRepository.GetHraccounts().Skip(page * pagesize).Take(pagesize)
            .Where(s => s.Fullname.Contains(name, StringComparison.OrdinalIgnoreCase));
            if (hraccounts != null)
            {
                return hraccounts;
            }
            return null;
        }

        [HttpGet(template: "find/{id}")]
        public Hraccount Get(int id)
        {
            Hraccount hraccount = hRRepository.GetHraccountByID(id);
            if (hraccount != null)
            {
                return hraccount;
            }
            return null;
        }

        [HttpGet(template: "getCompanyIdByHREmail/{email}")]

        public IEnumerable<int> Get(String email)
        {
            IEnumerable<Hraccount> hraccounts = hRRepository.GetHraccounts();
            Hraccount findHR = null;
            foreach (Hraccount hraccount in hraccounts)
            {
                if (hraccount.EmailAddress.Equals(email))
                {
                    findHR = hraccount;
                }
            }
            if (findHR != null)
            {
                IEnumerable<int> companyID = managePayrollRepository.GetManagePayrolls()
                .Where(s => s.HrId.Equals(findHR.Id)).Select(s=>s.CompanyId);
                return companyID;
            }
            return null;
            /*return _payRollDBCotext.Companies.SingleOrDefault(x => x.Id == id);*/
        }

        [HttpPost(template: "add")]
        public String Post([FromBody] Hraccount hraccount)
        {
            hRRepository.InsertHraccount(hraccount);
            hRRepository.Save();
            return "Add Success";
        }

        // PUT api/<HraccountController>/5
        [HttpPut(template: "update")]
        public String Put([FromBody] Hraccount hraccount)
        {
            try
            {
                hRRepository.UpdateHraccount(hraccount);
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
            try
            {
                Hraccount findHraccount = hRRepository.GetHraccountByID(id);
                if (findHraccount != null)
                {
                    hRRepository.DeleteHraccount(id);
                    hRRepository.Save();
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
