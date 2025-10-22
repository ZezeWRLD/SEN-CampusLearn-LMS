using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CampusLearn.Application.DTOs;

namespace CampusLearn.Application.Services.Interfaces
{
    public interface IJwtTokenService
    {
        string GenerateToken(string email, string role);
       // DecodedTokenDto? ValidateToken(string token);
    }
}
