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
    public class CreateSurveyCommand : IRequest<Response<SurveyResponse>>
    {
        public string SurveyName { get; set; }
        public string CreatedBy { get; set; }
    }
}
