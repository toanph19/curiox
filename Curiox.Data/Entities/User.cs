using System;
using System.Collections.Generic;

namespace Curiox.Data.Entities
{
    public partial class User : BaseEntity
    {
        public User()
        {
            Answer = new HashSet<Answer>();
            Question = new HashSet<Question>();
        }

        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
        public string Username { get; set; }

        public virtual ICollection<Answer> Answer { get; set; }
        public virtual ICollection<Question> Question { get; set; }
    }
}
