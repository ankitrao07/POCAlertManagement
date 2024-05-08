using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class RepositoryContext : DbContext
    {
       
        public RepositoryContext(DbContextOptions options) : base(options)
        {

        }
       public DbSet<Alerts> Alerts  {get;set;}
       public  DbSet<User> User { get;set;}
    }
}
