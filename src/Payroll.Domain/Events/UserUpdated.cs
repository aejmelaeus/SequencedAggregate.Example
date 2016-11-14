using Payroll.Domain.Interfaces;

namespace Payroll.Domain.Events
{
    public class UserUpdated : IPayrollEvent
    {
        public UserUpdated(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}