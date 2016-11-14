using Payroll.Domain.Interfaces;

namespace Payroll.Domain.Events
{
    internal class UserAddedToCustomer : IPayrollEvent
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string CustomerId { get; set; }
    }
}