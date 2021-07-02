using EmployeeTaskMonitor.Core.Entities;
using EmployeeTaskMonitor.Core.Models;
using EmployeeTaskMonitor.Core.RepositoryInterfaces;
using EmployeeTaskMonitor.Core.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTaskMonitor.Infrastructure.Services
{
    public class EmployeeService : IEmployeeService
    {
       // private readonly IAsyncRepository<Employee> _employeeRepository;
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<IEnumerable<EmployeeResponseModel>> GetAllEmployees()
        {
            var employees = await _employeeRepository.ListAllAsync();
            var employeeCardResponseModel = new List<EmployeeResponseModel>();
            foreach(var employee in employees)
            {
                var employeeCard = new EmployeeResponseModel();
                employeeCard.EmployeeId = employee.EmployeeId;
                employeeCard.FirstName = employee.FirstName;
                employeeCard.LastName = employee.LastName;
                employeeCard.HiredDate = employee.HiredDate;
                employeeCardResponseModel.Add(employeeCard);
            }
            return employeeCardResponseModel;
        }

        public async Task<IEnumerable<TaskResponseModel>> GetTasksByEmployeeId(int Id)
        {          
            //tasks: IEnumerable<Task>
            var tasks = await _employeeRepository.GetTasksByEmployee(Id);
            var taskList = new List<TaskResponseModel>();
            foreach (var task in tasks)
            {
                var taskReponseModel = new TaskResponseModel();
                taskReponseModel.TaskId = task.TaskId;
                taskReponseModel.StartTime = task.StartTime;
                taskReponseModel.Deadline = task.Deadline;
                taskReponseModel.TaskName = task.TaskName;
                taskReponseModel.EmployeeId = task.EmployeeId;
                taskList.Add(taskReponseModel);
            }      
            return taskList;
        }

        public async Task<EmployeeResponseModel> GetEmployeeById(int id)
        {
            var employeeDetails = new EmployeeResponseModel();
            var employee = await _employeeRepository.GetByIdAsync(id);

            employeeDetails.EmployeeId = employee.EmployeeId;
            employeeDetails.FirstName = employee.FirstName;
            employeeDetails.LastName = employee.LastName;
            employeeDetails.HiredDate = employee.HiredDate;

            employeeDetails.Tasks = new List<TaskResponseModel>();
            foreach(var task in employee.EmployeeTasks)
            {
                employeeDetails.Tasks.Add(new TaskResponseModel
                {
                    TaskId = task.TaskId,
                    StartTime = task.StartTime,
                    Deadline = task.Deadline
                });
                
            }
            return employeeDetails;

        }

    }


}
