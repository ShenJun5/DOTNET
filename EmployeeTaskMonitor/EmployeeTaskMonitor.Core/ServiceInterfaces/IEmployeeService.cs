using EmployeeTaskMonitor.Core.Entities;
using EmployeeTaskMonitor.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTaskMonitor.Core.ServiceInterfaces
{
    public interface IEmployeeService
    {
        public Task<IEnumerable<EmployeeResponseModel>> GetAllEmployees();

        public Task<IEnumerable<TaskResponseModel>> GetTasksByEmployeeId(int Id);

        public Task<EmployeeResponseModel> GetEmployeeById(int id);
    }
}
