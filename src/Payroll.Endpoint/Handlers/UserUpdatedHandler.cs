using System;
using NServiceBus;
using System.Threading.Tasks;
using Payroll.Domain.Interfaces;
using Payroll.Endpoint.Commands;
using User.Endpoint.Messages;

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
            var userUpdated = new Domain.Events.UserUpdated(message.FirstName, message.LastName, message.Email);
            
            _payrollRepository.CommitEvents(id.ToString(), sequenceAnchor, messageId, new []{ userUpdated });

            return context.Send(new UpdateCompaniesForUser
            {
                Id = id
            });
        }
    }
}
