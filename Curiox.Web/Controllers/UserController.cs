using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Curiox.Data.Entities;
using Curiox.Data.Repositories;
using Curiox.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Curiox.Web.Controllers
{
    public class UserController : Controller
    {
        private IRepository<User> userRepo = new Repository<User>();

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            
            return View();
        }
        
        [HttpGet]
        public JsonResult GetUser(string token)
        {
            var user = new User("Toan", "me@gmail.com", "123456");

            return Json(user);
        } 

        [HttpGet]
        public JsonResult GetAccessToken(string username, string password)
        {
            string accessToken = "SampleAccessToken";

            return Json(accessToken);
        }


        [HttpPost]
        public IActionResult Register(string username, string email, string password)
        {
            var user = new User(username, email, password);
            userRepo.Add(user);

            return View();
        }
    }
}