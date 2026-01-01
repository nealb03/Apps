using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebApi.Data;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]  // Require JWT authentication
    public class FinancialDataController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FinancialDataController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            // Get user id from JWT claims
            var userIdClaim = User.FindFirst("id");
            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userId))
                return Unauthorized();

            // Query transactions for accounts owned by this user
            var transactions = await _context.Transactions
                .AsNoTracking()
                .Include(t => t.Account)
                .Where(t => t.Account.UserId == userId)
                .Select(t => new
                {
                    t.TransactionId,
                    t.AccountId,
                    AccountType = t.Account.AccountType,
                    AccountNumber = t.Account.AccountNumber,
                    t.Amount,
                    t.Type,
                    t.Description,
                    t.CreatedAt
                })
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();

            return Ok(transactions);
        }
    }
}