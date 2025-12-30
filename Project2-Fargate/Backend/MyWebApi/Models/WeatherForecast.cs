using System;
using System.ComponentModel.DataAnnotations;

namespace MyWebApi.Models
{
    public class WeatherForecast
    {
        [Key]
        public int Id { get; set; }  // Primary key

        [Required]
        public DateOnly Date { get; set; }

        [Required]
        public int TemperatureC { get; set; }

        [Required]
        [MaxLength(50)]
        public required string Summary { get; set; }  // Ensures non-nullable property is initialized
    }
}
