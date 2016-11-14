namespace Core.Endpoint.Messages.Events
{
    public class ServiceAddedToCustomer
    {
        public Customer Customer { get; set; }
        public string ServiceId { get; set; }
    }
}
