using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curiox.Web.DTOs
{
    public class PostAnswerDTo
    {
        public string Token { get; set; }
        public string Content { get; set; }

        [JsonProperty(PropertyName = "question_id")]
        public int QuestionId { get; set; }
    }
}
