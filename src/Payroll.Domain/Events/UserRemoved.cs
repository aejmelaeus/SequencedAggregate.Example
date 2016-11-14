using System;
using Payroll.Domain.Interfaces;

namespace Payroll.Domain.Events
{
    public class UserRemoved : IPayrollEvent
    {
        public UserRemoved(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}