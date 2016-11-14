using System;
using Payroll.Domain.Interfaces;

namespace Payroll.Domain.Events
{
    internal class RoleAddedToUser : IPayrollEvent
    {
        public string Role { get; set; }
        public Guid UserId { get; set; }
    }
}