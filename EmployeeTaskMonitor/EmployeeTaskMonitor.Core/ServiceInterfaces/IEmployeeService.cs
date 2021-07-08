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
      
        Task<IEnumerable<EmployeeResponseModel>> GetAllEmployees();
        Task<EmployeeResponseModel> GetEmployeeById(int id);
        System.Threading.Tasks.Task AddEmployee(EmployeeRequestModel employeeCreateRequest);
        System.Threading.Tasks.Task RemoveEmployee(EmployeeRequestModel employeeCreateRequest);
        Task<EmployeeResponseModel> UpdateEmployee(EmployeeRequestModel employeeRequest);




        Task<IEnumerable<TaskResponseModel>> GetTasksByEmployeeId(int Id);

    }
}
