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
        private IRepository<Category> categoryRepo = new Repository<Category>();
        private IRepository<Answer> answerRepo = new Repository<Answer>();
        public IActionResult Index()
        {
            var users = userRepo.GetAll().ToList();
            var questions = questionRepo.GetAll();
            var categories = categoryRepo.GetAll().ToList();
            var answers = answerRepo.GetAll().ToList();
            List<QuestionViewModel> questionViews = new List<QuestionViewModel>();
            foreach(var qs in questions)
            {
                foreach(var item in answers)
                {
                    if (item.QuestionId == qs.Id) qs.Answer.Add(item);
                }
                var questionView = new QuestionViewModel
                {
                    Title = qs.Title,
                    DateCreated = qs.DateCreated,
                    DateUpdated = qs.DateUpdated,
                    UserName = users.Find(user => user.Id == qs.UserId).Username,
                    CategoryName = categories.Find(cat => cat.Id == qs.CategoryId).Name
                };
                foreach (var item in qs.Answer)
                {
                    var ans = new AnswerViewModel
                    {
                        Content = item.Content,
                        QuestionId = item.QuestionId,
                        UserName = users.Find(user => user.Id == item.UserId).Username
                    };
                    questionView.Answer.Add(ans);
                }
                questionViews.Add(questionView);
            }            
            return View(questionViews);

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

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Question()
        {
            return View();
        }
    }
}
