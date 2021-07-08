using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeTaskMonitor.Core.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime HiredDate { get; set; }

        //1 Employee - many Tasks
        public ICollection<Task> EmployeeTasks { get; set; }
    }
}
