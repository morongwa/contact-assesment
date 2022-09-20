using System;
using contact.app.business.context;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using contact.app.business.repository;

namespace contact.app.test
{
    public class Test_AuthRepository : IDisposable
    {

        private readonly DbConnection _connection;
        private readonly DbContextOptions<WebCoreContext> _contextOptions;
        

        public Test_AuthRepository()
        {
            // Create and open a connection. This creates the SQLite in-memory database, which will persist until the connection is closed
            // at the end of the test (see Dispose below).
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();

            // These options will be used by the context instances in this test suite, including the connection opened above.
            _contextOptions = new DbContextOptionsBuilder<WebCoreContext>()
                .UseSqlite(_connection)
                .Options;

            using (var context = GetContext()) {
                context.Database.EnsureCreated();
            }
        }

        public void Dispose() => _connection.Dispose();
        WebCoreContext GetContext() => new WebCoreContext(_contextOptions);


        [Test]
        public void Test_AuthRegister()
        {
            IAuthRepository repository = new AuthRepository(GetContext());
            repository.Register("hello", "hello123", "email@home.com");
            repository.Save();
            var objOnlineUser = repository.GetByUsername("hello");

            Assert.That(objOnlineUser.Count, Is.EqualTo(1));
            Assert.That(objOnlineUser.First().Username, Is.EqualTo("hello"));
        }

        [Test]
        public void Test_SignIn()
        {
            IAuthRepository repository = new AuthRepository(GetContext());
            repository.Register("signin", "hello123", "email@home.com");
            repository.Save();
            var result = repository.SignIn("signin","hello123");

            Assert.That(result, Is.EqualTo(true));
        }
    }
}

