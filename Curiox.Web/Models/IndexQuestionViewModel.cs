using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curiox.Web.Models
{
    public class IndexQuestionViewModel : BaseQuestionViewModel
    {
        public AnswerViewModel FirstAnswer { get; set; }
        public int AnswerCounts { get; set; }
        public static int MaxAnswerDisplayLength { get; } = 400;
    }
}
