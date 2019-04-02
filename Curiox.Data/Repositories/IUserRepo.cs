using Curiox.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Curiox.Data.Repositories
{
    public interface IUserRepo
    {
        IList<User> GetUsers();
        User GetUser(int id);
        void Insert(User user);
        void Update(User user);
        void Delete(User user);
    }
}
