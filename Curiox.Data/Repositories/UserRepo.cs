using Curiox.Data.Context;
using Curiox.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Curiox.Data.Repositories
{
    public class UserRepo : BaseRepo, IUserRepo
    {
        public IList<User> GetUsers()
        {
            return Db.User.ToList();
        }

        public User GetUser(int id)
        {
            return Db.User.Find(id);
        }

        public void Insert(User user)
        {
            throw new NotImplementedException();
        }

        public void Update(User user)
        {
            Db.User.Attach(user);
            Db.Entry(user).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public void Delete(User user)
        {
            throw new NotImplementedException();
        }
    }
}
