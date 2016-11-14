using System.Threading.Tasks;

namespace Payroll.Domain.Interfaces
{
    public interface IPayrollApi
    {
        Task SynchronizeAsync(PayrollCustomer payrollCustomer);
    }
}
