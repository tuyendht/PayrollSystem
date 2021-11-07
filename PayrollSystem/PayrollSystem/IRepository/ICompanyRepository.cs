using PayrollSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollSystem.IRepository
{
    public interface ICompanyRepository : IDisposable
    {
        IEnumerable<Company> GetCompanies();
        Company GetCompanyByID(int Id);
        void InsertCompany(Company company);
        void DeleteCompany(int id);
        void UpdateCompany(Company company);
        void Save();
    }
}
