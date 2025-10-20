using CampusLearn.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CampusLearn.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthCheckController : ControllerBase
    {
        private readonly CampusLearnDbContext _context;

        public HealthCheckController(CampusLearnDbContext context)
        {
            _context = context;
        }

        [HttpGet("config")]
        public IActionResult ShowConnection()
        {
            return Ok(_context.Database.GetConnectionString());
        }
        

        [HttpGet("db")]
        public async Task<IActionResult> CheckDatabase()
        {
            try
            {
                await using var connection = _context.Database.GetDbConnection();

                if (connection.State == System.Data.ConnectionState.Closed)
                    await connection.OpenAsync();


                var canConnect = await _context.Database.CanConnectAsync();
             

                if (canConnect)
                {
                  
                    await using var command = connection.CreateCommand();
                    command.CommandText = "SELECT NOW();";
                    var serverTime = await command.ExecuteScalarAsync();


                    return Ok(new
                    {
                        status = "Healthy",
                        message = "✅ Database connection successful!",
                        server_time = serverTime?.ToString()
                    });
                }
                else
                {
                    return StatusCode(500, new
                    {
                        status = "Unhealthy",
                        message = "❌ Unable to connect to the Supabase database."
                    });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    status = "Unhealthy",
                    message = "❌ Database connection failed.",
                    error = ex.Message
                });
            }
        }
    }
}
