using AssetTrackingAPI.DTOs;
using AssetTrackingAPI.Interfaces;
using AssetTrackingAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AssetTrackingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseApiController
    {
        private readonly AssetDBContext _context;
        private readonly ITokenService _tokenService;
        public AccountController(AssetDBContext context, ITokenService tokenService) 
        {
            _context = context;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> Register(RegisterDTO registerDto)
        {
            if (await userExists(registerDto.Username))
                return BadRequest("This username is already registered!");

            using var hmac = new HMACSHA512();
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password));
            var salt = hmac.Key;

            var user = new User
            {
                Username = registerDto.Username.ToLower(),
                FirstName = registerDto.Firstname,
                LastName = registerDto.Lastname,
                Email = registerDto.Email,
                Phone = registerDto.Phone,
                Role = registerDto.Role,
                PasswordHash = Convert.ToBase64String(hash),
                PasswordSalt = Convert.ToBase64String(salt)
            };

            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return new UserDTO 
            {
                Username = user.Username,
                Firstname = user.FirstName,
                Lastname = user.LastName,
                Email = user.Email,
                Phone = user.Phone,
                Role = user.Role,
                Token = _tokenService.CreateToken(user)
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO loginDto)
        {
            var user = await _context.User.SingleOrDefaultAsync(x => x.Username == loginDto.Username);
            
            if (user == null)
                return Unauthorized("Invalid username!");

            using var hmac = new HMACSHA512(Convert.FromBase64String(user.PasswordSalt));

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));
            var computedHashS = Convert.ToBase64String(computedHash);

            if (!computedHashS.Equals(user.PasswordHash))
            {
                return Unauthorized("Invalid Password!");
            }

            return new UserDTO
            {
                Username = user.Username,
                Firstname = user.FirstName,
                Lastname = user.LastName,
                Email = user.Email,
                Phone = user.Phone,
                Role = user.Role,
                Token = _tokenService.CreateToken(user)
            };
        }

        private async Task<bool> userExists(string username)
        {
            return await _context.User.AnyAsync(x => x.Username == username.ToLower());
        }
    }
}
