using System;
using contact.app.business.entity;
using contact.app.business.context;

namespace contact.app.business.repository
{
    public class RepositoryContact: IGenericRepository<Contact>
    {

        private readonly WebCoreContext context;
        public RepositoryContact(WebCoreContext _context)
        {
            context = _context;
        }

        public IEnumerable<Contact> All()
        {
            return context.Contacts.ToList();
        }

        public IEnumerable<Contact> OnlineUserContacts(int iOnlineUserId)
        {
            return context.Contacts.Where(o=> o.CreatedByOnlineUserId==iOnlineUserId).ToList();
        }

        public void Create(Contact obj, int? iCreatedById)
        {
            obj.ContactStatusId = 1;
            obj.CreatedByOnlineUserId = iCreatedById;
            obj.DateCreated = DateTime.Now;
            context.Contacts.Add(obj);
        }

        public void Delete(int id)
        {
            var obj = context.Contacts.Find(id);
            if (obj != null)
            {
                context.Contacts.Remove(obj);
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

        public IEnumerable<Contact> Filter(Func<Contact, bool> func)
        {
            return context.Contacts.Where(func).ToList();
        }

        public Contact GetById(int id)
        {
            return context.Contacts.Find(id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Contact obj)
        {
            if(obj != null)
            {
                obj.CreatedByOnlineUserId = (obj.CreatedByOnlineUserId != null) ? obj.CreatedByOnlineUserId : 1;
                obj.DateCreated = (obj.DateCreated != null) ? obj.DateCreated : DateTime.Now;
                obj.ContactStatusId = 1;

                context.Contacts.Add(obj);
                context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
        }
    }
}

