using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebApi.Models
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }

        [Required]
        [MaxLength(20)]
        public required string AccountNumber { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Balance { get; set; }

        [Required]
        [MaxLength(10)]
        public required string AccountType { get; set; }  // e.g., Checking, Savings

        // Navigation properties
        public User? User { get; set; }
        public ICollection<Transaction>? Transactions { get; set; }
    }
}
