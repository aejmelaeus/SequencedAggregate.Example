using System;
using System.Linq;
using NServiceBus;
using System.Threading.Tasks;
using Core.Endpoint.Messages.Events;
using Payroll.Domain.Events;
using Payroll.Domain.Interfaces;

namespace Payroll.Endpoint.Handlers
{
    internal class UsersDisconnectedFromServiceOnCustomerHandler : IHandleMessages<UsersDisconnectedFromServiceOnCustomer>
    {
        private readonly IPayrollRepository _payrollRepository;

        public UsersDisconnectedFromServiceOnCustomerHandler(IPayrollRepository payrollRepository)
        {
            _payrollRepository = payrollRepository;
        }

        public Task Handle(UsersDisconnectedFromServiceOnCustomer message, IMessageHandlerContext context)
        {
            var id = message.CustomerId;
            var sequenceAnchor = message.TimeStamp.Ticks;
            var messageId = Guid.Parse(context.MessageId);
            var events = message.UserIds.Select(u => new UserRemoved(u));

            _payrollRepository.CommitEvents(id, sequenceAnchor, messageId, events);

            return Task.FromResult(0);
        }
    }
}