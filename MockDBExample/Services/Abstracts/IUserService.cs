using MockDBExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MockDBExample.Services.Abstracts
{
    public interface IUserService
    {
        User GetUser(string UID);

        List<User> GetUserList();

        void AddUser(User user);

    }
}
