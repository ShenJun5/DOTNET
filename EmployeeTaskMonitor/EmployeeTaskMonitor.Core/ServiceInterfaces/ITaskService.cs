using EmployeeTaskMonitor.Core.Entities;
using EmployeeTaskMonitor.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeTaskMonitor.Core.ServiceInterfaces
{
    public interface ITaskService
    {
        public TaskResponseModel GetTaskById(int Id);
    }
}
