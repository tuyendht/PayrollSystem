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
    [Route("api/feedbacks")]
    [ApiController]
    public class FeedBackController : ControllerBase
    {
        private IFeedBackRepository feedBackRepository;
        private IPaySlipRepository paySlipRepository;
        private readonly PayrollSystemContext _payRollDBCotext;
        public FeedBackController(PayrollSystemContext payRollDBCotext)
        {
            this.feedBackRepository = new FeedBackRepository(new PayrollSystemContext());
            this.paySlipRepository = new PaySlipRepository(new PayrollSystemContext());
            _payRollDBCotext = payRollDBCotext;
        }
        [HttpGet(template: "get")]
        public IEnumerable<FeedBack> Get(string desciption, int paySlipID, int page, int pagesize)
        {
            if (desciption == null) desciption = "";
            if (desciption == "" && paySlipID == 0)
            {
                IEnumerable<FeedBack> feedBacks = feedBackRepository.GetFeedBacks().Skip(page * pagesize).Take(pagesize).OrderByDescending(s=>s.Id);
                if (feedBacks != null)
                {
                    foreach (FeedBack feedBack in feedBacks)
                    {
                        feedBack.PaySlip = paySlipRepository.GetPaySlipByID((int)feedBack.PaySlipId);
                    }
                    return feedBacks;
                }

            }
            else if (desciption != "" && paySlipID == 0)
            {
                IEnumerable<FeedBack> feedBacks = feedBackRepository.GetFeedBacks().Skip(page * pagesize).Take(pagesize)
                .Where(s => s.Desciption.Contains(desciption, StringComparison.OrdinalIgnoreCase)).OrderByDescending(s => s.Id);
                if (feedBacks != null)
                {
                    foreach (FeedBack feedBack in feedBacks)
                    {
                        feedBack.PaySlip = paySlipRepository.GetPaySlipByID((int)feedBack.PaySlipId);
                    }
                    return feedBacks;
                }
            }
            else if (paySlipID != 0 && desciption == "")
            {
                IEnumerable<FeedBack> feedBacks = feedBackRepository.GetFeedBacks().Skip(page * pagesize).Take(pagesize)
                .Where(s => s.PaySlipId.Equals(paySlipID)).OrderByDescending(s => s.Id);
                if (feedBacks != null)
                {
                    foreach (FeedBack feedBack in feedBacks)
                    {
                        feedBack.PaySlip = paySlipRepository.GetPaySlipByID((int)feedBack.PaySlipId);
                    }
                    return feedBacks;
                }
            }
            else
            {
                IEnumerable<FeedBack> feedBacks = feedBackRepository.GetFeedBacks().Skip(page * pagesize).Take(pagesize)
                .Where(s => s.Desciption.Contains(desciption, StringComparison.OrdinalIgnoreCase))
                .Where(s => s.PaySlipId.Equals(paySlipID)).OrderByDescending(s => s.Id);
                if (feedBacks != null)
                {
                    foreach (FeedBack feedBack in feedBacks)
                    {
                        feedBack.PaySlip = paySlipRepository.GetPaySlipByID((int)feedBack.PaySlipId);
                    }
                    return feedBacks;
                }
            }
            return null;
        }
        [HttpGet(template: "find/{id}")]
        public FeedBack Get(int id)
        {
            FeedBack feedBack = feedBackRepository.GetFeedBackByID(id);
            if (feedBack != null)
            {
                feedBack.PaySlip = paySlipRepository.GetPaySlipByID((int)feedBack.PaySlipId);
            }
            return feedBack;
        }

        [HttpGet(template: "findByEmpID")]
        public IEnumerable<FeedBack> GetByEmpID(int empID)
        {
            IEnumerable<FeedBack> feedBacks = feedBackRepository.GetFeedBacks()
                .Where(s => s.EmployeeId.Equals(empID)).OrderByDescending(s => s.Id);
            if (feedBacks != null)
            {
                foreach (FeedBack feedBack in feedBacks)
                {
                    feedBack.PaySlip = paySlipRepository.GetPaySlipByID((int)feedBack.PaySlipId);
                }
                return feedBacks;
            }
            return feedBacks;
        }

        [HttpPost(template: "add")]
        public String Post([FromBody] FeedBack feedBack)
        {
            try
            {
                feedBackRepository.InsertFeedBack(feedBack);
                feedBackRepository.Save();
            }
            catch (Exception e)
            {
                return "Add Failed";
            }
            return "Add Success";
        }

        // PUT api/<CompanyController>/5
        [HttpPut(template: "update")]
        public String Put([FromBody] FeedBack feedBack)
        {
            try
            {
                feedBackRepository.UpdateFeedBack(feedBack);
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
                FeedBack findFeedBack = feedBackRepository.GetFeedBackByID(id);
                if (findFeedBack != null)
                {
                    feedBackRepository.DeleteFeedBack(id);
                    feedBackRepository.Save();
                }
            }
            catch (Exception e)
            {
                return "Delete Failed";
            }
            return "Delete Success";
        }
    }
}
