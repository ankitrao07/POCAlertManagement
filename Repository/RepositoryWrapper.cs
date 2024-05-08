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
    public class RepositoryWrapper:IRepositoyWrapper
    {

        private RepositoryContext _repoContext;
        private IAlertsRepository _alerts;
        private IUserReposity _user;
        public IAlertsRepository Alerts {
            get
            {
                if (_alerts == null)
                {
                    _alerts = new AlertsRepository(_repoContext);

                }
                return _alerts;
            
            }

            
        }
        public IUserReposity User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_repoContext);
                }
                return _user;
            }
        }
        public RepositoryWrapper(RepositoryContext repoContext)
        {
            _repoContext = repoContext;
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }

    }
}
