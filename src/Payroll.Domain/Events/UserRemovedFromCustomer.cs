using Payroll.Domain.Interfaces;

namespace Payroll.Domain.Events
{
    public class UserRemovedFromCustomer : IPayrollEvent
    {
        public string CustomerId { get; set; }
    }
}