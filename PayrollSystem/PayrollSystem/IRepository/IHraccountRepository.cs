using PayrollSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollSystem.IRepository
{
    public interface IHraccountRepository:IDisposable
    {
        IEnumerable<Hraccount> GetHraccounts();
        Hraccount GetHraccountByID(int Id);
        void InsertHraccount(Hraccount hraccount);
        void DeleteHraccount(int id);
        void UpdateHraccount(Hraccount hraccount);
        void Save();
    }
}
