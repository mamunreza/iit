using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskPlanner.Data.Interface;
using TaskPlanner.ViewModels;

namespace TaskPlanner.Data.Mocks
{
    public class MockTaskRotationRepository : ITaskRotationRepository
    {
        public void Create(TaskRotationViewModel vm)
        {
            
        }

        public ICollection<TaskRotationViewModel> List()
        {
            var vm = new List<TaskRotationViewModel>
            {
                new TaskRotationViewModel{Name="Hourly"},
                new TaskRotationViewModel{Name="Daily"},
                new TaskRotationViewModel{Name="Weekly"},
                new TaskRotationViewModel{Name="Monthly"}
            };

            return vm;
            
        }
    }
}
