using AutoMapper;
using ChatDev.Algorithms;
using ChatDev.Contracts;
using ChatDev.Data;
using ChatDev.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChatDev.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;


        public AuthController(IUsersRepository usersRepository, IMapper mapper)
        {
            _mapper = mapper;
            _usersRepository = usersRepository;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Find the user by email
            var user = await _usersRepository.GetUserByEmail(model.Email);

            if (user == null)
            {
                return NotFound("User not found.");
            }

            return Ok("Authentication successful.");
        }

 
    }
}
