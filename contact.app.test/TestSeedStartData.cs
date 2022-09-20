using System;
using System.Linq;
using System.Data.Common;
using contact.app.business.context;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace contact.app.test
{
    public class TestSeedStartData: IDisposable
    {

        private readonly DbConnection _connection;
        private readonly DbContextOptions<WebCoreContext> _contextOptions;

        public TestSeedStartData() {
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

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_SeedProvinceData()
        {
            business.tools.SeedStartData.AddressProvinceData(GetContext());

            var data = GetContext().AddressProvinces.ToList();
            var iCountSeedData = 1;

            Assert.That(data.Count, Is.GreaterThanOrEqualTo(iCountSeedData));
        }

        [Test]
        public void Test_SeedCountryData()
        {
            business.tools.SeedStartData.AddressCountryData(GetContext());

            var data = GetContext().AddressCountries.ToList();
            var iCountSeedData = 1;

            Assert.That(data.Count, Is.GreaterThanOrEqualTo(iCountSeedData));
        }

        [Test]
        public void Test_SeedStatusContactData()
        {
            business.tools.SeedStartData.StatusContactData(GetContext());

            var data = GetContext().StatusContacts.ToList();
            var iCountSeedData = 1;

            Assert.That(data.Count, Is.GreaterThanOrEqualTo(iCountSeedData));
        }

        [Test]
        public void Test_SeedNamedGroupData()
        {
            business.tools.SeedStartData.NamedGroupData(GetContext());

            var data = GetContext().NamedGroups.ToList();
            var iCountSeedData = 1;

            Assert.That(data.Count, Is.GreaterThanOrEqualTo(iCountSeedData));
        }
    }
}

