using System;

namespace User.Endpoint.Messages
{
    public class UserUpdated
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
