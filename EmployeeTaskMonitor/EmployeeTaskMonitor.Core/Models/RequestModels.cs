using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace EmployeeTaskMonitor.Core.Models
{
    public class EmployeeRequestModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(150)]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime HiredDate { get; set; }

        //1 Employee - many Tasks
        public List<TaskResponseModel> Tasks { get; set; }
    }


    public class TaskRequestModel
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string TaskName { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartTime { get; set; }

        [DataType(DataType.Date)]
        public DateTime Deadline { get; set; }
    }

}
