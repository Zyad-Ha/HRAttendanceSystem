using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRAttendanceSystem.DAL.Model
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Department { get; set; }

        public DateTime HireDate { get; set; }

        public ICollection<Attendance> Attendances { get; set; } = new HashSet<Attendance>();    

    }
}
