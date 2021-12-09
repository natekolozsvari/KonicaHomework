using KonicaHomework.Models;
using System;
using System.Linq;
using System.Net;

namespace KonicaHomework.DAL
{
    public interface IUserRepository
    {
        bool DoesUsernameExist(string name);
        User GetUser(int id);
        User GetUserByName(string name);
        bool IsUserInactive(int id);
        void AddUser(User user);
        void UpdateUser(User user);
        void Log(User user, bool success, IPAddress ip);
    }
}
