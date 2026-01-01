using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebApi.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;

        [Column("Password")]
        public string PasswordHash { get; set; } = null!;

        public ICollection<Account> Accounts { get; set; } = new List<Account>();
    }
}