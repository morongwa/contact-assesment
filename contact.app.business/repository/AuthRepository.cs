using System;
using System.Linq;
using contact.app.business.context;
using contact.app.business.entity;

namespace contact.app.business.repository
{
    public class AuthRepository: IAuthRepository
    {
        private readonly WebCoreContext context;
        public AuthRepository(WebCoreContext _context)
        {
            context = _context;
        }

        private bool isDisposed = false;
        public void Dispose()
        {
            if (!isDisposed) {
                context.Dispose();
            }
            isDisposed = true;
        }

        public void Register(string username, string password, string email)
        {
            var objOnlineUser = new OnlineUser() {
                Username = username,
                Password = RepositoryCypher.Encrypt(password),
                DateCreated = DateTime.Now,
                Email = email
            };
            context.OnlineUsers.Add(objOnlineUser);
        }

        public bool SignIn(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password)) return false;

            var obj = GetByUsername(username);
            if (obj != null && obj.Count()>0) {
                var pass = RepositoryCypher.Encrypt(password);
                return (obj.First().Password == pass);
            }
            return false;
        }

        public OnlineUser GetById(int id) {
            return context.OnlineUsers.Find(id);
        }

        public IEnumerable<OnlineUser> GetByUsername(string username)
        {
            return context.OnlineUsers.Where(o=>o.Username == username).ToList();
        }

        public void Save() {
            context.SaveChanges();
        }
    }
}

