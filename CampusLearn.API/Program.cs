using CampusLearn.Application;
using CampusLearn.Infrastructure;
using CampusLearn.Infrastructure.Data;
using DotNetEnv;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using CampusLearn.API.Helpers;
using CampusLearn.Application.Services.Interfaces;
using CampusLearn.Application.Services.Implementations;


var builder = WebApplication.CreateBuilder(args);
Env.Load();

Console.WriteLine(builder.Configuration.GetConnectionString("SupabaseConnection"));


builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
// Add services to the container.

builder.Services.AddControllers();

var jwtKey = builder.Configuration["Jwt:Key"];
var jwtIssuer = builder.Configuration["Jwt:Issuer"];

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtIssuer,
            ValidAudience = jwtIssuer,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
        };
    });


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<CampusLearnDbContext>();
    try
    {
        if (db.Database.CanConnect())
            Console.WriteLine("Database verified on startup!");
        else
            Console.WriteLine("Database connection failed at startup.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Database check error: {ex.Message}");
    }
}

app.UseAuthentication();
app.UseAuthorization();

app.Run();
