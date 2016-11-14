using System;
using System.Collections.Generic;

namespace Payroll.Domain.Interfaces
{
    public interface IPayrollRepository
    {
        PayrollCustomer GetCustomerById(string id);
        void Commit(PayrollCustomer payrollCustomer);
        void CommitEvents(string id, long sequenceAnchor, Guid messageId, IEnumerable<IPayrollEvent> events);
        PayrollUser GetUserById(Guid id);
    }
}
