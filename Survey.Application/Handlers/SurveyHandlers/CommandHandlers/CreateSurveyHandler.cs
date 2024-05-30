using AutoMapper;
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
    public class CreateSurveyHandler : IRequestHandler<CreateSurveyCommand, Response<SurveyResponse>>
    {
        private readonly IRepository<Surveys> _repository;
        private readonly IMapper _mapper;

        public CreateSurveyHandler(IRepository<Surveys> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<SurveyResponse>> Handle(CreateSurveyCommand request, CancellationToken cancellationToken)
        {
            if (String.IsNullOrWhiteSpace(request.SurveyName))
                return Response<SurveyResponse>.Fail("SurveyName cannot be empty", 409);

            var isThere = await _repository.Any(x => x.Status && x.SurveyName == request.SurveyName);

            if (isThere)
                return Response<SurveyResponse>.Fail("This survey is already exist", 409);

            Surveys survey = new Surveys
            {
                SurveyName = request.SurveyName,
                CreatedDate = DateTime.UtcNow,
                CreatedBy = request.CreatedBy,
            };

            await _repository.Create(survey);

            var response = _mapper.Map<SurveyResponse>(survey);

            return Response<SurveyResponse>.Success(response, 201);
        }
    }
}
