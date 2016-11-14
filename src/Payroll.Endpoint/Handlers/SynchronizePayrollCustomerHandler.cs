using System.Threading.Tasks;
using NServiceBus;
using Payroll.Domain.Interfaces;

namespace Payroll.Endpoint.Handlers
{
    internal class SynchronizePayrollCustomerHandler : IHandleMessages<SynchronizePayrollCustomer>
    {
        private readonly IPayrollRepository _payrollRepository;
        private readonly IPayrollApi _payrollApi;

        public SynchronizePayrollCustomerHandler(IPayrollRepository payrollRepository, IPayrollApi payrollApi)
        {
            _payrollRepository = payrollRepository;
            _payrollApi = payrollApi;
        }

        public Task Handle(SynchronizePayrollCustomer message, IMessageHandlerContext context)
        {
            var customer = _payrollRepository.GetCustomerById(message.Id);
            return _payrollApi.SynchronizeAsync(customer);
        }
    }
}