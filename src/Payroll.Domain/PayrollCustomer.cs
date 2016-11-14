using System;
using Payroll.Domain.Events;
using Payroll.Domain.Interfaces;
using System.Collections.Generic;

namespace Payroll.Domain
{
    public class PayrollCustomer : PayrollAggregate
    {
        private readonly Dictionary<Guid, PayrollCustomerUser> _users = new Dictionary<Guid, PayrollCustomerUser>();

        public string Id { get; }
        public string Name { get; set; }
        public string VatId { get; set; }
        public string PayrollConfiguration { get; private set; }
        
        public IEnumerable<PayrollCustomerUser> Users => _users.Values;

        public PayrollCustomer(string id)
        {
            Id = id;

            RegisterTransition<PayrollConfigured>(Transition);
            RegisterTransition<RoleAddedToUser>(Transition);
            RegisterTransition<RoleRemovedFromUser>(Transition);
            RegisterTransition<UserAdded>(Transition);
            RegisterTransition<UserRemoved>(Transition);
            RegisterTransition<PayrollAddedToCustomer>(Transition);
        }

        public void SetPayrollConfiguration(string payrollConfiguration)
        {
            // Here it is OK to deny an event, sice we are working in real time!
            if (ConfigurationIsValid(payrollConfiguration))
            {
                RaiseEvent(new PayrollConfigured {Configuration = payrollConfiguration});
            }
        }

        public void AddRoleToUser(string role, Guid userId)
        {
            if (_users.ContainsKey(userId))
            {
                RaiseEvent(new RoleAddedToUser { Role = role, UserId = userId });
            }
        }

        public void RemoveRoleFromUser(string role, Guid userId)
        {
            if (_users.ContainsKey(userId))
            {
                RaiseEvent(new RoleRemovedFromUser { Role = role, UserId = userId });
            }
        }

        private bool ConfigurationIsValid(string payrollConfiguration)
        {
            /*
            ** Do some fancy validation!
            */
            return true;
        }

        #region Aggregate stuff
        
        private void RaiseEvent(IPayrollEvent payrollEvent)
        {
            ApplyEvent(payrollEvent);
            _uncommittedEvents.Add(payrollEvent);
        }
        
        #endregion // #region Aggregate stuff

        #region Transitions

        private void Transition(PayrollConfigured payrollConfigured)
        {
            PayrollConfiguration = payrollConfigured.Configuration;
        }

        private void Transition(RoleAddedToUser @event)
        {
            if (_users.ContainsKey(@event.UserId))
            {
                _users[@event.UserId].AddRole(@event.Role);
            }
        }

        private void Transition(RoleRemovedFromUser @event)
        {
            if (_users.ContainsKey(@event.UserId))
            {
                _users[@event.UserId].RemoveRole(@event.Role);
            }
        }

        private void Transition(UserAdded @event)
        {
            if (!_users.ContainsKey(@event.Id))
            {
                _users.Add(@event.Id, new PayrollCustomerUser(@event.Id, @event.FirstName, @event.LastName, @event.Email));
            }
        }

        private void Transition(UserRemoved @event)
        {
            _users.Remove(@event.Id);
        }

        private void Transition(PayrollAddedToCustomer @event)
        {
            Name = @event.CustomerName;
            VatId = @event.VatId;
        }

        #endregion // #region Transitions
    }
}
