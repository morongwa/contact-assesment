using System;
using contact.app.business.context;
using contact.app.business.entity;

namespace contact.app.business.repository
{
    public class RepositoryNamedGroup : IGenericRepository<NamedGroup>
    {

        private readonly WebCoreContext context;
        public RepositoryNamedGroup(WebCoreContext _context)
        {
            context = _context;
        }

        public IEnumerable<NamedGroup> All()
        {
            return context.NamedGroups.ToList();
        }

        public void Create(NamedGroup obj, int? iCreatedById)
        {
            context.NamedGroups.Add(obj);
        }

        public void Delete(int id)
        {
            var obj = context.NamedGroups.Find(id);
            if (obj != null)
            {
                context.NamedGroups.Remove(obj);
            }
        }

        private bool isDisposed = false;
        public void Dispose()
        {
            if (!isDisposed)
            {
                context.Dispose();
            }
            isDisposed = true;
        }

        public IEnumerable<NamedGroup> Filter(Func<NamedGroup, bool> func)
        {
            return context.NamedGroups.Where(func).ToList();
        }

        public NamedGroup GetById(int id)
        {
            return context.NamedGroups.Find(id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(NamedGroup obj)
        {
            context.NamedGroups.Add(obj);
            context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}

