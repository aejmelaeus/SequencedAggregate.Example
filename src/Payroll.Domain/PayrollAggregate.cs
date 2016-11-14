using System;
using System.Collections.Generic;
using Payroll.Domain.Interfaces;

namespace Payroll.Domain
{
    public abstract class PayrollAggregate
    {
        protected readonly List<IPayrollEvent> _uncommittedEvents = new List<IPayrollEvent>();
        private readonly Dictionary<Type, Action<IPayrollEvent>> _routes = new Dictionary<Type, Action<IPayrollEvent>>();

        public IEnumerable<IPayrollEvent> UncommittedEvents => _uncommittedEvents;

        public void ApplyEvent(IPayrollEvent payrollEvent)
        {
            var eventType = payrollEvent.GetType();

            if (_routes.ContainsKey(eventType))
            {
                _routes[eventType](payrollEvent);
            }
        }

        public void ClearUncommittedEvents()
        {
            _uncommittedEvents.Clear();
        }

        protected void RegisterTransition<T>(Action<T> transition) where T : class
        {
            _routes.Add(typeof(T), o => transition(o as T));
        }
    }
}