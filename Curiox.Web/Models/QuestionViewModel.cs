using Curiox.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curiox.Web.Models
{
    public class QuestionViewModel : BaseEntity
    {
        public QuestionViewModel()
        {
            Answer = new HashSet<AnswerViewModel>();
        }

        public string Title { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string UserName { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<AnswerViewModel> Answer { get; set; }
    }
}
