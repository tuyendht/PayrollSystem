using PayrollSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollSystem.IRepository
{
    public interface IIndustryRepository: IDisposable
    {
        IEnumerable<Industry> GetIndustries();
        Industry GetIndustryByID(int Id);
        void InsertIndustry(Industry industry);
        void DeleteIndustry(int id);
        void UpdateIndustry(Industry industry);
        void Save();
    }
}
