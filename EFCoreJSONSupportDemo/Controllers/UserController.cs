using Azure;
using EFCoreJSONSupportDemo.Data;
using EFCoreJSONSupportDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace EFCoreJSONSupportDemo.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public UserController(DataContext dataContext) 
        {
            _dataContext = dataContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(User user)
        {
            try
            {
                _dataContext.Users.Add(user);
                await _dataContext.SaveChangesAsync();
                return Ok(user);
            }
            catch (Exception  ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("user/filterByCategory")]
        public async Task<IActionResult> GetUsersByHobbiesCategory(string category)
        {
            var usersByCategory = await _dataContext.Users.Where(o => o.Hobbies.Any(x => x.Category == category)).ToListAsync();
            return Ok(usersByCategory);
        }

        [HttpGet("user/filterByHobbyName")]
        public async Task<IActionResult> GetUsersByHobbyName(string hobbyName)
        {
            var usersByHobbyName = await _dataContext.Users.Where(o => o.Hobbies.Any(x => x.Name == hobbyName)).ToListAsync();
            return Ok(usersByHobbyName);
        }
    }
}
