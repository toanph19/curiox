using System;
using System.Collections.Generic;

namespace Curiox.Data.Entities
{
    public partial class Answer : BaseEntity
    {
        public string Content { get; set; }
        public int UserId { get; set; }
        public int QuestionId { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

        public virtual Question Question { get; set; }
        public virtual User User { get; set; }
    }
}
