using System;
using System.Collections.Generic;

namespace Core.Endpoint.Messages.Events
{
    public class UsersDisconnectedFromServiceOnCustomer
    {
        public string ServiceId { get; set; }
        public IEnumerable<Guid> UserIds { get; set; }
        public string CustomerId { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}