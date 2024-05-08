using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IUserReposity:IRepositoryBase<User>
    {
        bool IsAuthenticated(string userName,string Password);
    }
}
