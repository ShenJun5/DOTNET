using EmployeeTaskMonitor.Core.Entities;
using EmployeeTaskMonitor.Core.Exceptions;
using EmployeeTaskMonitor.Core.RepositoryInterfaces;
using EmployeeTaskMonitor.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTaskMonitor.Infrastructure.Repositories
{
    public class EmployeeRepository : EfRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(EmployeeTaskMonitorDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Core.Entities.Task>> GetTasksByEmployee(int Id)
        {
            var tasks = await _dbContext.Tasks.Where(t => t.EmployeeId == Id).Include(t => t.Employee)
                .Select(t => new Core.Entities.Task
                {
                    EmployeeId = t.EmployeeId,
                    TaskName = t.TaskName,
                    StartTime = t.StartTime,
                    Deadline = t.Deadline
                }).ToListAsync();
            return tasks;
        }

        public override async Task<Employee> GetByIdAsync(int id)
        {
            return await _dbContext.Employees.Include(e => e.EmployeeTasks).FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
