using StateManagement.Data.Contracts;
using System.Data.Entity;
using StateManagement.Models.Models;

namespace StateManagement.Data
{
    public class StateManagementContext : DbContext, IStateManagementContext
    {
        public StateManagementContext()
            : base("StateManagement")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<StateManagementContext>());
        }

        public IDbSet<UsersCount> UsersCount { get; set; }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}
