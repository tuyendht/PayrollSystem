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
    [Route("api/legalstructures")]
    [ApiController]
/*    [Authorize]*/
    public class LegalStructureController : ControllerBase
    {
        private ILegalStructureRepository legalStructureRepository;
        private readonly PayrollSystemContext _payRollDBCotext;
        public LegalStructureController(PayrollSystemContext payRollDBCotext)
        {
            this.legalStructureRepository = new LegalStructureRepository(new PayrollSystemContext());
            _payRollDBCotext = payRollDBCotext;
        }
        [HttpGet(template: "get")]
        public IEnumerable<LegalStructure> Get(string name, int page, int pagesize)
        {
            if (name == null) name = "";
            IEnumerable<LegalStructure> legalStructures = legalStructureRepository.GetLegalStructures().Skip(page * pagesize).Take(pagesize)
            .Where(s => s.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
            return legalStructures;
        }
        [HttpGet(template: "find/{id}")]
        public LegalStructure Get(int id)
        {
            LegalStructure legalStructure = legalStructureRepository.GetLegalStructureByID(id);
            return legalStructure;
            /*return _payRollDBCotext.Companies.SingleOrDefault(x => x.Id == id);*/
        }

        // POST api/<CompanyController>
        [HttpPost(template: "add")]
        public void Post([FromBody] LegalStructure legalStructure)
        {
            legalStructureRepository.InsertLegalStructure(legalStructure);
            legalStructureRepository.Save();
            /*_payRollDBCotext.Companies.Add(company);
            _payRollDBCotext.SaveChanges();*/
        }

        // PUT api/<CompanyController>/5
        [HttpPut(template: "update")]
        public HttpStatusCode Put([FromBody] LegalStructure legalStructure)
        {
            try
            {
                legalStructureRepository.UpdateLegalStructure(legalStructure);
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
            LegalStructure findLegalStructure = legalStructureRepository.GetLegalStructureByID(id);

            /*var item = _payRollDBCotext.Companies.FirstOrDefault(x => x.Id == id);*/
            if (findLegalStructure != null)
            {
                legalStructureRepository.DeleteLegalStructure(id);
                legalStructureRepository.Save();
                /*_payRollDBCotext.Companies.Remove(item);
                _payRollDBCotext.SaveChanges();*/
            }
        }
    }
}
