using KonicaHomework.DAL;
using KonicaHomework.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace KonicaHomework.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private IUserRepository userRepository;

        public UserController(IUserRepository repo)
        {
            userRepository = repo;
        }

        [HttpGet("exists/{name}")]
        public bool DoesUsernameExist(string name)
        {
            return userRepository.DoesUsernameExist(name);
        }

        [HttpGet("{id}")]
        public User GetUser(int id)
        {
            return userRepository.GetUser(id);
        }

        [HttpGet("inactive/{id}")]
        public bool IsUserInactive(int id)
        {
            return userRepository.IsUserInactive(id);
        }

        [HttpPost("login")]
        public User Login(User user)
        {

            var tempUser = userRepository.GetUserByName(user.Username);
            if (tempUser == null)
            {
                return null;
            }
            if (tempUser.Password.Equals(HashPassword(user.Password, tempUser.Salt).Item2))
            {
                return tempUser;
            }
            return null;
        }

        [HttpPost]
        public void AddUser(User user)
        {
            var hashed = HashPassword(user.Password);
            user.Salt = hashed.Item1;
            user.Password = hashed.Item2;
            userRepository.AddUser(user);
        }

        [HttpPut]
        public void UpdateUser(User user)
        {
            userRepository.UpdateUser(user);
        }

        private Tuple<byte[], string> HashPassword(string password, byte[] salt = null)
        {
            byte[] newSalt;
            if (salt == null)
            {
                newSalt = new byte[128 / 8];
                using (var rngCsp = new RNGCryptoServiceProvider())
                {
                    rngCsp.GetNonZeroBytes(newSalt);
                }
            }
            else
            {
                newSalt = salt;
            }

            var hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: newSalt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));

            return Tuple.Create(newSalt, hashedPassword);
        }
    }
}
