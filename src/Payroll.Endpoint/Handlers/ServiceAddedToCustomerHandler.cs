using NServiceBus;
using System.Threading.Tasks;
using Core.Endpoint.Messages.Events;

namespace Payroll.Endpoint.Handlers
{
    internal class ServiceAddedToCustomerHandler : IHandleMessages<ServiceAddedToCustomer>
    {
        public Task Handle(ServiceAddedToCustomer message, IMessageHandlerContext context)
        {
            return Task.FromResult(0);
        }
    }
}
