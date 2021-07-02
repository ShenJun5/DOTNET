using EmployeeTaskMonitor.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTaskMonitor.Core.RepositoryInterfaces
{
    public interface IEmployeeRepository: IAsyncRepository<Employee>
    {
        Task<IEnumerable<Core.Entities.Task>> GetTasksByEmployee(int Id);
    }
}
