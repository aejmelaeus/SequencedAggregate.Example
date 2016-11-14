using System;
using Payroll.Domain.Events;
using System.Collections.Generic;

namespace Payroll.Domain
{
    public class PayrollUser : PayrollAggregate
    {
        private readonly HashSet<string> _customerIds = new HashSet<string>();

        public Guid Id { get; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public IEnumerable<string> CustomerIds => _customerIds;
        
        public PayrollUser(Guid id)
        {
            Id = id;

            RegisterTransition<UserAddedToCustomer>(Transition);
            RegisterTransition<UserRemovedFromCustomer>(Transition);
            RegisterTransition<UserUpdated>(Transition);
        }

        private void Transition(UserAddedToCustomer @event)
        {
            FirstName = @event.FirstName;
            LastName = @event.LastName;
            Email = @event.Email;
            _customerIds.Add(@event.CustomerId);
        }

        private void Transition(UserRemovedFromCustomer @event)
        {
            _customerIds.Remove(@event.CustomerId);
        }

        private void Transition(UserUpdated @event)
        {
            FirstName = @event.FirstName;
            LastName = @event.LastName;
            Email = @event.Email;
        }
    }
}