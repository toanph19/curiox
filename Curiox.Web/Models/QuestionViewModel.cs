using Curiox.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curiox.Web.Models
{
    public class QuestionViewModel : BaseQuestionViewModel
    {
        public QuestionViewModel()
        {
            Answer = new HashSet<AnswerViewModel>();
        }

        public virtual ICollection<AnswerViewModel> Answer { get; set; }

    }
}
