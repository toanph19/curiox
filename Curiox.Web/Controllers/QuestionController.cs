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
        private IRepository<QuestionUpvote> questionUpvoteRepo = new Repository<QuestionUpvote>();
        private IRepository<AnswerUpvote> answerUpvoteRepo = new Repository<AnswerUpvote>();

        [HttpPost("/Api/Question")]
        public IActionResult PostQuestion([FromBody] PostQuestionDTO questionDTO)
        {
            var token = questionDTO.Token;
            var user = userRepo.GetByToken(token);
            if (user == null)
            {
                return BadRequest();
            }

            var category = categoryRepo.FirstOrDefault(c => c.Name == questionDTO.Category);
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
            var upvotes = questionUpvoteRepo.GetAll(q => q.QuestionId == questionId);
            
            return Json(upvotes);
        }

        [HttpGet("/Api/Answer/Upvote")]
        public IActionResult GetAnswerUpvotes(int answerId)
        {
            var upvotes = answerUpvoteRepo.GetAll(q => q.AnswerId == answerId);

            return Json(upvotes);
        }

        [HttpPost("/Api/Question/Upvote")]
        public IActionResult UpvoteQuestion(int questionId, [FromBody] UserTokenDTO tokenDTO)
        {
            var token = tokenDTO.Token;
            var user = userRepo.GetByToken(token);
            if (user == null)
            {
                return BadRequest();
            }

            var upvote = questionUpvoteRepo.FirstOrDefault(u => u.UserId == user.Id && u.QuestionId == questionId);
            if (upvote != null)
            {
                return BadRequest();
            }
            
            upvote = new QuestionUpvote()
            {
                QuestionId = questionId,
                UserId = user.Id
            };
            questionUpvoteRepo.Add(upvote);

            return CreatedAtAction("Index", null);
        }

        [HttpPost("/Api/Answer/Upvote")]
        public IActionResult UpvoteAnswer(int answerId, [FromBody] UserTokenDTO tokenDTO)
        {
            var token = tokenDTO.Token;
            var user = userRepo.GetByToken(token);
            if (user == null)
            {
                return BadRequest();
            }

            var upvote = answerUpvoteRepo.FirstOrDefault(u => u.UserId == user.Id && u.AnswerId == answerId);
            if (upvote != null)
            {
                return BadRequest();
            }

            upvote = new AnswerUpvote()
            {
                AnswerId = answerId,
                UserId = user.Id
            };
            answerUpvoteRepo.Add(upvote);

            return CreatedAtAction("Index", null);
        }

        [HttpDelete("/Api/Question/Upvote")]
        public IActionResult DeleteUpvoteQuestion(int questionId, [FromBody] UserTokenDTO tokenDTO)
        {
            var token = tokenDTO.Token;
            var user = userRepo.GetByToken(token);
            if (user == null)
            {
                return BadRequest();
            }

            var upvote = questionUpvoteRepo.FirstOrDefault(u => u.UserId == user.Id && u.QuestionId == questionId);
            if (upvote == null)
            {
                return BadRequest();
            }
            questionUpvoteRepo.Delete(upvote);

            return Ok();
        }

        [HttpDelete("/Api/Answer/Upvote")]
        public IActionResult DeleteUpvoteAnswer(int answerId, [FromBody] UserTokenDTO tokenDTO)
        {
            var token = tokenDTO.Token;
            var user = userRepo.GetByToken(token);
            if (user == null)
            {
                return BadRequest();
            }

            var upvote = answerUpvoteRepo.FirstOrDefault(u => u.UserId == user.Id && u.AnswerId == answerId);
            if (upvote == null)
            {
                return BadRequest();
            }
            answerUpvoteRepo.Delete(upvote);

            return Ok();
        }
    }
}