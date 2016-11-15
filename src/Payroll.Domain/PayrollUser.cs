using System;
using Payroll.Domain.Events;
using System.Collections.Generic;

namespace Payroll.Domain
{
    public class PayrollUser : PayrollAggregate
    {
        private readonly HashSet<string> _customerIds = new HashSet<string>();

        public Guid Id { get; }

        public IEnumerable<string> CustomerIds => _customerIds;
        
        public PayrollUser(Guid id)
        {
            Id = id;

            RegisterTransition<UserAddedToCustomer>(Transition);
            RegisterTransition<UserRemovedFromCustomer>(Transition);
        }

        private void Transition(UserAddedToCustomer @event)
        {
            _customerIds.Add(@event.CustomerId);
        }

        private void Transition(UserRemovedFromCustomer @event)
        {
            _customerIds.Remove(@event.CustomerId);
        }
    }
}