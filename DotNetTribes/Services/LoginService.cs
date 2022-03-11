using System;
using System.ComponentModel;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using DotNetTribes.DTOs;
using DotNetTribes.Exceptions;
using Microsoft.IdentityModel.Tokens;

namespace DotNetTribes.Services
{
    public class LoginService : ILoginService
    {
        private readonly ApplicationContext _applicationContext;
        private readonly string SECRET_KEY;

        public LoginService(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
            SECRET_KEY = Environment.GetEnvironmentVariable("SECRET_KEY");
        }

        public LoginResponseDto VerifyUsernameAndPassword(LoginRequestDto usernamePasswordDto)
        {
            if (usernamePasswordDto == null)
            {
                throw new LoginException("All fields are required.");
            }

            if (string.IsNullOrEmpty(usernamePasswordDto.password))
            {
                throw new LoginException("Password is required.");
            }
            
            if (string.IsNullOrEmpty(usernamePasswordDto.username))
            {
                throw new LoginException("Username is required.");
            }

            isUsernameAndPasswordCorrect(usernamePasswordDto);
            
            var user = _applicationContext.Users.SingleOrDefault(u => u.Username == usernamePasswordDto.username);

            string token = CreateToken(user.Username, user.KingdomId.ToString());
            
            
            return new LoginResponseDto()
            {
                Status = "ok",
                Token = token
            };
        }
        
        private string CreateToken(string name, string kingdomId)
        {
            var symmetricKey = Encoding.ASCII.GetBytes(SECRET_KEY);
            
            SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {//here are the information that the token stores and their names
                        new Claim("Username", name),
                        new Claim("KindomId", kingdomId)
                    }),
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken = tokenHandler.CreateToken(securityTokenDescriptor);
            string token = tokenHandler.WriteToken(securityToken);

            return token;
        }

        private void isUsernameAndPasswordCorrect(LoginRequestDto usernamePasswordDto)
        {
            var user = _applicationContext.Users.SingleOrDefault(u => u.Username == usernamePasswordDto.username);
            if (user == null)
            {
                throw new LoginException("Username or password is incorrect.");
            }
            bool verified = BCrypt.Net.BCrypt.Verify(usernamePasswordDto.password, user.HashedPassword);
            if (verified == false)
            {
                throw new LoginException("Username or password is incorrect.");
            }
            
        }
    }
}