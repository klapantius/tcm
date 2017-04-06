using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestControllerManager.ViewModel
{
    public interface ITestAgentViewModel
    {
        string Name { get; }
        string Status { get; }
        bool? Scheduled { get; set; }
        string StatusDetails { get; }

        void DeleteSchedule();
    }
}
