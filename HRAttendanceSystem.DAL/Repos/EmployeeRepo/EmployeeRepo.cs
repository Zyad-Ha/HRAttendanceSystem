using HRAttendanceSystem.DAL.Data;
using HRAttendanceSystem.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRAttendanceSystem.DAL.Repos.EmployeeRepo
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly AppDbContext _appDbContext;
        public EmployeeRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Add(Employee employee)
        {
            _appDbContext.Employees.Add(employee);
        }

        public void Delete(int id)
        {
            var emp = GetById(id);
            if (emp != null)
                _appDbContext.Employees.Remove(emp);

        }

        public IEnumerable<Employee> GetAll()
        {
            return _appDbContext.Employees.ToList();
        }

        public Employee GetById(int id)
        {
            return _appDbContext.Employees.Find(id);
        }
        public void Update(Employee employee)
        {
            _appDbContext.Employees.Update(employee);
        }

        public int SaveChanges()
        {
            return _appDbContext.SaveChanges();
        }

    }
}
