using BusinessLayer.Interfaces;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Context;
using System;
using System.Linq;

namespace ContactUser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserBL _userBL;
        IConfiguration _config;
        UserContext _context;

        public UserController(IUserBL user, IConfiguration config, UserContext context)
        {
            _userBL = user;
            _config = config;
            _context = context;
        }
        [HttpPost("register")]
        public IActionResult Registration(UserRegistration model)
        {
            var result = this._userBL.Register(model);

            return this.Ok(new { Success = true, message = "Registration data", Data = result });

        }
        [HttpPost("login")]
        public IActionResult LoginData(UserLogin userLogin)
        {
            LoginResponseModel result = this._userBL.Login(userLogin);

            return this.Ok(new { Success = true, message = "Logged In", Data = result });

        }
        [Authorize]
        [HttpPost("AddContact/{contactId}")]
        public IActionResult AddAContact(int contactId)
        {
            int userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
            var result = this._userBL.AddContact(userId, contactId);

            return this.Ok(new { Success = true, message = "contact got added" , Data = result});
        }

        [Authorize]
        [HttpDelete("{contactId}")]
        public IActionResult RemoveAContact(int contactId)
        {
            int userId = Convert.ToInt32(User.Claims.First(e => e.Type == "UserId").Value);
            var result = this._userBL.RemoveContact(userId, contactId);

            return this.Ok(new { Success = true, message = "contact got removed", Data = result });

        }

       
        [HttpGet("byName/{name}")]
        public IActionResult GetAllContactByNames(string name)
        {
            
            var result = this._userBL.GetContactsByUserName(name);

            return this.Ok(new { Success = true, message = "all contacts data via name", Data = result });
        }

        [HttpGet]
        public IActionResult AllUsers()
        {
            var result = this._userBL.GetAllUsers();

            return this.Ok(new { Success = true, message = "all contacts data", Data = result });


        }

    }
}
