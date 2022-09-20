using System;
namespace contact.app.business.entity
{
    public class OnlineUser
    {
        public int OnlineUserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? DateCreated { get; set; }
        public bool? Active { get; set; }
    }
}

