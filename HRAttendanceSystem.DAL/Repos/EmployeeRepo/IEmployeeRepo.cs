using HRAttendanceSystem.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRAttendanceSystem.DAL.Repos.EmployeeRepo
{
    public interface IEmployeeRepo
    {
        public IEnumerable<Employee> GetAll();
        public Employee GetById(int id);
        public void Add(Employee employee);
        public void Update(Employee employee);
        public void Delete(int id);

        public int SaveChanges();


    }
}
