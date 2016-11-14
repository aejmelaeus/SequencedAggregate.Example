using System.Collections.Generic;

namespace Core.Endpoint.Messages.Events
{
    public class UsersConnectedToServiceOnCustomer
    {
        public string ServiceId { get; set; }
        public IEnumerable<CustomerUser> CustomerUsers { get; set; }
    }
}
