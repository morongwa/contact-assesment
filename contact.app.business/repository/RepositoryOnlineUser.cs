using System;
using System.Security.Cryptography;
using contact.app.business.context;
using contact.app.business.entity;

namespace contact.app.business.repository
{
    public class RepositoryOnlineUser: IGenericRepository<OnlineUser>
    {
        private readonly WebCoreContext context;

        public RepositoryOnlineUser(WebCoreContext _context)
        {
            context = _context;
        }

        public IEnumerable<OnlineUser> All()
        {
            return context.OnlineUsers.ToList();
        }

        public void Create(OnlineUser obj, int? iCreatedById)
        {
            obj.Password = RepositoryCypher.Encrypt(obj.Password);
            context.OnlineUsers.Add(obj);
        }

        public void Delete(int id)
        {
            var obj = context.OnlineUsers.Find(id);
            if (obj != null) {
                context.OnlineUsers.Remove(obj);
            }
        }

        private bool isDisposed = false;
        public void Dispose()
        {
            if (!isDisposed) {
                context.Dispose();
            }
            isDisposed = true;
        }

        public IEnumerable<OnlineUser> Filter(Func<OnlineUser, bool> func)
        {
            return context.OnlineUsers.Where(func).ToList();
        }

        public OnlineUser GetById(int id)
        {
            return context.OnlineUsers.Find(id);
        }

        public void Update(OnlineUser obj)
        {
            context.OnlineUsers.Add(obj);
            context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void Save() {
            context.SaveChanges();
        }
    }
}

