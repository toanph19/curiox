using Curiox.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curiox.Web.Models
{
    public class IndexViewModel
    {
        public IEnumerable<IndexQuestionViewModel> QuestionsAndAnswers { get; set; }
        public IEnumerable<IndexCategoryViewModel> Categories { get; set; }
    }
}
