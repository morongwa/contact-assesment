using System;
using System.ComponentModel.DataAnnotations;

namespace contact.app.business.entity
{
    public class Contact
    {
        public int ContactId { get; set; }

        [Required(ErrorMessage = "Firstname is required")]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "Surname is required")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "Must be a valid email")]
        public string ContactEmail { get; set; }

        [Required(ErrorMessage = "ContactPhone is required")]
        public string ContactPhone { get; set; }

        public string AddressStreet { get; set; }
        public string AddressSuburb { get; set; }

        public int? AddressProvinceId { get; set; }
        public int? AddressCountryId { get; set; }
        public int? ContactStatusId { get; set; }
        public int? CreatedByOnlineUserId { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}

