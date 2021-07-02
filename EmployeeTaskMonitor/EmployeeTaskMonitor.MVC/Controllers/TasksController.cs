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
        private readonly EmployeeTaskMonitorDbContext _dbContext;

        public TasksController(EmployeeTaskMonitorDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var tasks = await _dbContext.Tasks.ToListAsync();    
            return View(tasks);
        }

    }
}
