using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MyWebApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

// Configure MySQL Database with EF Core
// Ensure your appsettings.json has a connection string named "DefaultConnection"
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);

// Enable CORS with policy allowing React frontend from localhost:5173
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policyBuilder =>
    {
        policyBuilder.WithOrigins("http://localhost:5173")
                     .AllowAnyHeader()
                     .AllowAnyMethod();
    });
});

// Add Swagger/OpenAPI support
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "MyWebApi",
        Version = "v1",
        Description = "ASP.NET Core Web API with MySQL RDS and EF Core"
    });
});

var app = builder.Build();

// Apply any pending EF Core migrations automatically
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate();
}

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyWebApi v1");
        c.RoutePrefix = string.Empty; // Swagger UI at root: http://<server>:<port>/
    });
}

// Enable CORS using the AllowFrontend policy
app.UseCors("AllowFrontend");

// HTTPS redirection is enabled since you have HTTPS URLs configured
app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

// Listen on all interfaces and ports for external access
app.Urls.Add("http://0.0.0.0:5000");
app.Urls.Add("https://0.0.0.0:5001");

app.Run();