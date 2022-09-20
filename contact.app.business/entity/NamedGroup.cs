using System;
namespace contact.app.business.entity
{
    public class NamedGroup
    {
        public int NamedGroupId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? CreatedByOnlineUserId { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}

