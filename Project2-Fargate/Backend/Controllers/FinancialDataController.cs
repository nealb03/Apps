using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using MyWebApi.Data;       // Your actual DbContext namespace
using MyWebApi.Models;     // Your actual models namespace

namespace MyWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
            var transactions = await _context.Transactions
                .Select(t => new
                {
                    t.TransactionId,
                    t.AccountId,
                    t.Amount,
                    t.Type,
                    t.Description,
                    t.CreatedAt
                })
                .ToListAsync();

            return Ok(transactions);
        }
    }
}