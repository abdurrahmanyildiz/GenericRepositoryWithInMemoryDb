using MockDBExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MockDBExample.Repos.Abstracts
{
    public interface IUserRepo : IGenericRepositoryBase<User>
    {
    }
}
