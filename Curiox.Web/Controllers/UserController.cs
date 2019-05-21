using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Curiox.Data.Entities;
using Curiox.Data.Repositories;
using Curiox.Web.DTOs;
using Curiox.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Curiox.Web.Controllers
{
    public class UserController : Controller
    {
        private UserRepo userRepo = new UserRepo();

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("/Api/SignUp")]
        public IActionResult Register([FromBody] UserRegisterDTO userDTO)
        {
            var user = new User(userDTO.Username, userDTO.Email, userDTO.Password);
            userRepo.Add(user);

            var message = "Success";

            return Json(message);
        }

        [HttpPost("/Api/Login")]
        public IActionResult Login([FromBody] UserLoginDTO userDTO)
        {
            var user = userRepo.Get(userDTO.Email, userDTO.Password);
            if (user != null)
            {
                return GetAccessToken(userDTO.Email, userDTO.Password);
            }

            return NotFound();
        }

        [HttpGet]
        public IActionResult GetAccessToken(string email, string password)
        {
            // Note: currently access token is email
            string accessToken = email;

            return Json(accessToken);
        }

        [HttpGet]
        public IActionResult GetUser(string token)
        {
            // Note: currently access token is email
            var email = token;
            var user = userRepo.Get(email);

            //if (user == null)
            //{
            //    return NotFound();
            //}

            return Json(user);
        }
    }
}