using Curiox.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curiox.Web.Models
{
    public class AnswerViewModel : BaseEntity
    {
        public string Content { get; set; }
        public string UserName { get; set; }
        public int QuestionId { get; set; }
        public int UpvoteCount { get; set; }
        public int Liked { get; set; }
    }
}
