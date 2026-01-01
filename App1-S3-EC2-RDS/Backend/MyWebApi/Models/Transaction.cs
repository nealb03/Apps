using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebApi.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public int AccountId { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime CreatedAt { get; set; }

        // Navigation property to Account
        [ForeignKey(nameof(AccountId))]
        public Account Account { get; set; } = null!;
    }
}