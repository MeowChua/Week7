using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using front.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Week7.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Week7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly DataContext dt;
        public UsersController(DataContext dt)
        {
            this.dt = dt;
        }
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await dt.Users.ToArrayAsync());
            //return View();
        }
        [HttpGet]
        [Route("{id:Int}")]
        public async Task<IActionResult> GetUserById([FromRoute] int id)
        {
            var pd = await dt.Users.FindAsync(id);
            if (pd == null)
            {
                return NotFound();
            }

            return Ok(pd);
            //return View();
        }
        [HttpDelete]
        [Route("{id:Int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var ar = dt.Users.Find(id);
            if (ar != null)
            {
                dt.Remove(ar);
                dt.SaveChanges();
                return Ok(ar);
            }
            return NotFound();
        }
        /*
        public static User us = new User();
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserLogin usg)
        {
            CreatePasswordHash(usg.Password, out byte[] pwHash, out byte[] pwSalt);
            us.Email = usg.Email;
            us.PasswordHash = pwHash;
            us.PasswordSalt = pwSalt;
            return Ok(us);
        }
        private void CreatePasswordHash(string pw, out byte[] pwHash, out byte[] pwSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                pwSalt = hmac.Key;
                pwHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(pw));

            }
        }

        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login(UserLogin usg)
        {
            if (us.Email != usg.Email)
            {
                return BadRequest("User not found");
            }
            
            if(!VerifyPasswordHash(usg.Password, us.PasswordHash, us.PasswordSalt))
            {
                return BadRequest("Wrong password");
            }
            string token = CreateToken(us);
            return Ok("My Crazy Token");
        }
        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email)
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _icf.GetSection("AppSettings:Token").Value));
            var cred = new SigningCredentials(key,
                SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt; 
        }
        private bool VerifyPasswordHash(string pw, byte[] pwHash, byte[] pwSalt)
        {
            using (var hmac = new HMACSHA512(pwSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(pw));
                return computedHash.SequenceEqual(pwHash);
            }
        }
        */
    }
}

