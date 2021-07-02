using EmployeeTaskMonitor.Core.Entities;
using EmployeeTaskMonitor.Core.RepositoryInterfaces;
using EmployeeTaskMonitor.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeTaskMonitor.Infrastructure.Repositories
{
    public class TaskRepository : EfRepository<Task>, ITaskRepository
    {
        public TaskRepository(EmployeeTaskMonitorDbContext dbContext) : base(dbContext)
        {
        }

    }
    
}
