using KonicaHomework.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;

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

        public void Log(User user, bool success, IPAddress ip)
        {
            var tempUser = GetUserByName(user.Username);
            if (tempUser.Inactive)
            {
                success = false;
            }
            var log = new Log
            {
                Ip = ip.ToString(),
                Date = DateTime.Now,
                Username = user.Username,
                Event = success ? "Successful login" : "Unsuccessful login"
            };
            context.Logs.Add(log);
            context.SaveChanges();
            if (!tempUser.Inactive)
            {
                var lastFive = context.Logs.Where(log => log.Username == user.Username).OrderByDescending(log => log.Date).Take(5);
                if (lastFive.Where(log => log.Event == "Unsuccessful login").Count() == 5)
                {
                    tempUser.Inactive = true;
                    UpdateUser(tempUser);
                    var deactivateLog = new Log
                    {
                        Ip = ip.ToString(),
                        Date = DateTime.Now,
                        Username = user.Username,
                        Event = "User deactivated"
                    };
                    context.Logs.Add(deactivateLog);
                    context.SaveChanges();
                }
            }
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
