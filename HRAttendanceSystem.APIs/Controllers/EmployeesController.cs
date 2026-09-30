using HRAttendanceSystem.BL.DTOs.EmployeeDTOs;
using HRAttendanceSystem.BL.Services.EmployeeService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRAttendanceSystem.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_employeeService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var employee = _employeeService.GetById(id);
            if (employee is null)
            {
                return NotFound($"Employee with ID {id} not found.");
            }
            return Ok(employee);
        }

        [HttpPost]
        public ActionResult Add(WriteEmployeeDTO EmployeeDTO)
        {
            _employeeService.Add(EmployeeDTO);
            return Ok("Employee added successfully.");
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, WriteEmployeeDTO EmployeeDTO)
        {
            _employeeService.Update(id, EmployeeDTO);
            return Ok("Employee updated successfully.");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _employeeService.Delete(id);
            return NoContent();
        }
    }
}
