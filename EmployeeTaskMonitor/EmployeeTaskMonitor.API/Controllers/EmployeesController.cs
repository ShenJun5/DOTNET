using EmployeeTaskMonitor.Core.Models;
using EmployeeTaskMonitor.Core.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeTaskMonitor.API.Controllers
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
        [Route("allemployees")]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _employeeService.GetAllEmployees();
            if (!employees.Any())
            {
                return NotFound("No employees");
            }
            return Ok(employees);
        }

        [HttpPost("addemployee")]
        public async Task<IActionResult> CreateEmployee(EmployeeRequestModel employeeCreateRequest)
        {
            await _employeeService.AddEmployee(employeeCreateRequest);
            return Ok();
        }



    }
}
