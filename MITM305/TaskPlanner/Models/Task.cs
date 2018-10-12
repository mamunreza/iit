using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.ComponentModel.DataAnnotations;

namespace TaskPlanner.Models
{
    public class Task
    {
        [BindNever]
        public int TaskId { get; set; }

        [Required(ErrorMessage = "Please enter task name")]
        [Display(Name = "Task rotation name")]
        [StringLength(100)]
        public string TaskName { get; set; }
        public DateTime DueDate { get; set; }
        public int TaskRotationId { get; set; }
        public TaskRotation TaskRotation { get; set; }
        public bool Active { get; set; }
    }
}
