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
    [Route("api/payscheduletypes")]
    [ApiController]
    public class PayScheduleTypeController : ControllerBase
    {
        private IPayScheduleTypeRepository payScheduleTypeRepository;
        private readonly PayrollSystemContext _payRollDBCotext;
        public PayScheduleTypeController(PayrollSystemContext payRollDBCotext)
        {
            this.payScheduleTypeRepository = new PayScheduleTypeRepository(new PayrollSystemContext());
            _payRollDBCotext = payRollDBCotext;
        }

        [HttpGet(template: "get")]
        public IEnumerable<PayScheduleType> Get(string name, int page, int pagesize)
        {
            if (name == null) name = "";
            IEnumerable<PayScheduleType> payScheduleTypes = payScheduleTypeRepository.GetPayScheduleTypes().Skip(page * pagesize).Take(pagesize)
            .Where(s => s.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
            if (payScheduleTypes != null)
            {
                return payScheduleTypes;
            }
            return null;
        }

        [HttpGet(template: "find/{id}")]
        public PayScheduleType Get(int id)
        {
            PayScheduleType payScheduleType = payScheduleTypeRepository.GetPayScheduleTypeByID(id);
            if (payScheduleType != null)
            {
                return payScheduleType;
            }
            return null;
        }
        [HttpPost(template: "add")]
        public String Post([FromBody] PayScheduleType payScheduleType)
        {
            payScheduleTypeRepository.InsertPayScheduleType(payScheduleType);
            payScheduleTypeRepository.Save();
            return "Add Success";
        }

        // PUT api/<PayScheduleTypeController>/5
        [HttpPut(template: "update")]
        public String Put([FromBody] PayScheduleType payScheduleType)
        {
            try
            {
                payScheduleTypeRepository.UpdatePayScheduleType(payScheduleType);
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
                PayScheduleType findPayScheduleType = payScheduleTypeRepository.GetPayScheduleTypeByID(id);
                if (findPayScheduleType != null)
                {
                    payScheduleTypeRepository.DeletePayScheduleType(id);
                    payScheduleTypeRepository.Save();
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
