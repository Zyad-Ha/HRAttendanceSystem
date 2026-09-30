using HRAttendanceSystem.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRAttendanceSystem.DAL.Repos.AttendanceRepo
{
    public interface IAttendanceRepo
    {
        public IEnumerable<Attendance> GetAll();
        public IEnumerable<Attendance> GetEmployeeId(int EmpId);
        public IEnumerable<Attendance> GetByDate(DateOnly date);
        public Attendance GetById(int id);
        public void Add(Attendance attendance);
        public void Update(Attendance attendance);
        public void Delete(int id);

        public int SaveChanges();
    }
}
