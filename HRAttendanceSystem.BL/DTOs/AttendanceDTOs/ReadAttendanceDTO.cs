using HRAttendanceSystem.DAL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRAttendanceSystem.BL.DTOs.AttendanceDTOs
{
    public class ReadAttendanceDTO
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly CheckIn { get; set; }
        public TimeOnly? CheckOut { get; set; }
        public TimeSpan? TotalHours { get; set; }
    }
}
