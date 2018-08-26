using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.ComponentModel.DataAnnotations;

namespace TaskPlanner.Models
{
    public class TaskHistory
    {
        [BindNever]
        public int TaskHistoryId { get; set; }
        [Required(ErrorMessage = "Please select task name")]
        public int TaskId { get; set; }
        [Required(ErrorMessage = "Please provide task completion date")]
        public Task Task { get; set; }
        public DateTime CompletionDate { get; set; }
    }
}
