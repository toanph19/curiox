using System;
using System.Collections.Generic;

namespace Curiox.Data.Entities
{
    public partial class Question : BaseEntity
    {
        public Question()
        {
            Answer = new HashSet<Answer>();
        }

        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public int? UserId { get; set; }
        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Answer> Answer { get; set; }
    }
}
