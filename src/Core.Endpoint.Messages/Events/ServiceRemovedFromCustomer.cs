namespace Core.Endpoint.Messages.Events
{
    public class ServiceRemovedFromCustomer
    {
        public string ServiceId { get; set; }
        public string CustomerId { get; set; }
    }
}
