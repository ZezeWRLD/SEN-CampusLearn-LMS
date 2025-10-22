using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;
using CampusLearn.Application.DTOs;

namespace CampusLearn.Application.Services.Interfaces
{
    public interface IAuthService
    {
       // Task<AuthResponseDto> RegisterAsync(RegisterRequestDto request);
        Task<AuthResponseDto> LoginAsync(LoginRequestDto request);
       // Task<UserInfoDto> ValidateTokenAsync(string token);
    }
}
