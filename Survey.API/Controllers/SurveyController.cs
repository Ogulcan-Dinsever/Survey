using MediatR;
using Microsoft.AspNetCore.Mvc;
using Survey.Application.Commands.SurveyCommands;
using Survey.Application.Commands.UserCommands;
using Survey.Application.Shared;

namespace Survey.API.Controllers
{
    [Route("api/Survey/[controller]")]
    [ApiController]
    public class SurveyController : CustomBaseController
    {
        private readonly IMediator _mediator;

        public SurveyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateSurvey")]
        public async Task<IActionResult> CreateSurvey(CreateSurveyCommand command)
        {
            var response = await _mediator.Send(command);

            return CreateActionResultInstance(response);
        }

        [HttpDelete("DeleteSurvey/{id}")]
        public async Task<IActionResult> DeleteSurvey(int id)
        {
            var response = await _mediator.Send(new DeleteSurveyCommand { SurveyId = id});

            return CreateActionResultInstance(response);
        }

        [HttpGet("GetAllSurvey")]
        public async Task<IActionResult> GetAllSurvey()
        {
            var response = await _mediator.Send(new GetAllSurveyQuery());

            return CreateActionResultInstance(response);
        }
    }
}
