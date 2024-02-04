using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTO;
using api.Request;

namespace api.Services.Auth
{
    public interface IAuthenticateService
    {
        public AuthenticateDto Register(RegisterRequest registerRequest);
        public AuthenticateDto? Login(LoginRequest loginRequest);
    }
}
