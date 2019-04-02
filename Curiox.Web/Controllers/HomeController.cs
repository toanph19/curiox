using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Curiox.Web.Models;
using Curiox.Data.Repositories;

namespace Curiox.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            string items = new UserRepo().GetUser(0);
            ViewData["Items"] = items;
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

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
