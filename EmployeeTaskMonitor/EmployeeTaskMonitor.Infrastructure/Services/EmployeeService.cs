using EmployeeTaskMonitor.Core.Entities;
using EmployeeTaskMonitor.Core.Models;
using EmployeeTaskMonitor.Core.RepositoryInterfaces;
using EmployeeTaskMonitor.Core.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;


namespace EmployeeTaskMonitor.Infrastructure.Services
{
    public class EmployeeService : IEmployeeService
    {

        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        


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
                employeeCard.Id = employee.Id;
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
            var taskDetails= new List<TaskResponseModel>();
            foreach (var task in tasks)
            {
                taskDetails.Add(new TaskResponseModel
                {
                    Id = task.Id,
                    StartTime = task.StartTime,
                    Deadline = task.Deadline,
                    TaskName = task.TaskName,
                    EmployeeId = task.EmployeeId,
                });
            }      
            return taskDetails;
        }




        public async Task<EmployeeResponseModel> GetEmployeeById(int id)
        {
            var employeeDetails = new EmployeeResponseModel();
            var employee = await _employeeRepository.GetByIdAsync(id);

            employeeDetails.Id = employee.Id;
            employeeDetails.FirstName = employee.FirstName;
            employeeDetails.LastName = employee.LastName;
            employeeDetails.HiredDate = employee.HiredDate;

            employeeDetails.Tasks = new List<TaskResponseModel>();
            foreach(var task in employee.EmployeeTasks)
            {
                employeeDetails.Tasks.Add(new TaskResponseModel
                {
                    Id = task.Id,
                    EmployeeId = task.EmployeeId,
                    StartTime = task.StartTime,
                    Deadline = task.Deadline
                });
                
            }
            return employeeDetails;
        }

        public async System.Threading.Tasks.Task AddEmployee(EmployeeRequestModel employeeCreateRequest)
        {
            var employee = new Employee
            {
                Id = employeeCreateRequest.Id,
                FirstName = employeeCreateRequest.FirstName,
                LastName = employeeCreateRequest.LastName,
                HiredDate = employeeCreateRequest.HiredDate
            };
            var createEmployee = await _employeeRepository.AddAsync(employee);
        }

        public async System.Threading.Tasks.Task RemoveEmployee(EmployeeRequestModel employeeRequest)
        {
            var employees = await _employeeRepository.ListAsync(e => e.Id == employeeRequest.Id);
            foreach(var employee in employees)
            {
                await _employeeRepository.DeleteAsync(employee);
            }          
        }

        public async Task<EmployeeResponseModel> UpdateEmployee(EmployeeRequestModel employeeRequest)
        {
            var employee = _mapper.Map<Employee>(employeeRequest);
            var createdEmployee = await _employeeRepository.UpdateAsync(employee);
            var response = _mapper.Map<EmployeeResponseModel>(employee);
            return response;
        }

    }
}
