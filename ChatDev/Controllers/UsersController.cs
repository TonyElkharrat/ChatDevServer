using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChatDev.Data;
using AutoMapper;
using ChatDev.Contracts;
using ChatDev.DTOS;
using ChatDev.Repository;
using ChatDev.Third_Party;
using ChatDev.Algorithms;

namespace ChatDev.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;

        public UsersController(IUsersRepository usersRepository, IConfiguration configuration, IMapper mapper)
        {
            this._mapper = mapper;
            this._usersRepository = usersRepository;
        }

        // GET: Users
        //public async Task<ActionResult<UserDto>> GetUser([FromQuery] string userEmail)
        //{
            
        //    if (user is not null)
        //    {
        //        var userDto = _mapper.Map<UserDto>(user);
        //        return Ok(userDto);
        //    }
        //    return BadRequest();
        //}

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,Lastname,Email")] UserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!UserExists(userDto.Email).Result)
            {
                return BadRequest("user already exist");
            }

            //var captchaResponse = await CaptchaValidation.IsCaptchaTokenValidAsync(model.CaptchaToken, _configuration);
            //if (!captchaResponse)
            //{
            //    return BadRequest("Captcha Not Valid");
            //}
            var user= _mapper.Map<User>(userDto);

            await _usersRepository.AddAsync(user);
            return Ok("Authentication successful.");
        }

        // GET: Users/Edit/5
        //public async Task<IActionResult> Edit(Guid? id)
        //{
        //    if (id == null || _context.Users == null)
        //    {
        //        return NotFound();
        //    }

        //    var user = await _context.Users.FindAsync(id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(user);
        //}

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(Guid id, [Bind("Id,FirstName,Lastname,Email")] User user)
        //{
        //    if (id != user.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(user);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!UserExists(user.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(user);
        //}

        //// GET: Users/Delete/5
        //public async Task<IActionResult> Delete(Guid? id)
        //{
        //    if (id == null || _context.Users == null)
        //    {
        //        return NotFound();
        //    }

        //    var user = await _context.Users
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(user);
        //}

        //// POST: Users/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(Guid id)
        //{
        //    if (_context.Users == null)
        //    {
        //        return Problem("Entity set 'ChatDevDbContext.Users'  is null.");
        //    }
        //    var user = await _context.Users.FindAsync(id);
        //    if (user != null)
        //    {
        //        _context.Users.Remove(user);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private async Task<bool> UserExists(string email)
        {
            var user = await _usersRepository.GetUserByEmail(email);

            return user is null;
        }
    }
}
