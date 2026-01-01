using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyWebApi.Data;
using MyWebApi.Models;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyWebApi.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILogger<AuthController> _logger;

        public AuthController(AppDbContext context, ILogger<AuthController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // Allows anonymous access (no authentication or JWT required)
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Password))
                return BadRequest(new { message = "Email and password are required." });

            var user = await _context.Users.AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == request.Email);

            if (user == null)
            {
                _logger.LogWarning("Login failed: user not found for email {Email}", request.Email);
                return Unauthorized(new { message = "Invalid email or password." });
            }

            if (!VerifyPasswordHash(request.Password, user.PasswordHash))
            {
                _logger.LogWarning("Login failed: invalid password for email {Email}", request.Email);
                return Unauthorized(new { message = "Invalid email or password." });
            }

            // Return user data only, no tokens
            return Ok(new
            {
                user = new
                {
                    user.UserId,
                    user.FirstName,
                    user.LastName,
                    user.Email
                }
            });
        }

        private bool VerifyPasswordHash(string password, string storedHash)
        {
            if (string.IsNullOrEmpty(storedHash))
                return false;

            using var sha256 = SHA256.Create();
            var hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            var computedHash = BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();

            return computedHash == storedHash.ToLowerInvariant();
        }
    }

    public record LoginRequest(string Email, string Password);
}