using System.Security.Cryptography;
using System.Text;
using API.Data;
using API.DTO;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class AccountController: BaseApiController
    {
        public readonly DataContext _context;
        public AccountController(DataContext context)
        {
            _context = context;
            
        }

        [HttpPost("register")] //api/account/register
        public async Task<ActionResult<AppUser>> Resgister(RegisterDto registerDto)
        {
            if (await UserExist(registerDto.UserName)) 
            {
                return BadRequest("Username is taken");
            }
            using var  hmac = new HMACSHA512();
            var user = new AppUser
            {
                UserName = registerDto.UserName,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        [HttpPost("login")]
        public async Task<ActionResult<AppUser>> Login(LoginDto loginDto)
        {
            var user = await  _context.Users.SingleOrDefaultAsync(x => 
            x.UserName == loginDto.UserName);

            if (user == null) return Unauthorized("Invalid username");

            using var  hmac = new HMACSHA512(user.PasswordSalt);

            var ComputeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password
            ));

            for (int i = 0; i < ComputeHash.Length; i++)
            {
                if (ComputeHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid passowrd");
            }

            return user;
        }

        private async Task<bool>UserExist(string username)
        {
            return await _context.Users.AnyAsync(x => x.UserName == username.ToLower());
        }
        
    }
}