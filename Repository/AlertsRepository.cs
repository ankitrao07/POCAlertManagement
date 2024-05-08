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
    public class AlertsRepository : RepositoryBase<Alerts>, IAlertsRepository
    {
        public AlertsRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public IEnumerable<Alerts> GetAlerts()
        {
            return FindAll()
                .OrderBy(a =>a.AlertTriggeredOn )
                .ToList();
        }

    }
}
