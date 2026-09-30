using HRAttendanceSystem.BL.DTOs.AttendanceDTOs;
using HRAttendanceSystem.BL.Services.AttendanceService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRAttendanceSystem.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;
        public AttendanceController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var attend = _attendanceService.GetAll();
            if (!attend.Any())
            {
                return BadRequest("there is no attendances added yet");
            }
            return Ok(attend);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            return Ok(_attendanceService.GetById(id));
        }

        [HttpGet("employee/{EmployeeId}")]
        public ActionResult GetEmployeeId(int EmployeeId)
        {
            return Ok(_attendanceService.GetEmployeeId(EmployeeId));
        }

        [HttpGet("date/{date}")]
        public ActionResult GetByDate(DateOnly date)
        {
            return Ok(_attendanceService.GetByDate(date));
        }


        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _attendanceService.Delete(id);
            return NoContent();
        }

        [HttpPost("Check-In")]
        public ActionResult AddCheckIn(CheckInDTO checkInDTO)
        {
            try
            {
                _attendanceService.AddCheckIn(checkInDTO);
                return Ok("checked in Successfuly!.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Check-Out/{EmpId}")]
        public ActionResult UpdateCheckOut(int EmpId)
        {
            try
            {
                _attendanceService.UpdateCheckOut(EmpId);
                return Ok("Check Out updated.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
