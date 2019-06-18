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
using Curiox.Web.DTOs;

namespace Curiox.Web.Controllers
{
    public class HomeController : Controller
    {
        private UserRepo userRepo = new UserRepo();
        private IRepository<Question> questionRepo = new Repository<Question>();
        private IRepository<Category> categoryRepo = new Repository<Category>();
        private IRepository<Answer> answerRepo = new Repository<Answer>();
        private IRepository<QuestionUpvote> questionUpvoteRepo = new Repository<QuestionUpvote>();
        private IRepository<AnswerUpvote> answerUpvoteRepo = new Repository<AnswerUpvote>();

        public IActionResult Index()
        {
            var users = userRepo.GetAll().ToList();
            var categories = categoryRepo.GetAll().ToList();
            var questions = questionRepo.GetAll().OrderByDescending(q => q.DateCreated).ToList();
            var questionUpvotes = questionUpvoteRepo.GetAll();
            //var answers = answerRepo.GetAll().ToList();

            var viewModel = new IndexViewModel();

            var categoryViews = categories.Select(c => new IndexCategoryViewModel
            {
                Id = c.Id,
                Name = c.Name
            });

            var qaViews = new List<IndexQuestionViewModel>();
            foreach (var qs in questions)
            {
                //var questionAnswers = answers.Where(a => a.QuestionId == qs.Id);
                //var firstAnswer = questionAnswers.FirstOrDefault();


                AnswerViewModel answerView = null;
                //if (firstAnswer != null)
                //{
                //    answerView = new AnswerViewModel
                //    {
                //        Content = firstAnswer.Content?.Substring(0, Math.Min(IndexQuestionViewModel.MaxAnswerDisplayLength, firstAnswer.Content.Length)),
                //        QuestionId = firstAnswer.QuestionId,
                //        UserName = users.Find(user => user.Id == firstAnswer.UserId).Username,
                //        DateCreated = firstAnswer.DateCreated,
                //        DateUpdated= firstAnswer.DateUpdated
                //    };
                //}

                var questionLiked = questionUpvotes.FirstOrDefault(up => up.UserId == qs.UserId && up.QuestionId == qs.Id) == null ? 0 : 1;
                var qaView = new IndexQuestionViewModel
                {
                    Id = qs.Id,
                    Title = qs.Title,
                    Content = qs.Content?.Substring(0, Math.Min(IndexQuestionViewModel.MaxAnswerDisplayLength, qs.Content.Length)),
                    DateCreated = qs.DateCreated,
                    DateUpdated = qs.DateUpdated,
                    UserName = users.FirstOrDefault(user => user.Id == qs.UserId)?.Username,
                    Category = categories.FirstOrDefault(cat => cat.Id == qs.CategoryId)?.Name,
                    FirstAnswer = answerView,
                    //AnswerCounts = questionAnswers.Count(),
                    UpvoteCount = questionUpvotes.Count(u => u.QuestionId == qs.Id),
                    Liked = questionLiked
                };

                qaViews.Add(qaView);
            }

            viewModel.QuestionsAndAnswers = qaViews;
            viewModel.Categories = categoryViews;

            return View(viewModel);
        }

        //[HttpGet("/Home/Category/{category}")]
        [HttpGet("/Category/{category}")]
        public IActionResult Category(string category)
        {
            var categories = categoryRepo.GetAll().ToList();
            var categoryObj = categories.FirstOrDefault(c => c.Name == category);
            if (categoryObj == null)
            {
                return BadRequest();
            }
            var categoryId = categoryObj.Id;

            var users = userRepo.GetAll().ToList();
            var questions = questionRepo.GetAll(q => q.CategoryId == categoryId).OrderByDescending(q => q.DateCreated).ToList();
            var answers = answerRepo.GetAll().ToList();
            var questionUpvotes = questionUpvoteRepo.GetAll();

            var viewModel = new IndexViewModel();

            var categoryViews = categories.Select(c => new IndexCategoryViewModel
            {
                Id = c.Id,
                Name = c.Name
            });

            var qaViews = new List<IndexQuestionViewModel>();
            foreach (var qs in questions)
            {
                var questionAnswers = answers.Where(a => a.QuestionId == qs.Id);
                var firstAnswer = questionAnswers.FirstOrDefault();

                AnswerViewModel answerView = null;
                if (firstAnswer != null)
                {
                    answerView = new AnswerViewModel
                    {
                        Content = firstAnswer.Content.Substring(0, Math.Min(IndexQuestionViewModel.MaxAnswerDisplayLength, firstAnswer.Content.Length)),
                        QuestionId = firstAnswer.QuestionId,
                        UserName = users.Find(user => user.Id == firstAnswer.UserId).Username,
                        DateCreated = firstAnswer.DateCreated,
                        DateUpdated= firstAnswer.DateUpdated
                    };
                }

                var questionLiked = questionUpvotes.FirstOrDefault(up => up.UserId == qs.UserId && up.QuestionId == qs.Id) == null ? 0 : 1;
                var qaView = new IndexQuestionViewModel
                {
                    Id = qs.Id,
                    Title = qs.Title,
                    Content = qs.Content?.Substring(0, Math.Min(IndexQuestionViewModel.MaxAnswerDisplayLength, qs.Content.Length)),
                    DateCreated = qs.DateCreated,
                    DateUpdated = qs.DateUpdated,
                    UserName = users.FirstOrDefault(user => user.Id == qs.UserId)?.Username,
                    Category = categories.FirstOrDefault(cat => cat.Id == qs.CategoryId)?.Name,
                    FirstAnswer = answerView,
                    AnswerCounts = questionAnswers.Count(),
                    UpvoteCount = questionUpvotes.Count(u => u.QuestionId == qs.Id),
                    Liked = questionLiked
                };

                qaViews.Add(qaView);
            }

            viewModel.QuestionsAndAnswers = qaViews;
            viewModel.Categories = categoryViews;

            return View(viewModel);
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
            var questionUpvotes = questionUpvoteRepo.GetAll();

            var questionLiked = questionUpvotes.FirstOrDefault(up => up.UserId == question.UserId && up.QuestionId == question.Id) == null ? 0 : 1;
            var questionView = new QuestionViewModel
            {
                Title = question.Title,
                Content = question.Content,
                DateCreated = question.DateCreated,
                DateUpdated = question.DateUpdated,
                UserName = users.Find(user => user.Id == question.UserId)?.Username,
                Category = categories.Find(cat => cat.Id == question.CategoryId)?.Name,
                UpvoteCount = questionUpvotes.Count(u => u.QuestionId == question.Id),
                Liked = questionLiked
            };

            var answers = answerRepo.GetAll(a => a.QuestionId == id).ToList();
            var answerUpvotes = answerUpvoteRepo.GetAll();

            foreach (var answer in answers)
            {
                var answerLiked = answerUpvotes.FirstOrDefault(u => u.UserId == answer.UserId && u.AnswerId == answer.Id) == null ? 0 : 1;

                var answerView = new AnswerViewModel
                {
                    Id = answer.Id,
                    Content = answer.Content,
                    QuestionId = answer.QuestionId,
                    UserName = users.Find(user => user.Id == answer.UserId)?.Username,
                    UpvoteCount = answerUpvotes.Count(u => u.AnswerId == answer.Id),
                    Liked = answerLiked,
                    DateCreated = answer.DateCreated,
                    DateUpdated = answer.DateUpdated
                };
                questionView.Answer.Add(answerView);
            }
            
            return View(questionView);
        }
    }
}
