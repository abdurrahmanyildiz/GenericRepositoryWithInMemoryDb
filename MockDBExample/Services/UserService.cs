using MockDBExample.Models;
using MockDBExample.Repos.Abstracts;
using MockDBExample.Services.Abstracts;
using System;
using System.Collections.Generic;

namespace MockDBExample.Services
{
    public class UserService : IUserService
    {
        private IUserRepo userRepo;
        public UserService(IUserRepo _userRepo)
        {
            userRepo = _userRepo;
        }

        public void AddUser(User user)
        {
            user.UID = Guid.NewGuid().ToString();
            userRepo.Add(user);
        }

        public User GetUser(string UID)
        {
            if (string.IsNullOrEmpty(UID))
            {
                throw new Exception("UID is null or empty!");
            }

            return userRepo.Get(x => x.UID == UID);
        }

        public List<User> GetUserList()
        {
            return userRepo.GetList();
        }

    }
}
