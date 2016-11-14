namespace Payroll.Domain.Events
{
    internal class PayrollAddedToCustomer
    {
        public string CustomerName { get; set; }
        public string VatId { get; set; }
    }
}