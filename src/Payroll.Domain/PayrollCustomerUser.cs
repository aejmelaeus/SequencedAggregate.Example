using System;
using System.Collections.Generic;

namespace Payroll.Domain
{
    public class PayrollCustomerUser
    {
        private readonly HashSet<string> _roles = new HashSet<string>();

        public PayrollCustomerUser(Guid id)
        {
            Id = id;
        }

        public PayrollCustomerUser(Guid id, string firstName, string lastName, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public Guid Id { get; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public IEnumerable<string> Roles => _roles;

        public void AddRole(string role)
        {
            _roles.Add(role);
        }

        public void RemoveRole(string role)
        {
            _roles.Remove(role);
        }
    }
}