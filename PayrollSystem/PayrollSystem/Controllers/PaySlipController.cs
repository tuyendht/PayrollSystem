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
    [Route("api/payslips")]
    [ApiController]
    public class PaySlipController : ControllerBase
    {
        private IPaySlipRepository paySlipRepository;
        private IEmployeeRepository employeeRepository;
        private IPayStatusRepository payStatusRepository;
        private IPaySlipDetailRepository paySlipDetailRepository;
        private readonly PayrollSystemContext _payRollDBCotext;
        public PaySlipController(PayrollSystemContext payRollDBCotext)
        {
            this.paySlipRepository = new PaySlipRepository(new PayrollSystemContext());
            this.employeeRepository = new EmployeeRepository(new PayrollSystemContext());
            this.payStatusRepository = new PayStatusRepository(new PayrollSystemContext());
            this.paySlipDetailRepository = new PaySlipDetailRepository(new PayrollSystemContext());
            _payRollDBCotext = payRollDBCotext;
        }
        [HttpGet(template: "get")]
        public IEnumerable<PaySlip> Get(string payDate, int status, int page, int pagesize)
        {
            if (payDate == null) payDate = "";
            if (status == 0)
            {
                IEnumerable<PaySlip> paySlips = paySlipRepository.GetPaySlips().Skip(page * pagesize).Take(pagesize)
                    .Where(s => s.PayDate.ToString().Contains(payDate, StringComparison.OrdinalIgnoreCase)).OrderByDescending(s => s.Id);
                if (paySlips != null)
                {
                    foreach (PaySlip paySlip in paySlips)
                    {
                        paySlip.Employee = employeeRepository.GetEmployeeByID((int)paySlip.EmployeeId);
                        paySlip.PayStatus = payStatusRepository.GetPayStatusByID(paySlip.PayStatusId);
                        paySlip.PaySlipDetail = paySlipDetailRepository.GetPaySlipDetailByID((int)paySlip.PaySlipDetailId);
                    }
                    return paySlips;
                }

            }          
            else
            {
                IEnumerable<PaySlip> paySlips = paySlipRepository.GetPaySlips().Skip(page * pagesize).Take(pagesize)
                .Where(s => s.PayStatus.Equals(status))
                .Where(s => s.PayDate.ToString().Contains(payDate, StringComparison.OrdinalIgnoreCase)).OrderByDescending(s => s.Id);
                if (paySlips != null)
                {
                    foreach (PaySlip paySlip in paySlips)
                    {
                        paySlip.Employee = employeeRepository.GetEmployeeByID((int)paySlip.EmployeeId);
                        paySlip.PayStatus = payStatusRepository.GetPayStatusByID(paySlip.PayStatusId);
                        paySlip.PaySlipDetail = paySlipDetailRepository.GetPaySlipDetailByID((int)paySlip.PaySlipDetailId);
                    }
                    return paySlips;
                }
            }
            return null;
        }
        [HttpGet(template: "findByEmpID/{id}")]
        public IEnumerable<PaySlip> GetByEmpID(int id)
        {
            IEnumerable<PaySlip> paySlips = paySlipRepository.GetPaySlips()
                .Where(s => s.EmployeeId.Equals(id)).OrderByDescending(s => s.Id);
            foreach (PaySlip paySlip in paySlips)
            {
                paySlip.Employee = employeeRepository.GetEmployeeByID((int)paySlip.EmployeeId);
                paySlip.PayStatus = payStatusRepository.GetPayStatusByID(paySlip.PayStatusId);
                paySlip.PaySlipDetail = paySlipDetailRepository.GetPaySlipDetailByID((int)paySlip.PaySlipDetailId);
            }
            return paySlips;
            /*return _payRollDBCotext.Companies.SingleOrDefault(x => x.Id == id);*/
        }

        [HttpGet(template: "find/{id}")]
        public PaySlip Get(int id)
        {
            PaySlip paySlip = paySlipRepository.GetPaySlipByID(id);
            if (paySlip != null)
            {
                paySlip.Employee = employeeRepository.GetEmployeeByID((int)paySlip.EmployeeId);
                paySlip.PayStatus = payStatusRepository.GetPayStatusByID(paySlip.PayStatusId);
                paySlip.PaySlipDetail = paySlipDetailRepository.GetPaySlipDetailByID((int)paySlip.PaySlipDetailId);
            }
            return paySlip;
            /*return _payRollDBCotext.Companies.SingleOrDefault(x => x.Id == id);*/
        }

        // POST api/<CompanyController>
        [HttpPost(template: "add")]
        public String Post([FromBody] PaySlip paySlip)
        {
            try
            {
                paySlipRepository.InsertPaySlip(paySlip);
                paySlipRepository.Save();
            }
            catch (Exception)
            {
                return "Add Failed";
            }
            return "Add Success";
        }

        // PUT api/<CompanyController>/5
        [HttpPut(template: "update")]
        public String Put([FromBody] PaySlip paySlip)
        {
            try
            {
                paySlipRepository.UpdatePaySlip(paySlip);
            }
            catch (DataException)
            {
                return "Update Failed";
            }
            return "Update Success";
        }

        // DELETE api/<CompanyController>/5
        [HttpDelete(template: "delete/{id}")]
        public String Delete(int id)
        {
            
            try
            {
                PaySlip findPaySlip = paySlipRepository.GetPaySlipByID(id);
                if (findPaySlip != null)
                {
                    paySlipRepository.DeletePaySlip(id);
                    paySlipRepository.Save();
                }
            }
            catch (Exception)
            {
                return "Delete Failed";
            }
            return "Delete Success";
        }
    }
}
