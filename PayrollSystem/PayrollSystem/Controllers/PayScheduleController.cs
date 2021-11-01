using Microsoft.AspNetCore.Mvc;
using PayrollSystem.IRepository;
using PayrollSystem.Models;
using PayrollSystem.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PayrollSystem.Controllers
{
    [Route("api/payschedules")]
    [ApiController]
    public class PayScheduleController : ControllerBase
    {
        private IPayScheduleRepository payScheduleRepository;
        private ICompanyRepository companyRepository;
        private readonly PayrollSystemContext _payRollDBCotext;
        public PayScheduleController(PayrollSystemContext payRollDBCotext)
        {
            this.payScheduleRepository = new PayScheduleRepository(new PayrollSystemContext());
            this.companyRepository = new CompanyRepository(new PayrollSystemContext());
            _payRollDBCotext = payRollDBCotext;
        }
        [HttpGet(template: "get")]
        public IEnumerable<PaySchedule> Get(int companyID, int payScheduleType, int page, int pagesize)
        {
            if (companyID == 0 && payScheduleType == 0)
            {
                IEnumerable<PaySchedule> paySchedules = payScheduleRepository.GetPaySchedules().Skip(page * pagesize).Take(pagesize);
                if (paySchedules != null)
                {
                    foreach (PaySchedule paySchedule in paySchedules)
                    {
                        paySchedule.Company = companyRepository.GetCompanyByID(paySchedule.CompanyId);
                    }
                    return paySchedules;
                }

            }
            else if (companyID != 0 && payScheduleType == 0)
            {
                IEnumerable<PaySchedule> paySchedules = payScheduleRepository.GetPaySchedules().Skip(page * pagesize).Take(pagesize)
                .Where(s => s.CompanyId.Equals(companyID));
                if (paySchedules != null)
                {
                    foreach (PaySchedule paySchedule in paySchedules)
                    {
                        paySchedule.Company = companyRepository.GetCompanyByID(paySchedule.CompanyId);
                    }
                    return paySchedules;
                }
            }
            else if (payScheduleType != 0 && companyID == 0)
            {
                IEnumerable<PaySchedule> paySchedules = payScheduleRepository.GetPaySchedules().Skip(page * pagesize).Take(pagesize)
                .Where(s => s.PayScheduleType.Equals(payScheduleType));
                if (paySchedules != null)
                {
                    foreach (PaySchedule paySchedule in paySchedules)
                    {
                        paySchedule.Company = companyRepository.GetCompanyByID(paySchedule.CompanyId);
                    }
                    return paySchedules;
                }
            }
            else
            {
                IEnumerable<PaySchedule> paySchedules = payScheduleRepository.GetPaySchedules().Skip(page * pagesize).Take(pagesize)
                .Where(s => s.PayScheduleType.Equals(payScheduleType))
                .Where(s => s.CompanyId.Equals(companyID));
                if (paySchedules != null)
                {
                    foreach (PaySchedule paySchedule in paySchedules)
                    {
                        paySchedule.Company = companyRepository.GetCompanyByID(paySchedule.CompanyId);
                    }
                    return paySchedules;
                }
            }
            return null;
        }

        [HttpGet(template: "find/{id}")]
        public PaySchedule Get(int id)
        {
            PaySchedule paySchedule = payScheduleRepository.GetPayScheduleByID(id);
            if (paySchedule != null)
            {
                return paySchedule;
            }
            return null;
        }

        [HttpPost(template: "add")]
        public String Post([FromBody] PaySchedule paySchedule)
        {
            payScheduleRepository.InsertPaySchedule(paySchedule);
            payScheduleRepository.Save();
            return "Add Success";
        }

        // PUT api/<PayScheduleController>/5
        [HttpPut(template: "update")]
        public String Put([FromBody] PaySchedule paySchedule)
        {
            try
            {
                payScheduleRepository.UpdatePaySchedule(paySchedule);
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
            PaySchedule findPaySchedule = payScheduleRepository.GetPayScheduleByID(id);
            if (findPaySchedule != null)
            {
                payScheduleRepository.DeletePaySchedule(id);
                payScheduleRepository.Save();
                return "Delete Success";
            }
            return "Delete Failed";

        }

    }
}
