using MediatR;
using Survey.Application.Responses;
using Survey.Application.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Application.Commands.SurveyCommands
{
    public class SaveSurveyAnswersCommand : IRequest<Response<bool>>
    {
        public int UserId { get; set; }
        public int SurveyId { get; set; }
        public List<QuestionAnswer>? QuestionAnswers { get; set; }
        public class QuestionAnswer
        {
            public int QuestionId { get; set; }
            public bool IsCheckedQuestion { get; set; }  //if this choise false == this option is text answer
            public string? TextAnswer { get; set; }
            public List<int>? OptionIds { get; set; }
        }
    }

}
