﻿using HR.LeaveManagement.Application.Features.LeaveRequest.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Commands.CreateLeaveRequest
{
    public class CreateLeaveRequestCommand : BaseLeaveRequest, IRequest<int>
    {
        public string RequestComments { get; set; } = String.Empty;
    }
}
