using System;
using contact.app.business.context;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using contact.app.business.repository;
using contact.app.business.entity;

namespace contact.app.test
{
    public class Test_Contact_CRUD
    {
        private readonly DbConnection _connection;
        private readonly DbContextOptions<WebCoreContext> _contextOptions;


        public Test_Contact_CRUD()
        {
            // Create and open a connection. This creates the SQLite in-memory database, which will persist until the connection is closed
            // at the end of the test (see Dispose below).
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();

            // These options will be used by the context instances in this test suite, including the connection opened above.
            _contextOptions = new DbContextOptionsBuilder<WebCoreContext>()
                .UseSqlite(_connection)
                .Options;

            using (var context = GetContext())
            {
                context.Database.EnsureCreated();
            }
        }

        public void Dispose() => _connection.Dispose();
        WebCoreContext GetContext() => new WebCoreContext(_contextOptions);

        [Test]
        public void Test_Contact_Create() {
            RepositoryContact repository = new RepositoryContact(GetContext());
            repository.Create(new Contact()
            {
                ContactId = 1,
                Firstname = "Morongwa",
                Surname = "Ramputa",
                ContactEmail = "jramputa@gmail.com",
                ContactPhone = "+27729601643",
                AddressStreet = "1016 Jan Shoba",
                AddressSuburb = "Brooklyn",
                AddressProvinceId = 1,
                AddressCountryId = 1,
                CreatedByOnlineUserId = 1,
                DateCreated = DateTime.Now
            },1);
            repository.Save();
            var obj = repository.GetById(1);


            Assert.IsNotNull(obj);
            Assert.That(obj.Firstname, Is.EqualTo("Morongwa"));
            Assert.That(obj.ContactId, Is.EqualTo(1));
        }

        [Test]
        public void Test_Contact_Update()
        {
            RepositoryContact repository = new RepositoryContact(GetContext());
            var contact = new Contact()
            {
                ContactId = 2,
                Firstname = "Kgaugelo",
                Surname = "Mahlangu",
                ContactEmail = "jramputa@gmail.com",
                ContactPhone = "+27729601643",
                AddressStreet = "1016 Jan Shoba",
                AddressSuburb = "Brooklyn",
                AddressProvinceId = 1,
                AddressCountryId = 1,
                CreatedByOnlineUserId = 1,
                DateCreated = DateTime.Now
            };
            repository.Create(contact,1);
            repository.Save();


            var sNewName = "Keabetswe";
            var sNewNumber = "+27823456789";
            contact.Firstname = sNewName;
            contact.ContactPhone = sNewNumber;

            repository.Update(contact);
            repository.Save();

            var obj = repository.GetById(2);

            Assert.IsNotNull(obj);
            Assert.That(obj.Firstname, Is.EqualTo(sNewName));
            Assert.That(obj.ContactPhone, Is.EqualTo(sNewNumber));
            Assert.That(obj.ContactId, Is.EqualTo(2));
        }

        [Test]
        public void Test_Contact_Delete()
        {
            RepositoryContact repository = new RepositoryContact(GetContext());
            var contact = new Contact()
            {
                ContactId = 3,
                Firstname = "Gugu",
                Surname = "GUmede",
                ContactEmail = "gugu.g@gmail.com",
                ContactPhone = "+27729601643",
                AddressStreet = "1016 Jan Shoba",
                AddressSuburb = "Brooklyn",
                AddressProvinceId = 1,
                AddressCountryId = 1,
                CreatedByOnlineUserId = 1,
                DateCreated = DateTime.Now
            };

            repository.Create(contact,1);
            repository.Save();

            repository.Delete(3);
            repository.Save();

            var obj = repository.GetById(3);


            Assert.IsNull(obj);
        }
    }
}

