using AssetTrackingAPI.DTOs;
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

        public AccountController(AssetDBContext context) 
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(RegisterDTO registerDto)
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
                PasswordHash = System.Text.Encoding.Default.GetString(hash),
                PasswordSalt = System.Text.Encoding.Default.GetString(salt)
            };

            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        [HttpPost("login")]
        public async Task<ActionResult<User>> Login(LoginDTO loginDto)
        {
            var user = await _context.User.SingleOrDefaultAsync(x => x.Username == loginDto.Username);
            
            if (user == null)
                return Unauthorized("Invalid username!");

            using var hmac = new HMACSHA512(Encoding.UTF8.GetBytes(user.PasswordSalt));

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i])
                {
                    return Unauthorized("Invalid Password!");
                }
            }

            return user;
        }

        private async Task<bool> userExists(string username)
        {
            return await _context.User.AnyAsync(x => x.Username == username.ToLower());
        }
    }
}
