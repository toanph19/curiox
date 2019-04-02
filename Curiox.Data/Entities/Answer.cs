using System;
using System.Collections.Generic;

namespace Curiox.Data.Entities
{
    public partial class Answer
    {
        public string Content { get; set; }
        public int UserId { get; set; }
        public int QuestionId { get; set; }
        public int Id { get; set; }

        public virtual Question Question { get; set; }
        public virtual User User { get; set; }
    }
}
