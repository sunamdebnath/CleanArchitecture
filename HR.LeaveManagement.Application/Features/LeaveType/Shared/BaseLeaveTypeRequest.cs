using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Shared
{
    public abstract class BaseLeaveTypeRequest
    {
        public string Name { get; set; } = String.Empty;
        public int DefaultDays { get; set; }
    }
}
