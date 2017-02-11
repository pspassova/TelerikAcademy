using System.ComponentModel.DataAnnotations;

namespace StateManagement.Models.Models
{
    public class UsersCount
    {
        public int Id { get; set; }

        [Required]
        public int Count { get; set; }
    }
}
