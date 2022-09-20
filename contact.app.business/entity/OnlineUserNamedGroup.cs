using System;
namespace contact.app.business.entity
{
    public class OnlineUserNamedGroup
    {
        public int OnlineUserNamedGroupId { get; set; }
        public int ContactId { get; set; }
        public int OnlineUserId { get; set; }
        public int NamedGroupId { get; set; }
        public int? CreatedByOnlineUserId { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}

