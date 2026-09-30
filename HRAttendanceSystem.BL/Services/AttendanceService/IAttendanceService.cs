using HRAttendanceSystem.BL.DTOs.AttendanceDTOs;
using HRAttendanceSystem.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRAttendanceSystem.BL.Services.AttendanceService
{
    public interface IAttendanceService
    {
        public IEnumerable<ReadAttendanceDTO> GetAll();
        public IEnumerable<ReadAttendanceDTO> GetEmployeeId(int EmpId);
        public IEnumerable<ReadAttendanceDTO> GetByDate(DateOnly date);
        public ReadAttendanceDTO GetById(int id);
        public void AddCheckIn(CheckInDTO checkIn);
        public void UpdateCheckOut(int EmpId );
        public void Delete(int id);
    }
}
