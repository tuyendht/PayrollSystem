using PayrollSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollSystem.IRepository
{
    public interface IPayScheduleTypeRepository : IDisposable
    {
        IEnumerable<PayScheduleType> GetPayScheduleTypes();
        PayScheduleType GetPayScheduleTypeByID(int Id);
        void InsertPayScheduleType(PayScheduleType payScheduleType);
        void DeletePayScheduleType(int id);
        void UpdatePayScheduleType(PayScheduleType payScheduleType);
        void Save();
    }
}
