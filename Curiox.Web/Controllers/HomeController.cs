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
            var questions = questionRepo.GetAll().ToList();
            var categories = categoryRepo.GetAll().ToList();
            var answers = answerRepo.GetAll().ToList();

            var questionViews = new List<IndexQuestionViewModel>();
            foreach (var qs in questions)
            {
                var questionAnswers = answers.Where(a => a.QuestionId == qs.Id);
                var firstAnswer = questionAnswers.FirstOrDefault();

                AnswerViewModel answerView = null;
                if (firstAnswer != null)
                {
                    answerView = new AnswerViewModel
                    {
                        Content = firstAnswer.Content,
                        QuestionId = firstAnswer.QuestionId,
                        UserName = users.Find(user => user.Id == firstAnswer.UserId).Username
                    };
                }
                
                var questionView = new IndexQuestionViewModel
                {
                    Id = qs.Id,
                    Title = qs.Title,
                    DateCreated = qs.DateCreated,
                    DateUpdated = qs.DateUpdated,
                    UserName = users.FirstOrDefault(user => user.Id == qs.UserId)?.Username,
                    CategoryName = categories.FirstOrDefault(cat => cat.Id == qs.CategoryId)?.Name,
                    FirstAnswer = answerView,
                    AnswerCounts = questionAnswers.Count()
                };

                questionViews.Add(questionView);
            }

            return View(questionViews);
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Question(int id)
        {
            var question = questionRepo.Get(id);

            if (question == null)
            {
                return NotFound();
            }

            var users = userRepo.GetAll().ToList();
            var categories = categoryRepo.GetAll().ToList();
                        
            var questionView = new QuestionViewModel
            {
                Title = question.Title,
                DateCreated = question.DateCreated,
                DateUpdated = question.DateUpdated,
                UserName = users.Find(user => user.Id == question.UserId)?.Username,
                CategoryName = categories.Find(cat => cat.Id == question.CategoryId)?.Name
            };

            var answers = answerRepo.GetAll(a => a.QuestionId == id).ToList();

            foreach (var answer in answers)
            {
                var answerView = new AnswerViewModel
                {
                    Content = answer.Content,
                    QuestionId = answer.QuestionId,
                    UserName = users.Find(user => user.Id == answer.UserId)?.Username
                };
                questionView.Answer.Add(answerView);
            }
            
            return View(questionView);
        }
    }
}
