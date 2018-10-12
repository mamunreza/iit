using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaskPlanner.Models;

namespace TaskPlanner.ViewModels
{
    public class TaskViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter task name")]
        [Display(Name = "Task Name")]
        [StringLength(100)]
        public string TaskName { get; set; }

        [Display(Name = "Due Date")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime DueDate { get; set; }

        [Display(Name = "Task Rotation")]
        public int TaskRotationId { get; set; }
        public TaskRotation TaskRotation { get; set; }

        [Display(Name = "Task Rotation")]
        public string TaskRotationName { get; set; }

        [Display(Name = "Active")]
        public bool Active { get; set; }

        [NotMapped]
        public SelectList ListOfTaskRotations { get; set; }
    }
}
