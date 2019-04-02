using System;
using System.Collections.Generic;

namespace Curiox.Data.Entities
{
    public partial class Category
    {
        public Category()
        {
            Question = new HashSet<Question>();
        }

        public string Name { get; set; }
        public int Id { get; set; }

        public virtual ICollection<Question> Question { get; set; }
    }
}
