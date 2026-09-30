using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRAttendanceSystem.BL.DTOs.EmployeeDTOs
{
    public class WriteEmployeeDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }

    }
}
