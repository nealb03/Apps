using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebApi.Data;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyWebApi.Controllers
{
    [ApiController]
    [Route("api/accounts")]
    [Authorize]  // Require authentication
    public class AccountsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AccountsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAccounts()
        {
            // Extract user ID from claims (set during JWT validation)
            var userIdClaim = User.FindFirst("id");
            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userId))
            {
                return Unauthorized();
            }

            // Query accounts only belonging to the authenticated user
            var accounts = await _context.Accounts
                .AsNoTracking()
                .Where(a => a.UserId == userId)
                .ToListAsync();

            return Ok(accounts);
        }
    }
}