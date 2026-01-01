using System.Collections.Generic;
using MyWebApi.Models;  // Make sure this is your models namespace

namespace MyWebApi.Models
{
    public class Account
    {
        public int AccountId { get; set; }
        public int UserId { get; set; }
        public string AccountNumber { get; set; } = null!;
        public string AccountType { get; set; } = null!;

        public User User { get; set; } = null!;  // navigation property
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}