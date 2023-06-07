using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EntityFrameworkDemo2.Db;
using EntityFrameworkDemo2.Models;
using EntityFrameworkDemo2.DTO;

namespace EntityFrameworkDemo2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DemoDbContext _context;

        public UsersController(DemoDbContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
         
            var users = await _context.Users
                .Include(x=>x.Address)
                .ToListAsync();


            var userDTOs = users.Select(user => new UserDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                MiddleName = user.MiddleName,
                LastName = user.LastName,
                Address = user.Address != null ? new UserAddressDTO
                {
                    Id = user.Address.Id,
                    AddressLine1 = user.Address.AddressLine1,
                    AddressLine2 = user.Address.AddressLine2,
                    City = user.Address.City,
                    Country = user.Address.Country
                } : null
            }).ToList();

            return userDTOs;
        }



        // POST: api/Users/attach
        [HttpPost("attach")]
        public async Task<ActionResult<UserDTO>> AttachUser([FromBody]UserDTO userDTO)
        {

            if (userDTO == null) {

                return BadRequest(userDTO);
            }

            var user = new User
            {
                Id = userDTO.Id,
                FirstName = userDTO.FirstName,
                MiddleName = userDTO.MiddleName,
                LastName = userDTO.LastName,
                Address = userDTO.Address != null ? new UserAddress {

                    Id = userDTO.Address.Id,
                    AddressLine1 = userDTO.Address.AddressLine1,
                    AddressLine2 = userDTO.Address.AddressLine2,
                    City = userDTO.Address.City,
                    Country = userDTO.Address.Country


                }:null

            };

    
                _context.Users.Attach(user);
                await _context.SaveChangesAsync();

                return Ok(userDTO);
            
        }


       // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var user = await _context.Users.Include(u => u.Address).FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);

            // Also delete the associated UserAddress if it exists
            if (user.Address != null)
            {
                _context.UserAddress.Remove(user.Address);
            }

            await _context.SaveChangesAsync();

            return NoContent();
        }

       // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult>PutUser(Guid id,[FromBody] UserDTO userDTO)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return BadRequest();
            }

            user.FirstName= userDTO.FirstName;
            user.LastName= userDTO.LastName;
            user.MiddleName= userDTO.MiddleName;

            if (userDTO.Address != null)
            {
                if (user.Address == null)
                {
                    user.Address = new UserAddress();
                }

                user.Address.AddressLine1 = userDTO.Address.AddressLine1;
                user.Address.AddressLine2 = userDTO.Address.AddressLine2;
                user.Address.City = userDTO.Address.City;
                user.Address.Country = userDTO.Address.Country;
            }
            else
            {
                user.Address = null;
            }

            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool UserExists(Guid id)
        {
            return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
