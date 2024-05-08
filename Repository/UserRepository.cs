using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UserRepository : RepositoryBase<User>, IUserReposity
    {
        private readonly RepositoryContext _repositoryContext;
        public UserRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

       public bool IsAuthenticated(string userName, string Password)
        {

            var result= _repositoryContext.User.Where(u=>u.UserName==userName && u.Password==Password).ToList();
                
            return result.Count>0  ? true:false ;
               
            
        }
    }
}
