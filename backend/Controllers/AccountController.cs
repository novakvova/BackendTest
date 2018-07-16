﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    public class Credentials
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    [Produces("application/json")]
    [Route("api/Account")]
    public class AccountController : Controller
    {
        readonly UserManager<IdentityUser> _userManager;
        readonly SignInManager<IdentityUser> _signInManager;
        public AccountController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromBody]Credentials credentials)
        {
            var user = new IdentityUser
            {
                UserName = credentials.Email,
                Email = credentials.Email
            };
            var result = await _userManager
                .CreateAsync(user, credentials.Password);
            if (!result.Succeeded)
                return BadRequest(result.Errors);
            await _signInManager.SignInAsync(user, isPersistent: false);
            var jwt = new JwtSecurityToken();
            return Ok(new JwtSecurityTokenHandler().WriteToken(jwt));
        }
    }
}