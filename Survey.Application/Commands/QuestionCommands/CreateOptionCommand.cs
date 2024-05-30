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
    public class CreateOptionCommand : IRequest<Response<OptionResponse>>
    {
        public int? QuestionId { get; set; }
        public string OptionText { get; set; }
    }
}
