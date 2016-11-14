using System;
using Payroll.Domain.Interfaces;

namespace Payroll.Domain.Events
{
    internal class UserAdded : IPayrollEvent
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}