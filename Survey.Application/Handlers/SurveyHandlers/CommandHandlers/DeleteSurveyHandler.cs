using MediatR;
using Survey.Application.Commands.SurveyCommands;
using Survey.Application.Commands.UserCommands;
using Survey.Application.Repositories.Interfaces;
using Survey.Application.Responses;
using Survey.Application.Shared;
using Survey.Domain.SurveyAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Application.Handlers.SurveyHandlers.CommandHandlers
{
    public class DeleteSurveyHandler : IRequestHandler<DeleteSurveyCommand, Response<bool>>
    {
        private readonly IRepository<Surveys> _repository;

        public DeleteSurveyHandler(IRepository<Surveys> repository)
        {
            _repository = repository;
        }
        public async Task<Response<bool>> Handle(DeleteSurveyCommand request, CancellationToken cancellationToken)
        {
            if (request.SurveyId <= 0)
                return Response<bool>.Fail("SurveyId cannot be 0 or smaller", 409);

            var survey = await _repository.Find(x => x.Status && x.Id == request.SurveyId);

            if (survey == null)
                return Response<bool>.Fail("This survey was not found", 409);

            survey.Status = false;
            survey.ModifiedDate = DateTime.UtcNow;

            await _repository.Update(survey);

            return Response<bool>.Success(true, 201);
        }
    }
}
