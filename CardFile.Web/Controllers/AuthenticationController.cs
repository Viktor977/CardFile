using CardFile.BAL.Interfaces;
using CardFile.BAL.ModelsDto;
using CardFile.Web.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CardFile.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _service;
        public AuthenticationController(IUserService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Auth([FromBody] AuthenticationDto model)
        {
            var identity = GetIdentity(model.Email, model.Password);
            if (identity is null) return  BadRequest();

            var now = DateTime.Now;
            var jwt = new JwtSecurityToken(
                issuer: TokenOptions.Issuer,
                audience: TokenOptions.Audience,
                notBefore: now,
                claims: identity.Claims,
                expires: now.Add(TimeSpan.FromMinutes(TokenOptions.LifeTime)),
                signingCredentials: new SigningCredentials(TokenOptions.GetSymmetricSecurityKey(),
                SecurityAlgorithms.HmacSha256)
                );

            var responce = await _service.CheckUser(model.Email, model.Password);
            responce.Password = null;
            responce.Token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return Ok(responce);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] UserForRegistrationDto model)
        {
            var user = await _service.CheckUser(model.Email, model.Password);
            if (user != null)
            {
                return BadRequest(new {errorText="User is exist" });
            }
            var userNew = new UserDto()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Role = DAL.Enums.Roles.Registered,
                Email = model.Email,
                Login = model.Login,
                Password = model.Password
            };

            await _service.AddAsync(userNew);

            return Ok(userNew);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UserDto user)
        {
            if (user.Id == 0)
            {
                return BadRequest();
            }
            await _service.UpdateAsync(user);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult>Delete([FromBody]UserDto user)
        {
            if(user is null)
            {
                return BadRequest();
            }

            await _service.DeleteAsync(user);
            return Ok();
        }

        private ClaimsIdentity GetIdentity(string username, string password)
        {
            var user = _service.CheckUser(username, password).Result;
            if (user is null)
            {
                return null;
            }

            var claims = new List<Claim>();
            var claimsEmail = new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email);
            var claimsPass = new Claim(ClaimsIdentity.DefaultNameClaimType, user.Password);
            var cllimsRole = new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.ToString());
            claims.Add(claimsEmail);
            claims.Add(claimsPass);
            claims.Add(cllimsRole);

            var claimsIdentity = new ClaimsIdentity(claims, "Token",
               ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            return claimsIdentity;
        }
    }
}
