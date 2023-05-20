using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace HR.LeaveManagement.Application.Contracts.Exceptions
{
    public class NotFoundException : Exception
    {
        public IDictionary<string, string[]> ValidationErrors { get; set; }
        public NotFoundException(string name, object key) : base($"{name} ({key}) was not found")
        {

        }
        public NotFoundException(string message, ValidationResult validationResult) : base(message)
        {
            ValidationErrors = validationResult.ToDictionary();
        }
        
    }
}
