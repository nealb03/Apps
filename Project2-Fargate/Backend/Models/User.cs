using System.ComponentModel.DataAnnotations;

namespace MyWebApi.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(100)]
        public required string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public required string LastName { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        [MaxLength(100)]
        public required string Password { get; set; }

        // Navigation property
        public ICollection<Account>? Accounts { get; set; }
    }
}
