using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using TransIT.API.Services;
using TransIT.Application.DTOs;
using TransIT.Domain.Models.Users;

namespace TransIT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IConfiguration config;
        private readonly AuthService service;
        private readonly IMapper mapper;

        public AuthController(IConfiguration config, AuthService service,IMapper mapper)
        {

            this.config = config;
            this.service = service;
            this.mapper = mapper;
        }
        /*private Employee AuthenticateEmployee(Employee employee)
        {
            if(employee.us)
        }*/
        private string GenerateToken(Employee employee)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(config["Jwt:Issuer"], config["Jwt:Auidence"], null, expires: DateTime.Now.AddMinutes(10), signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        private string GenerateTokenClient(Client employee)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(config["Jwt:Issuer"], config["Jwt:Auidence"], null, expires: DateTime.Now.AddMinutes(10), signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await service.GetAllEmployees());
        }
        [HttpPost("/register")]
        public async Task<IActionResult> Register(RegisterEmployeeDTO employee)
        {
            var user = await service.Authenticate(mapper.Map<Employee>(employee));
            if(user == null)
            { 
                return Ok(await service.Register(mapper.Map<Employee>(employee)));
                

            }
            return BadRequest("Korisnik vec postoji u bazi.");

        }
        [HttpPost("/registerclient")]
        public async Task<IActionResult> RegisterClient(RegisterClientDTO client)
        {
            var user = await service.AuthenticateClient(mapper.Map<Client>(client));
            if (user == null)
            {
                return Ok(await service.RegisterClient(mapper.Map<Client>(client)));


            }
            return BadRequest("Korisnik vec postoji u bazi.");

        }
        [HttpPost("/login")]
        public async Task<IActionResult> Login(LoginEmployeeDTO e)
        {

            var user = await service.Authenticate(mapper.Map<Employee>(e));
            if (user == null)
            {
                return BadRequest("Pogresno korisnicko ime ili lozinka.");
            }
            var token = GenerateToken(user);
            return Ok(new
            {
                token = token,
                user = user
            });
        }
        [HttpPost("/loginclient")]
        public async Task<IActionResult> LoginClient(LoginClientDTO e)
        {

            var user = await service.AuthenticateClient(mapper.Map<Client>(e));
            if (user == null)
            {
                return BadRequest("Pogresno korisnicko ime ili lozinka.");
            }
            var token = GenerateTokenClient(user);
            return Ok(new
            {
                token = token,
                user = user
            });
        }
    }
}
