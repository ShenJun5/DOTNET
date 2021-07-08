using EmployeeTaskMonitor.Core.Models;
using EmployeeTaskMonitor.Core.ServiceInterfaces;
using EmployeeTaskMonitor.Infrastructure.Data;
using EmployeeTaskMonitor.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeTaskMonitor.MVC.Controllers
{
    public class TasksController : Controller
    {

        private readonly ITaskService _taskService;
        private readonly IEmployeeService _employeeService;
        public TasksController(ITaskService taskService, IEmployeeService employeeService)
        {
            _taskService = taskService;
            _employeeService = employeeService;
        }


        //[HttpGet]
        //public async Task<IActionResult> Index()
        //{
        //    var tasks = await _dbContext.Tasks.ToListAsync();    
        //    return View(tasks);
        //}


        [HttpGet]
        public async Task<IActionResult> CreateTask(int? employeeId)
        {
            ViewBag.EmployeeId = employeeId == null ? 0 : employeeId.Value;
            return View();
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<IActionResult> CreateTask(TaskRequestModel taskRequest)
        {
            if (ModelState.IsValid && taskRequest.EmployeeId != 0)
            {
                await _taskService.AddTask(taskRequest);
            }
            var tasks = await _employeeService.GetTasksByEmployeeId(taskRequest.EmployeeId);
            return View("../Employees/GetTasks", tasks);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteTask()
        {
            return View();
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<IActionResult> DeleteTask(TaskRequestModel taskCreateRequest)
        {
            if (ModelState.IsValid)
            {
                await _taskService.RemoveTask(taskCreateRequest);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditTask()
        {
            return View();
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<IActionResult> EditTask(TaskRequestModel taskCreateRequest)
        {
            if (ModelState.IsValid)
            {
                await _taskService.UpdateTask(taskCreateRequest);
            }
            return View();
        }

    }
}
