using System;
using System.Collections.Generic;
using System.Text;


namespace EmployeeTaskMonitor.Core.Entities
{
    public class Task
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string TaskName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime Deadline { get; set; }
        public Employee Employee { get; set; }

    }
}
