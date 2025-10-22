using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampusLearn.Application.DTOs
{
    public class AuthResponseDto
    {
        public string Message { get; set; } = null!;
        public required string Role { get; set; }
        public required bool success { get; set; }
    }
}
