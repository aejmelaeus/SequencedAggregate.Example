using System;
using System.Collections.Generic;
using Payroll.Domain;
using Payroll.Domain.Interfaces;

namespace Payroll.Repository
{
    public class PayrollRepository : IPayrollRepository
    {
        private readonly ISequencedEventStore _sequencedEventStore;

        public PayrollRepository(ISequencedEventStore sequencedEventStore)
        {
            _sequencedEventStore = sequencedEventStore;
        }

        public PayrollCustomer GetCustomerById(string id)
        {
            var payrollCustomer = new PayrollCustomer(id);

            var events = _sequencedEventStore.GetById<IPayrollEvent>(id);

            foreach (var payrollEvent in events)
            {
                payrollCustomer.ApplyEvent(payrollEvent);
            }

            return payrollCustomer;
        }

        public void Commit(PayrollCustomer payrollCustomer)
        {
            _sequencedEventStore.CommitEvents(payrollCustomer.Id, payrollCustomer.UncommittedEvents);
            payrollCustomer.ClearUncommittedEvents();
        }

        public void CommitEvent(string id, long sequenceAnchor, Guid messageId, IPayrollEvent @event)
        {
            CommitEvents(id, sequenceAnchor, messageId, new [] { @event });   
        }

        public void CommitEvents(string id, long sequenceAnchor, Guid messageId, IEnumerable<IPayrollEvent> events)
        {
            _sequencedEventStore.CommitEvents(id, sequenceAnchor, messageId, events);
        }

        public PayrollUser GetUserById(Guid id)
        {
            var payrollUser = new PayrollUser(id);

            var events = _sequencedEventStore.GetById<IPayrollEvent>(id.ToString());

            foreach (var payrollEvent in events)
            {
                payrollUser.ApplyEvent(payrollEvent);
            }
            
            return payrollUser;
        }
    }
}

