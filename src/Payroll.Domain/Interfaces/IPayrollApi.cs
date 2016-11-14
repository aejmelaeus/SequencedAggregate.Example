namespace Payroll.Domain.Interfaces
{
    public interface IPayrollApi
    {
        void Synchronize(PayrollCustomer payrollCustomer);
    }
}
