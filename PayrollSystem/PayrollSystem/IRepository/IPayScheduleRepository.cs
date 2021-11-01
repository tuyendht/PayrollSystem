using PayrollSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollSystem.IRepository
{
    public interface IPayScheduleRepository: IDisposable
    {
        IEnumerable<PaySchedule> GetPaySchedules();
        PaySchedule GetPayScheduleByID(int Id);
        void InsertPaySchedule(PaySchedule paySchedule);
        void DeletePaySchedule(int id);
        void UpdatePaySchedule(PaySchedule paySchedule);
        void Save();
    }
}
