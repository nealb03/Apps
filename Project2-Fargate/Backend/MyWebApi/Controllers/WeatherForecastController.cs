using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebApi.Data;
using MyWebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly AppDbContext _context;

        public WeatherForecastController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /WeatherForecast
        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            // Fetches all weather forecast records from DB
            return await _context.WeatherForecasts.ToListAsync();
        }

        // GET: /WeatherForecast/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<WeatherForecast>> GetById(int id)
        {
            var forecast = await _context.WeatherForecasts.FindAsync(id);

            if (forecast == null)
                return NotFound();

            return forecast;
        }

        // POST: /WeatherForecast
        [HttpPost]
        public async Task<ActionResult<WeatherForecast>> Post([FromBody] WeatherForecast forecast)
        {
            if (forecast == null)
                return BadRequest();

            _context.WeatherForecasts.Add(forecast);
            await _context.SaveChangesAsync();

            // Returns 201 Created with location header for new resource
            return CreatedAtAction(nameof(GetById), new { id = forecast.Id }, forecast);
        }

        // PUT: /WeatherForecast/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] WeatherForecast forecast)
        {
            if (forecast == null || forecast.Id != id)
                return BadRequest();

            var existing = await _context.WeatherForecasts.FindAsync(id);
            if (existing == null)
                return NotFound();

            existing.Date = forecast.Date;
            existing.TemperatureC = forecast.TemperatureC;
            existing.Summary = forecast.Summary;

            _context.Entry(existing).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            // 204 No Content indicates update success
            return NoContent();
        }

        // DELETE: /WeatherForecast/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var forecast = await _context.WeatherForecasts.FindAsync(id);
            if (forecast == null)
                return NotFound();

            _context.WeatherForecasts.Remove(forecast);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}