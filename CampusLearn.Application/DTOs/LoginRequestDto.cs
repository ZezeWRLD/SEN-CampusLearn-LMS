using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampusLearn.Application.DTOs
{
    public class LoginRequestDto
    {
        public string UserEmail { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
