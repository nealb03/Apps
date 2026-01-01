using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyWebApi.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApi.Controllers
{
    [ApiController]
    [Route("api/transactions")]
    public class TransactionsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILogger<TransactionsController> _logger;

        public TransactionsController(AppDbContext context, ILogger<TransactionsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string? search)
        {
            try
            {
                var query = _context.Transactions
                    .Include(t => t.Account)
                    .AsQueryable();

                if (!string.IsNullOrWhiteSpace(search))
                {
                    // Case-insensitive search in Description and Type fields
                    var loweredSearch = search.ToLower();

                    query = query.Where(t =>
                        (t.Description != null && t.Description.ToLower().Contains(loweredSearch)) ||
                        (t.Type != null && t.Type.ToLower().Contains(loweredSearch))
                    );
                }

                var transactions = await query
                    .OrderByDescending(t => t.CreatedAt)
                    .Take(25)
                    .Select(t => new
                    {
                        t.TransactionId,
                        t.Amount,
                        t.Type,
                        t.Description,
                        t.CreatedAt,
                        Account = t.Account == null ? null : new
                        {
                            t.Account.AccountType,
                            t.Account.AccountNumber
                        }
                    })
                    .ToListAsync();

                return Ok(transactions);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error fetching transactions");
                return StatusCode(500, new { message = "Internal Server Error" });
            }
        }
    }
}