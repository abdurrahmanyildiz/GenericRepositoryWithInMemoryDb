using MockDBExample.Models;
using MockDBExample.Repos.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MockDBExample.Repos
{
    public class UserRepo : GenericRepository<User, MockDbContext>, IUserRepo
    {

    }
}
