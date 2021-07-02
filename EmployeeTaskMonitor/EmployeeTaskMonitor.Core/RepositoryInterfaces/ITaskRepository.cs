using EmployeeTaskMonitor.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeTaskMonitor.Core.RepositoryInterfaces
{
    public interface ITaskRepository: IAsyncRepository<Task>
    {

    }
}
