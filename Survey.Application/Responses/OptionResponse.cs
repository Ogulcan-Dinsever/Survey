using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Application.Responses
{
    public class OptionResponse
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string OptionText { get; set; }
    }
}
