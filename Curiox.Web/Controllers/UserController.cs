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

        [HttpPost]
        public IActionResult Register(string name, string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}