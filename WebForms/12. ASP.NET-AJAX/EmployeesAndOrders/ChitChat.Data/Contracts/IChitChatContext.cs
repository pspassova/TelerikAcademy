using ChitChat.Models.Models;
using System.Data.Entity;

namespace ChitChat.Data.Contracts
{
    public interface IChitChatContext
    {
        IDbSet<Message> Messages { get; set; }

        void SaveChanges();
    }
}
