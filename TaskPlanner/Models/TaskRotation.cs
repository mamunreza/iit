using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskPlanner.Models
{
    public class TaskRotation
    {
        [BindNever]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TaskRotationId { get; set; }

        [Required(ErrorMessage = "Please enter task rotation name")]
        [Display(Name = "Task rotation name")]
        [StringLength(100)]
        public string Name { get; set; }

    }
}
