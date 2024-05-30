using MediatR;
using Survey.Application.Responses;
using Survey.Application.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Application.Commands.QuestionCommands
{
    public class CreateQuestionCommand : IRequest<Response<QuestionResponse>>
    {
        public int SurveyId { get; set; }
        public string QuestionText { get; set; }
        public int Order { get; set; }
        public bool IsCheckedQuestion { get; set; }
        public List<CreateOptionCommand>? Options { get; set; }
    }
}
