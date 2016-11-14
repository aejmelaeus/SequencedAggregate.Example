using Payroll.Domain;
using Payroll.Domain.Interfaces;

namespace Payroll.Integration
{
    public class PayrollApi : IPayrollApi
    {
        public void Synchronize(PayrollCustomer payrollCustomer)
        {
            // Do some nitty gritty transport details to get the stuff
            // over the wire to the other system.
        }
    }
}