using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoyWrapper
    {
        IAlertsRepository Alerts { get; }
        IUserReposity User { get; }
        void Save();
    }
}
