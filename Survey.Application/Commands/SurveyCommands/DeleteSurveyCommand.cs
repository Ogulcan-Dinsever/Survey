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
    public class DeleteSurveyCommand : IRequest<Response<bool>>
    {
        public int SurveyId { get; set; }
    }
}
