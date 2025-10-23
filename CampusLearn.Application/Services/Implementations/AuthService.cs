using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CampusLearn.Infrastructure.Data;
using CampusLearn.Infrastructure.Data.Entities;
using CampusLearn.Application.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;
using CampusLearn.Application.DTOs;

namespace CampusLearn.Application.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly CampusLearnDbContext _context;

        public AuthService(CampusLearnDbContext context)
        {
            _context = context;
        }

        // ------------------ LOGIN ------------------
        public async Task<AuthResponseDto> LoginAsync(LoginRequestDto request)
        {
            var user = await _context.Users
                .Include(u => u.Password)
                .FirstOrDefaultAsync(u => u.UserEmail == request.UserEmail);

            if (user == null)
            {
                return new AuthResponseDto
                {
                    Message = "User not found.",
                    success = false
                };
            }

            if (user.Password == null)
            {
                return new AuthResponseDto
                {
                    Message = "No password set for this account.",
                    success = false
                };
            }

            bool isValidPassword = BCrypt.Net.BCrypt.Verify(request.Password, user.Password.PasswordHash);

            if (!isValidPassword)
            {
                return new AuthResponseDto
                {
                    Message = "Invalid email or password.",
                    success = false
                };
            }

            return new AuthResponseDto
            {
                Message = "Login successful.",
                success = true
            };
        }

        // ------------------ REGISTER ------------------
        /*public async Task<AuthResponseDto> RegisterAsync(RegisterRequestDto request)
        {
            if (await _context.Users.AnyAsync(u => u.UserEmail == request.UserEmail))
                return new AuthResponseDto { Message = "User already exists.", Token = string.Empty, Role = string.Empty };

            // Create user
            var newUser = new User
            {
                UserEmail = request.UserEmail,
                UserName = request.UserName,
                CourseId = null // optional field
            };

            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();

            // Add password
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);
            var passwordEntity = new Password
            {
                UserEmail = request.UserEmail,
                PasswordHash = hashedPassword
            };

            await _context.Passwords.AddAsync(passwordEntity);

            // Assign role (13=Student, 14=Tutor, 15=Admin)
            var userRole = new Role
            {
                RoleId = request.RoleId
            };
            await _context..AddAsync(userRole);

            await _context.SaveChangesAsync();

            string role = await _context.Roles
                .Where(r => r.RoleId == request.RoleId)
                .Select(r => r.RoleName)
                .FirstOrDefaultAsync() ?? "student";

            var token = _jwtTokenService.GenerateToken(request.UserEmail, role);
            return new AuthResponseDto
            {
                Message = "Registration successful.",
                Token = token,
                Role = role
            };
        }

        // ------------------ TOKEN VALIDATION ------------------
        public async Task<UserInfoDto> ValidateTokenAsync(string token)
        {
            var decoded = _jwtTokenService.ValidateToken(token);
            if (decoded == null)
                return null!;

            string email = decoded.Email;
            var user = await _context.Users
                .Include(u => u.Userroles)
                .ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync(u => u.UserEmail == email);

            string role = user?.Userroles.FirstOrDefault()?.Role?.RoleName ?? "student";
            return new UserInfoDto { Email = email, Role = role };
        } */

    }
}
