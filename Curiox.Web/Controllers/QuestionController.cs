using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Curiox.Data.Entities;
using Curiox.Data.Repositories;
using Curiox.Web.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Curiox.Web.Controllers
{
    public class QuestionController : Controller
    {
        private UserRepo userRepo = new UserRepo();
        private IRepository<Question> questionRepo = new Repository<Question>();
        private IRepository<Category> categoryRepo = new Repository<Category>();
        private IRepository<Answer> answerRepo = new Repository<Answer>();

        [HttpPost("/Api/Question")]
        public IActionResult PostQuestion([FromBody] PostQuestionDTO questionDTO)
        {
            var token = questionDTO.Token;
            var user = userRepo.GetByToken(token);
            if (user == null)
            {
                return BadRequest();
            }

            var category = categoryRepo.First(c => c.Name == questionDTO.Category);
            if (category == null)
            {
                return BadRequest();
            }

            var question = new Question()
            {
                CategoryId = category.Id,
                Title = questionDTO.Title,
                UserId = user.Id,
                DateCreated = DateTime.Now,

            };
            questionRepo.Add(question);

            return CreatedAtAction("Index", null);
        }

        [HttpPost("/Api/Answer")]
        public IActionResult PostAnswer([FromBody] PostAnswerDTo answerDTO)
        {
            var token = answerDTO.Token;
            var user = userRepo.GetByToken(token);
            if (user == null)
            {
                return BadRequest();
            }

            var answer = new Answer()
            {
                Content = answerDTO.Content,
                UserId = user.Id,
                QuestionId = answerDTO.QuestionId
            };
            answerRepo.Add(answer);

            return CreatedAtAction(nameof(Question), answerDTO.QuestionId);
        }
        
        [HttpGet("/Api/Question/Upvote")]
        public IActionResult GetQuestionUpvotes(int questionId)
        {
            throw new NotImplementedException();
        }

        [HttpGet("/Api/Answer/Upvote")]
        public IActionResult GetAnswerUpvotes(int answerId)
        {
            throw new NotImplementedException();
        }

        [HttpPost("/Api/Question/Upvote")]
        public IActionResult UpvoteQuestion(int questionId, [FromBody] UserTokenDTO tokenDTO)
        {
            return CreatedAtAction("Index", null);
        }

        [HttpPost("/Api/Answer/Upvote")]
        public IActionResult UpvoteAnswer(int answerId, [FromBody] UserTokenDTO tokenDTO)
        {
            return CreatedAtAction("Index", null);
        }

    }
}