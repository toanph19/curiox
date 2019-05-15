﻿using Curiox.Data.Entities;
using Curiox.Web.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Curiox.Data.Repositories
{
    public class UserRepo : Repository<User>, IUserRepo
    {
        public User Get(string username, string password)
        {
            var hashedPassword = HashHelper.ComputeSha256Hash(password);
            var user = Db.User.FirstOrDefault(u => u.Username == username && u.Password == hashedPassword);

            return user;
        }

        
        public void Add(string username, string email, string password)
        {
            var hashedPassword = HashHelper.ComputeSha256Hash(password);

            var user = new User
            {
                Username = username,
                Email = email,
                Password = hashedPassword
            };

            Db.User.Add(user);
            Db.SaveChanges();
        }
    }
}
