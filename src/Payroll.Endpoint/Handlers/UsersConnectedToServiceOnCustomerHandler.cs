using NServiceBus;
using System.Threading.Tasks;
using Core.Endpoint.Messages.Events;

namespace Payroll.Endpoint.Handlers
{
    internal class UsersConnectedToServiceOnCustomerHandler : IHandleMessages<UsersConnectedToServiceOnCustomer>
    {
        public Task Handle(UsersConnectedToServiceOnCustomer message, IMessageHandlerContext context)
        {
            return Task.FromResult(0);
        }
    }
}