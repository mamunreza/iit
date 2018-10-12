using System.ComponentModel.DataAnnotations;

namespace TaskPlanner.ViewModels
{
    public class TaskRotationViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Task Rotation")]
        public string Name { get; set; }
    }
}
