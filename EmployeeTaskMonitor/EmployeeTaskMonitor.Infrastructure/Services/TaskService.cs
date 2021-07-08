using EmployeeTaskMonitor.Core.Entities;
using EmployeeTaskMonitor.Core.Models;
using EmployeeTaskMonitor.Core.RepositoryInterfaces;
using EmployeeTaskMonitor.Core.ServiceInterfaces;
using AutoMapper;


namespace EmployeeTaskMonitor.Infrastructure.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
      

        public TaskResponseModel GetTaskById(int Id)
        {
            var taskDetails = new TaskResponseModel();
            var task = _taskRepository.GetByIdAsync(Id);
            return taskDetails;
        }

        public async System.Threading.Tasks.Task AddTask(TaskRequestModel taskRequest)
        {
            //var taskToAdd = _mapper.Map<Task>(taskRequest);
            //var employeeId = taskRequest.EmployeeId;
            //var employee = _employeeService.GetEmployeeById(employeeId);

            var task = new Task
            {
                Id = taskRequest.Id,
                EmployeeId = taskRequest.EmployeeId,
                TaskName = taskRequest.TaskName,
                StartTime = taskRequest.StartTime,
                Deadline = taskRequest.Deadline
            };
            
            var createdTask = await _taskRepository.AddAsync(task);
        }

        public async System.Threading.Tasks.Task RemoveTask(TaskRequestModel taskRequest)
        {
            var tasks = await _taskRepository.ListAsync(t => t.Id == taskRequest.Id);
            foreach (var task in tasks)
            {
                await _taskRepository.DeleteAsync(task);
            }
        }

        public async System.Threading.Tasks.Task<TaskResponseModel> UpdateTask(TaskRequestModel taskRequest)
        {
            var task = _mapper.Map<Task>(taskRequest);
            var createdTask = await _taskRepository.UpdateAsync(task);
            var response = _mapper.Map<TaskResponseModel>(task);
            return response;
        }
    }
}
