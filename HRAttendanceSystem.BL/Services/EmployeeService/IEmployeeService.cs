using HRAttendanceSystem.BL.DTOs.EmployeeDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRAttendanceSystem.BL.Services.EmployeeService
{
    public interface IEmployeeService
    {
        public IEnumerable<ReadEmployeeDTO> GetAll(int pageNumber,int pageSize);
        public ReadEmployeeDTO GetById(int id);
        public void Add(WriteEmployeeDTO employeeDto);
        public void Update(int id,WriteEmployeeDTO employeeDto);
        public void Delete(int id);

    }
}
