using System;
using System.Collections.Generic;
using System.Text;

namespace Curiox.Data.Entities
{
    public class AnswerUpvote : BaseEntity
    {
        public int AnswerId { get; set; }
        public int UserId { get; set; }
    }
}
