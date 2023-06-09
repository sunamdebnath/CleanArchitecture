﻿using HR.LeaveManagement.Application.Features.LeaveType.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.UpdateLeaveType
{
    public class UpdateLeaveTypeCommand : BaseLeaveTypeRequest, IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
