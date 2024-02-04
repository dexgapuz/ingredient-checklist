using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using api.Database;
using api.DTO;
using api.Models;
using api.Request;
using Microsoft.IdentityModel.Tokens;

namespace api.Services.Auth
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly DataContext _dataContext;
        private readonly IConfiguration _configuration;

        public AuthenticateService(DataContext dataContext, IConfiguration configuration)
        {
            _dataContext = dataContext;
            _configuration = configuration;
        }

        public AuthenticateDto? Login(LoginRequest loginRequest)
        {
            var user = _dataContext.Users
                .Where(u => u.Username.ToLower() == loginRequest.Username.ToLower())
                .FirstOrDefault();

            if (user != null && BC.Verify(loginRequest.Password, user.Password))
            {
                return new AuthenticateDto
                {
                    Id = user.Id,
                    Username = user.Username,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    AccessToken = GenerateToken(user)
                };
            }

            return null;
        }

        public AuthenticateDto Register(RegisterRequest registerRequest)
        {
            var user = new User
            {
                Username = registerRequest.Username,
                Password = BC.HashPassword(registerRequest.Password),
                FirstName = registerRequest.FirstName,
                LastName = registerRequest.LastName
            };

            _dataContext.Users.Add(user);
            _dataContext.SaveChanges();

            var accessToken = GenerateToken(user);

            return new AuthenticateDto
            {
                Id = user.Id,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                AccessToken = accessToken
            };
        }

        private string GenerateToken(User user)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Surname, user.LastName)
            };

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]!));

            var tokenDescriptor = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256)
            );

            var accessToken = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);

            return accessToken;
        }
    }
}
