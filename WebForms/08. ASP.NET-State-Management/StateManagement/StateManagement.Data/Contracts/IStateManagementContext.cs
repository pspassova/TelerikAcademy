using StateManagement.Models.Models;
using System.Data.Entity;

namespace StateManagement.Data.Contracts
{
    public interface IStateManagementContext
    {
        IDbSet<UsersCount> UsersCount { get; set; }

        void SaveChanges();
    }
}
