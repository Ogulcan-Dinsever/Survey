using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Survey.Application.Commands.SurveyCommands;
using Survey.Application.Commands.UserCommands;
using Survey.Application.Queries.SurveyQueries;
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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateSurvey(CreateSurveyCommand command)
        {
            var response = await _mediator.Send(command);

            return CreateActionResultInstance(response);
        }

        [HttpDelete("DeleteSurvey/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteSurvey(int id)
        {
            var response = await _mediator.Send(new DeleteSurveyCommand { SurveyId = id });

            return CreateActionResultInstance(response);
        }

        [HttpGet("GetAllSurvey")]
        [Authorize(Roles = "User, Admin")]
        public async Task<IActionResult> GetAllSurvey()
        {
            var response = await _mediator.Send(new GetAllSurveyQuery());

            return CreateActionResultInstance(response);
        }

        [HttpGet("GetSurveyBy/{id}")]
        [Authorize(Roles = "User, Admin")]
        public async Task<IActionResult> GetSurveyById(int id)
        {
            var response = await _mediator.Send(new GetSurveyByIdQuery());

            return CreateActionResultInstance(response);
        }




        [HttpPost("SaveSurveyAnswers")]
        [Authorize(Roles = "User, Admin")]
        public async Task<IActionResult> SaveSurveyAnswers(SaveSurveyAnswersCommand command)
        {
            var response = await _mediator.Send(command);

            return CreateActionResultInstance(response);
        }
    }
}
