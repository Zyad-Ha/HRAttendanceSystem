    using HRAttendanceSystem.BL.DTOs.AttendanceDTOs;
using HRAttendanceSystem.DAL.Model;
using HRAttendanceSystem.DAL.Repos.AttendanceRepo;
using HRAttendanceSystem.DAL.Repos.EmployeeRepo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HRAttendanceSystem.BL.Services.AttendanceService
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepo _ARepo;
        public AttendanceService(IAttendanceRepo attendanceRepo)
        {
            _ARepo = attendanceRepo;
        }

        public void Delete(int id)
        {
            _ARepo.Delete(id);
            _ARepo.SaveChanges();
        }

        public IEnumerable<ReadAttendanceDTO> GetAll()
        {
            return _ARepo.GetAll().Select(x => new ReadAttendanceDTO
            {
                Id = x.Id,
                EmployeeId = x.EmployeeId,
                CheckIn = x.CheckIn,
                CheckOut = x.CheckOut,
                Date = x.Date,
                TotalHours = x.CheckOut.HasValue? (x.CheckOut.Value - x.CheckIn) :null
            }).ToList();
        }

        public IEnumerable<ReadAttendanceDTO> GetByDate(DateOnly date)
        {
            return _ARepo.GetByDate(date).Select(i => new ReadAttendanceDTO
            {
                Id = i.Id,
                EmployeeId = i.EmployeeId,
                CheckIn = i.CheckIn,
                CheckOut = i.CheckOut,
                Date = i.Date,
                TotalHours = i.CheckOut.HasValue? (i.CheckOut.Value - i.CheckIn) :null

            }).ToList();
        }


        public IEnumerable<ReadAttendanceDTO> GetEmployeeId(int EmpId)
        {
            return _ARepo.GetEmployeeId(EmpId)
                .Select(i => new ReadAttendanceDTO
                {
                    Id = i.Id,
                    EmployeeId = i.EmployeeId,
                    CheckIn = i.CheckIn,
                    CheckOut = i.CheckOut,
                    Date = i.Date,
                    TotalHours = i.CheckOut.HasValue? (i.CheckOut - i.CheckIn) : null

                }).ToList();
        }

        public ReadAttendanceDTO GetById(int id)
        {
            var exist = _ARepo.GetById(id);
            if (exist is not null)
            {
                return new ReadAttendanceDTO
                {
                    Id = exist.Id,
                    EmployeeId = exist.EmployeeId,
                    CheckIn = exist.CheckIn,
                    CheckOut = exist.CheckOut,
                    Date = exist.Date,
                    TotalHours = exist.CheckOut.HasValue? (exist.CheckOut.Value - exist.CheckIn) : null

                };
            }
            return null;
        }

        public void AddCheckIn(CheckInDTO checkIn)
        {
            var todayDateRecord = DateOnly.FromDateTime(DateTime.Now);

            var checkInExist = _ARepo.GetEmployeeId(checkIn.EmployeeId)
                .FirstOrDefault(a => a.Date == todayDateRecord);

            if (checkInExist != null)
            {
                throw new Exception("You checked in already.");
            }

            var NewCheckIn = new Attendance
            {
                EmployeeId = checkIn.EmployeeId,
                Date = todayDateRecord,
                CheckIn = TimeOnly.FromDateTime(DateTime.Now)
            };
            _ARepo.Add(NewCheckIn);
            _ARepo.SaveChanges();

        }


        public void UpdateCheckOut(int EmpId)
        {
            var today = DateOnly.FromDateTime(DateTime.Now);

            var checkInRecord = _ARepo.GetEmployeeId(EmpId)
                .FirstOrDefault(a => a.Date == today);

            if (checkInRecord == null)
            {
                throw new Exception("You didn't check in today");
            }

            if (checkInRecord.CheckOut != null)
            {
                throw new Exception("You already checked out today.");
            }

            var currentTime = TimeOnly.FromDateTime(DateTime.Now);
            if (currentTime < checkInRecord.CheckIn)
            {
                throw new Exception("Check out time must be after check in time.");
            }

            checkInRecord.CheckOut = currentTime;
            _ARepo.Update(checkInRecord);
            _ARepo.SaveChanges();
        }
    }
}
