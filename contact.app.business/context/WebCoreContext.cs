using System;
using contact.app.business.entity;
using Microsoft.EntityFrameworkCore;

namespace contact.app.business.context
{
    public class WebCoreContext: DbContext
    {
        public WebCoreContext(DbContextOptions<WebCoreContext> options): base(options) { }

        public DbSet<OnlineUser> OnlineUsers { get; set; }
        public DbSet<AddressCountry> AddressCountries { get; set; }
        public DbSet<AddressProvince> AddressProvinces { get; set; }
        public DbSet<NamedGroup> NamedGroups { get; set; }
        public DbSet<StatusContact> StatusContacts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<OnlineUserNamedGroup> OnlineUserNamedGroups { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) {
            builder.Entity<OnlineUser>().ToTable("OnlineUser");
            builder.Entity<AddressCountry>().ToTable("AddressCountry");
            builder.Entity<AddressProvince>().ToTable("AddressProvince");
            builder.Entity<NamedGroup>().ToTable("NamedGroup");
            builder.Entity<StatusContact>().ToTable("StatusContact");
            builder.Entity<Contact>().ToTable("Contact");
            builder.Entity<OnlineUserNamedGroup>().ToTable("OnlineUserNamedGroup");

            builder.Entity<OnlineUser>().Property(o => o.Username).IsRequired(true);
            builder.Entity<OnlineUser>().Property(o => o.Password).IsRequired(true);

            builder.Entity<Contact>().Property(o => o.Firstname).IsRequired(true);
            builder.Entity<Contact>().Property(o => o.Surname).IsRequired(true);

            builder.Entity<Contact>().Property(o => o.AddressStreet).IsRequired(false);
            builder.Entity<Contact>().Property(o => o.AddressSuburb).IsRequired(false);

            builder.Entity<NamedGroup>().Property(o => o.Name).IsRequired(true);

            builder.Entity<OnlineUserNamedGroup>().Property(o => o.OnlineUserId).IsRequired(true);
            builder.Entity<OnlineUserNamedGroup>().Property(o => o.NamedGroupId).IsRequired(true);
            builder.Entity<OnlineUserNamedGroup>().Property(o => o.ContactId).IsRequired(true);
        }
    }
}

