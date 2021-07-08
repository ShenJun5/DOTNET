using EmployeeTaskMonitor.Core.Models;
using System.Threading.Tasks;

namespace EmployeeTaskMonitor.Core.ServiceInterfaces
{
    public interface ITaskService
    {
        public TaskResponseModel GetTaskById(int Id);
        System.Threading.Tasks.Task AddTask(TaskRequestModel taskRequest);
        System.Threading.Tasks.Task RemoveTask(TaskRequestModel taskRequest);
        Task<TaskResponseModel> UpdateTask(TaskRequestModel taskRequest);
    }
}
