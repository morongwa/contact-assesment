using System;
using System.ComponentModel.DataAnnotations;
using contact.app.business.entity;

namespace contact.app.mvc.Models
{
    public class ModelContact
    {
        public ModelContact() {
            ContactEntity = new Contact();
            Countries = new List<AddressCountry>();
            Provinces = new List<AddressProvince>();

        }
        public Contact ContactEntity { get; set; }
        public IEnumerable<AddressCountry> Countries { get; set; }
        public IEnumerable<AddressProvince> Provinces { get; set; }
    }
}

