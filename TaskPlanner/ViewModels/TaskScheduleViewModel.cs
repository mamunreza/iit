using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskPlanner.ViewModels
{
    public class TaskScheduleViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Task Name")]
        public string TaskName { get; set; }

        [Display(Name = "Due Date")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy HH:mm:ss}")]
        public DateTime DueDate { get; set; }

        [Display(Name = "Remaining Time")]
        public string TimeRemaining { get; set; }

        [Display(Name = "Complete")]
        public bool IsComplete { get; set; }
    }
}
