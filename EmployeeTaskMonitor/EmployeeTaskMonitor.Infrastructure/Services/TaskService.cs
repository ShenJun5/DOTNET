using EmployeeTaskMonitor.Core.Entities;
using EmployeeTaskMonitor.Core.Models;
using EmployeeTaskMonitor.Core.RepositoryInterfaces;
using EmployeeTaskMonitor.Core.ServiceInterfaces;


namespace EmployeeTaskMonitor.Infrastructure.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

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
    }
}
