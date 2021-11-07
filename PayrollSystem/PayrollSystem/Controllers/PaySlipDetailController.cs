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
    [Route("api/payslipdetails")]
    [ApiController]
    public class PaySlipDetailController : ControllerBase
    {
        private IPaySlipDetailRepository paySlipDetailRepository;
        private IEmployeeRepository employeeRepository;
        private IPaySlipRepository paySlipRepository;
        private readonly PayrollSystemContext _payRollDBCotext;
        public PaySlipDetailController(PayrollSystemContext payRollDBCotext)
        {
            this.paySlipDetailRepository = new PaySlipDetailRepository(new PayrollSystemContext());
            this.employeeRepository = new EmployeeRepository(new PayrollSystemContext());
            this.paySlipRepository = new PaySlipRepository(new PayrollSystemContext());
            _payRollDBCotext = payRollDBCotext;
        }
        [HttpGet(template: "get")]
        public IEnumerable<PaySlipDetail> Get(int employeeID, int page, int pagesize)
        {
            if (employeeID == 0)
            {
                IEnumerable<PaySlipDetail> paySlipDetails = paySlipDetailRepository.GetPaySlipDetails().Skip(page * pagesize).Take(pagesize);
                if (paySlipDetails != null)
                {
                    foreach (PaySlipDetail paySlipDetail in paySlipDetails)
                    {
                        paySlipDetail.Employee = employeeRepository.GetEmployeeByID(paySlipDetail.EmployeeId);
                    }
                    return paySlipDetails;
                }

            }
            else if (employeeID != 0)
            {
                IEnumerable<PaySlipDetail> paySlipDetails = paySlipDetailRepository.GetPaySlipDetails().Skip(page * pagesize).Take(pagesize)
                .Where(s => s.EmployeeId.Equals(employeeID));
                if (paySlipDetails != null)
                {
                    foreach (PaySlipDetail paySlipDetail in paySlipDetails)
                    {
                        paySlipDetail.Employee = employeeRepository.GetEmployeeByID(paySlipDetail.EmployeeId);
                    }
                    return paySlipDetails;
                }
            }else
            {
                IEnumerable<PaySlipDetail> paySlipDetails = paySlipDetailRepository.GetPaySlipDetails().Skip(page * pagesize).Take(pagesize)
                .Where(s => s.EmployeeId.Equals(employeeID));
                if (paySlipDetails != null)
                {
                    foreach (PaySlipDetail paySlipDetail in paySlipDetails)
                    {
                        paySlipDetail.Employee = employeeRepository.GetEmployeeByID(paySlipDetail.EmployeeId);
                    }
                    return paySlipDetails;
                }
            }
            return null;
        }
        [HttpGet(template: "find/{id}")]
        public PaySlipDetail Get(int id)
        {
            PaySlipDetail paySlipDetail = paySlipDetailRepository.GetPaySlipDetailByID(id);
            paySlipDetail.Employee = employeeRepository.GetEmployeeByID(paySlipDetail.EmployeeId);
            return paySlipDetail;
            /*return _payRollDBCotext.Companies.SingleOrDefault(x => x.Id == id);*/
        }

        // POST api/<CompanyController>
        [HttpPost(template: "add")]
        public String Post([FromBody] PaySlipDetail paySlipDetail)
        {
            try
            {
                paySlipDetailRepository.InsertPaySlipDetail(paySlipDetail);
                paySlipDetailRepository.Save();
            }
            catch (Exception)
            {
                return "Add Failed";
            }
            return "Add Success";
        }

        // PUT api/<CompanyController>/5
        [HttpPut(template: "update")]
        public String Put([FromBody] PaySlipDetail paySlipDetail)
        {
            try
            {
                paySlipDetailRepository.UpdatePaySlipDetail(paySlipDetail);
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
                PaySlipDetail findPaySlipDetail = paySlipDetailRepository.GetPaySlipDetailByID(id);
                if (findPaySlipDetail != null)
                {
                    paySlipDetailRepository.DeletePaySlipDetail(id);
                    paySlipDetailRepository.Save();
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
