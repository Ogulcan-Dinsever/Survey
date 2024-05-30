using MediatR;
using Microsoft.AspNetCore.Mvc;
using Survey.Application.Commands.QuestionCommands;
using Survey.Application.Commands.UserCommands;
using Survey.Application.Shared;

namespace Survey.API.Controllers
{
    [Route("api/Survey/[controller]")]
    [ApiController]
    public class QuestionController : CustomBaseController
    {
        private readonly IMediator _mediator;

        public QuestionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateQuestion")]
        public async Task<IActionResult> CreateQuestion(CreateQuestionCommand command)
        {
            var response = await _mediator.Send(command);

            return CreateActionResultInstance(response);
        }
    }
}
