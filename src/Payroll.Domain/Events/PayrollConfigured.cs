using Payroll.Domain.Interfaces;

namespace Payroll.Domain.Events
{
    internal class PayrollConfigured : IPayrollEvent
    {
        public string Configuration { get; set; }
    }
}
