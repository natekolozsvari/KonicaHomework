using KonicaHomework.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonicaHomework.DAL
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDBContext context;

        public UserRepository(AppDBContext context)
        {
            this.context = context;
        }

        public void AddUser(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }

        public bool DoesUsernameExist(string name)
        {
            return context.Users.FirstOrDefault(user => user.Username == name) != null;
        }

        public User GetUser(int id)
        {
            return context.Users.FirstOrDefault(user => user.Id == id);
        }

        public User GetUserByName(string name)
        {
            return context.Users.FirstOrDefault(user => user.Username == name);
        }

        public bool IsUserInactive(int id)
        {
            return context.Users.FirstOrDefault(user => user.Id == id).Inactive;
        }

        public void UpdateUser(User userChanges)
        {
            context.Entry(GetUser(userChanges.Id)).State = EntityState.Detached;
            var user = context.Users.Attach(userChanges);
            user.State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
