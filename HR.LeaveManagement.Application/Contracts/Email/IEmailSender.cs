using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.LeaveManagement.Application.Models;

namespace HR.LeaveManagement.Application.Contracts.Email
{
    public interface IEmailSender
    {
        public Task<bool> SendEmail(EmailMessage email);
    }
}
