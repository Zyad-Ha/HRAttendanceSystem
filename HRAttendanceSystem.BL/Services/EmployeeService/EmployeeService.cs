using HRAttendanceSystem.BL.DTOs.EmployeeDTOs;
using HRAttendanceSystem.DAL.Model;
using HRAttendanceSystem.DAL.Repos.EmployeeRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRAttendanceSystem.BL.Services.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepo _Erepo;
        public EmployeeService(IEmployeeRepo repo)
        {
            _Erepo = repo;

        }
        public void Add(WriteEmployeeDTO employeeDto)
        {
            var newEmp = new Employee()
            {
                Name = employeeDto.Name,
                Department = employeeDto.Department,
                Email = employeeDto.Email,
                HireDate = employeeDto.HireDate
            };
            _Erepo.Add(newEmp);
            _Erepo.SaveChanges();
        }

        public void Delete(int id)
        {
            _Erepo.Delete(id);
            _Erepo.SaveChanges();
        }

        public IEnumerable<ReadEmployeeDTO> GetAll()
        {
            return _Erepo.GetAll().Select(e => new ReadEmployeeDTO
            {
                Id = e.Id,
                Name = e.Name,
                Email = e.Email,
                Department = e.Department,
                HireDate = e.HireDate
            }).ToList();
        }

        public ReadEmployeeDTO GetById(int id)
        {
            var empIdExist = _Erepo.GetById(id);
            if (empIdExist is not null)
            {
                return new ReadEmployeeDTO
                {
                    Id = empIdExist.Id,
                    Name = empIdExist.Name,
                    Email = empIdExist.Email,
                    Department = empIdExist.Department,
                    HireDate = empIdExist.HireDate
                };
            }
            return null;
        }

        public void Update(int id, WriteEmployeeDTO employeeDto)
        {
            var OldEmp = _Erepo.GetById(id);
            if (OldEmp is not null)
            {
                OldEmp.Name = employeeDto.Name;
                OldEmp.Email = employeeDto.Email;
                OldEmp.Department = employeeDto.Department;
                OldEmp.HireDate = employeeDto.HireDate;
                _Erepo.Update(OldEmp);
                _Erepo.SaveChanges();
            }
        }
    }
}
