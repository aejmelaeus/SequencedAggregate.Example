using System.Threading.Tasks;
using NServiceBus;

namespace Payroll.Endpoint.Handlers
{
    internal class ServiceRemovedFromCustomer : IHandleMessages<ServiceRemovedFromCustomer>
    {
        public Task Handle(ServiceRemovedFromCustomer message, IMessageHandlerContext context)
        {
            return Task.FromResult(0);
        }
    }
}