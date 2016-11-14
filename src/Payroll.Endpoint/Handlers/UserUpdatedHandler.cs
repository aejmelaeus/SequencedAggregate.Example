using System;
using NServiceBus;
using System.Threading.Tasks;
using User.Endpoint.Messages;
using Payroll.Domain.Interfaces;

namespace Payroll.Endpoint.Handlers
{
    internal class UserUpdatedHandler : IHandleMessages<UserUpdated>
    {
        private readonly IPayrollRepository _payrollRepository;

        public UserUpdatedHandler(IPayrollRepository payrollRepository)
        {
            _payrollRepository = payrollRepository;
        }

        public Task Handle(UserUpdated message, IMessageHandlerContext context)
        {
            var id = message.Id;
            var sequenceAnchor = message.TimeStamp.Ticks;
            var messageId = Guid.Parse(context.MessageId);
            var userUpdatedEvent = new Domain.Events.UserUpdated(message.FirstName, message.LastName, message.Email);
            
            _payrollRepository.CommitEvent(id.ToString(), sequenceAnchor, messageId, userUpdatedEvent );

            var user = _payrollRepository.GetUserById(id);

            foreach (var customerId in user.CustomerIds)
            {
                _payrollRepository.CommitEvent(customerId, sequenceAnchor, Guid.NewGuid(), userUpdatedEvent);
                context.Send(new SynchronizePayrollCustomer
                {
                    Id = customerId
                });
            }
        
            return Task.FromResult(0);
        }
    }
}
