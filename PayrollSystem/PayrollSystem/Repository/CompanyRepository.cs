using Microsoft.EntityFrameworkCore;
using PayrollSystem.IRepository;
using PayrollSystem.Models;
/*using PayrollSystem.Models.DB;*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollSystem.Repository
{
    public class CompanyRepository : ICompanyRepository, IDisposable
    {
        private PayrollSystemContext context;
        public CompanyRepository(PayrollSystemContext context)
        {
            this.context = context;
        }

        public void DeleteCompany(int Id)
        {
            Company company = context.Companies.Find(Id);
            context.Companies.Remove(company);
        }
        private bool disposed = false;
        private PayrollSystemContext payrollSystemContext;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Company> GetCompanies()
        {
            return context.Companies.ToList();
        }

        public Company GetCompanyByID(int Id)
        {
            return context.Companies.Find(Id);
        }

        public void InsertCompany(Company company)
        {
            context.Companies.Add(company);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateCompany(Company company)
        {
            /*context.Entry(company).State = EntityState.Modified.;*/
            context.Companies.Update(company);
            context.SaveChanges();
        }
    }
}
