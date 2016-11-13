namespace Payroll.Domain.Interfaces
{
    public interface IPayrollRepository
    {
        PayrollCustomer GetCustomerById(string id);
        void Commit(PayrollCustomer payrollCustomer);
        PayrollUser GetUserById(string id);
    }
}
