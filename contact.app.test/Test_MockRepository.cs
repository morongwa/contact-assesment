using System;
using contact.app.business.entity;
using contact.app.business.repository;
using Moq;

namespace contact.app.test
{
    public class Test_MockRepository
    {
        public Test_MockRepository()
        {
        }

        [Test]
        public void Test_ContactGetAll() {
            var mock = new Mock<IGenericRepository<Contact>>();
            mock.Setup(r => r.All())
                .Returns(new List<Contact>() {
                    new Contact() {
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
                    },
                    new Contact()
                    {
                        ContactId = 2,
                        Firstname = "Mavis",
                        Surname = "Ramputa",
                        ContactEmail = "jramputa@gmail.com",
                        ContactPhone = "+27729601643",
                        AddressStreet = "1016 Jan Shoba",
                        AddressSuburb = "Brooklyn",
                        AddressProvinceId = 1,
                        AddressCountryId = 1,
                        CreatedByOnlineUserId = 1,
                        DateCreated = DateTime.Now
                    },
                    new Contact()
                    {
                        ContactId = 3,
                        Firstname = "Makoma",
                        Surname = "Ramputa",
                        ContactEmail = "jramputa@gmail.com",
                        ContactPhone = "+27729601643",
                        AddressStreet = "1016 Jan Shoba",
                        AddressSuburb = "Brooklyn",
                        AddressProvinceId = 1,
                        AddressCountryId = 1,
                        CreatedByOnlineUserId = 1,
                        DateCreated = DateTime.Now
                    }
                }
            );

            IGenericRepository<Contact> repository = mock.Object;
            var obj = repository.All();


            Assert.That(obj.Count, Is.EqualTo(3));
            Assert.That(obj.Where(o=>o.ContactId==1).First().Firstname, Is.EqualTo("Morongwa"));
            Assert.That(obj.Where(o => o.ContactId == 3).First().Firstname, Is.EqualTo("Makoma"));
        }

        [Test]
        public void Test_ContactGetById()
        {
            var mock = new Mock<IGenericRepository<Contact>>();
            mock.Setup(r => r.All())
                .Returns(new List<Contact>() {
                    new Contact() {
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
                    },
                    new Contact()
                    {
                        ContactId = 2,
                        Firstname = "Morongwa1",
                        Surname = "Ramputa",
                        ContactEmail = "jramputa@gmail.com",
                        ContactPhone = "+27729601643",
                        AddressStreet = "1016 Jan Shoba",
                        AddressSuburb = "Brooklyn",
                        AddressProvinceId = 1,
                        AddressCountryId = 1,
                        CreatedByOnlineUserId = 1,
                        DateCreated = DateTime.Now
                    },
                    new Contact()
                    {
                        ContactId = 3,
                        Firstname = "Morongwa2",
                        Surname = "Ramputa",
                        ContactEmail = "jramputa@gmail.com",
                        ContactPhone = "+27729601643",
                        AddressStreet = "1016 Jan Shoba",
                        AddressSuburb = "Brooklyn",
                        AddressProvinceId = 1,
                        AddressCountryId = 1,
                        CreatedByOnlineUserId = 1,
                        DateCreated = DateTime.Now
                    }
                }
            );

            mock.Setup(r => r.GetById(1)).Returns(
                new Contact()
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
                }
            );

            IGenericRepository<Contact> repository = mock.Object;
            var obj = repository.GetById(1);


            Assert.That(obj.ContactId, Is.EqualTo(1));
            Assert.That(obj.Firstname, Is.EqualTo("Morongwa"));
        }
    }
}

