using ChitChat.Data.Contracts;
using System.Data.Entity;
using ChitChat.Models.Models;

namespace ChitChat.Data
{
    public class ChitChatContext : DbContext, IChitChatContext
    {
        public ChitChatContext()
            : base("ChitChat")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ChitChatContext>());
        }

        public IDbSet<Message> Messages { get; set; }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}
