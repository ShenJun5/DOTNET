using EmployeeTaskMonitor.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeTaskMonitor.Core.Models
{
    public class EmployeeResponseModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime HiredDate { get; set; }
        public List<TaskResponseModel> Tasks { get; set; }

    }


    public class TaskResponseModel
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string TaskName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime Deadline { get; set; }
    }

}
