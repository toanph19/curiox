using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curiox.Web.DTOs
{
    public class PostQuestionDTO
    {
        public string Token { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Category { get; set; }
    }
}
