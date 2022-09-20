using System;
using contact.app.business.entity;

namespace contact.app.business.repository
{
    public interface IAuthRepository: IDisposable
    {
        bool SignIn(string username, String password);
        void Register(string username, string password, string email);
        IEnumerable<OnlineUser> GetByUsername(string username);
        OnlineUser GetById(int id);
        void Save();
    }
}

