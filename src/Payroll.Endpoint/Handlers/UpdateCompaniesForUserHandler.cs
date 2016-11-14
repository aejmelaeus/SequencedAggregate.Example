using System.Threading.Tasks;
using NServiceBus;
using Payroll.Endpoint.Commands;

namespace Payroll.Endpoint.Handlers
{
    internal class UpdateCompaniesForUserHandler : IHandleMessages<UpdateCompaniesForUser>
    {
        public Task Handle(UpdateCompaniesForUser message, IMessageHandlerContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}