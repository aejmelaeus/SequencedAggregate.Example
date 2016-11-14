using Payroll.Domain;
using System.Threading.Tasks;
using Payroll.Domain.Interfaces;

namespace Payroll.Integration
{
    public class PayrollApi : IPayrollApi
    {
        public Task SynchronizeAsync(PayrollCustomer payrollCustomer)
        {
            // Do some nitty gritty transport details to get the stuff
            // over the wire to the other system.
            return Task.FromResult(0);
        }
    }
}