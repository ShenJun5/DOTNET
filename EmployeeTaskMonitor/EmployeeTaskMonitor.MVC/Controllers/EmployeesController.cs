using EmployeeTaskMonitor.Core.Models;
using EmployeeTaskMonitor.Core.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeTaskMonitor.MVC.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetTasks(int Id)
        {
            var employeeTasks =await  _employeeService.GetTasksByEmployeeId(Id);
            ViewBag.EmployeeId = Id;
            return View(employeeTasks);
        }

        [HttpGet]
        public async Task<IActionResult> CreateEmployee()
        {
            return View();
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<IActionResult> CreateEmployee(EmployeeRequestModel employeeCreateRequest)
        {
            if (ModelState.IsValid)
            {
                await _employeeService.AddEmployee(employeeCreateRequest);
            }
            var employees = await _employeeService.GetAllEmployees();
            return View("../Home/Index", employees);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteEmployee()
        {
            return View();
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<IActionResult> DeleteEmployee(EmployeeRequestModel employeeCreateRequest)
        {
            if (ModelState.IsValid)
            {
                await _employeeService.RemoveEmployee(employeeCreateRequest);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditEmployee()
        {
            return View();
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<IActionResult> EditEmployee(EmployeeRequestModel employeeCreateRequest)
        {
            if (ModelState.IsValid)
            {
                await _employeeService.UpdateEmployee(employeeCreateRequest);
            }
            return View();
        }

    }
}
