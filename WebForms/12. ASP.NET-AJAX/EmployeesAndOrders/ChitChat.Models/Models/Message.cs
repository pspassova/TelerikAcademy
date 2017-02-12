using System.ComponentModel.DataAnnotations;

namespace ChitChat.Models.Models
{
    public class Message
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string Sender { get; set; }
    }
}
