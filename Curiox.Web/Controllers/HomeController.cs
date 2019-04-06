using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Curiox.Web.Models;
using Curiox.Data.Repositories;
using Curiox.Data;
using Curiox.Data.Context;
using Curiox.Data.Entities;

namespace Curiox.Web.Controllers
{
    public class HomeController : Controller
    {
        private IRepository<User> userRepo = new Repository<User>();
        private IRepository<Question> questionRepo = new Repository<Question>();

        public IActionResult Index()
        {
            var users = userRepo.GetAll();
            var user = users.First();

            ViewData["User"] = $"{user.Id} {user.Fullname}";
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult News()
        {
            ViewData["Message"] = "News.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
