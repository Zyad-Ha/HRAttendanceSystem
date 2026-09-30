using HRAttendanceSystem.DAL.Data;
using HRAttendanceSystem.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRAttendanceSystem.DAL.Repos.AttendanceRepo
{
    public class AttendanceRepo : IAttendanceRepo
    {
        private readonly AppDbContext _appDbContext;
        public AttendanceRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void Add(Attendance attendance)
        {
            _appDbContext.Attendances.Add(attendance);
        }

        public void Delete(int id)
        {
            var attendExist = GetById(id);
            if (attendExist != null) 
                _appDbContext.Attendances.Remove(attendExist);
        }

        public IEnumerable<Attendance> GetAll()
        {
            return _appDbContext.Attendances.ToList();
        }

        public Attendance GetById(int id)
        {
            return _appDbContext.Attendances.Find(id);
        }

        public void Update(Attendance attendance)
        {
            _appDbContext.Attendances.Update(attendance);
        }
        public int SaveChanges()
        {
            return _appDbContext.SaveChanges();
        }

        public IEnumerable<Attendance> GetEmployeeId(int EmpId)
        {
            return _appDbContext.Attendances
                .Where(a => a.EmployeeId == EmpId)
                .ToList();
        }

        public IEnumerable<Attendance> GetByDate(DateOnly date)
        {
            return _appDbContext.Attendances
                .Where(a => a.Date == date)
                .ToList();
        }
    }
}
