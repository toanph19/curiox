using System;
using System.Collections.Generic;
using System.Text;

namespace Curiox.Data.Entities
{
    public class QuestionUpvote : BaseEntity
    {
        public int QuestionId { get; set; }
        public int UserId { get; set; }
    }
}
