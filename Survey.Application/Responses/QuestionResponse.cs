using Survey.Domain.SurveyAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Application.Responses
{
    public class QuestionResponse
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public int Order { get; set; }
        public List<OptionResponse>? Options { get; set; }
        public bool IsCheckedQuestion { get; set; }  //if this choise false == this option is text answer
    }
}
