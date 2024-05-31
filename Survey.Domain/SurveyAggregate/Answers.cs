using Survey.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Domain.SurveyAggregate
{
    public class Answers : BaseEntity
    {
        public int UserId { get; set; }
        public int SurveyId { get; set; }
        public int QuestionId { get; set; }
        public bool IsCheckedQuestion { get; set; }  //if this choise false == this option is text answer
        public string? TextAnswer { get; set; }
        public List<int>? OptionIds { get; set; }
    }
}
