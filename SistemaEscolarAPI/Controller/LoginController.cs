using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaEscolarAPI.DB;
using SistemaEscolarAPI.Models;
using SistemaEscolarAPI.DTO;
using SistemaEscolarAPI.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Diagnostics;

namespace SistemaEscolarAPI.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDto)
        {
            var users  = new List<Usuario>{
                new Usuario{ Username = "admin", PassWord = "admin", Role = "admin" },
                new Usuario{ Username = "user", PassWord = "user", Role = "user" }
            };

            var user = users.FirstOrDefault(u => u.Username == loginDto.Username && u.PassWord == loginDto.Password);

            if (user == null)
            {
                return Unauthorized(new{ message = "Usuário ou senha inválidos"});
            }

            


            if (string.IsNullOrWhiteSpace(loginDto.Username) || string.IsNullOrWhiteSpace(loginDto.Password))
            {
                return BadRequest();
            }

            
            var token = Token.GenereteToken(user);   

            return Ok(new {token});
        }

    }
}