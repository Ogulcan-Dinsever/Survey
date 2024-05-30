using AutoMapper;
using MediatR;
using Survey.Application.Commands.SurveyCommands;
using Survey.Application.Queries.SurveyQueries;
using Survey.Application.Repositories.Interfaces;
using Survey.Application.Responses;
using Survey.Application.Shared;
using Survey.Domain.SurveyAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Application.Handlers.SurveyHandlers.QueryHandlers
{
    public class GetAllSurveyHandler : IRequestHandler<GetAllSurveyQuery, Response<List<SurveyResponse>>>
    {
        private readonly IRepository<Surveys> _repository;
        private readonly IMapper _mapper;

        public GetAllSurveyHandler(IRepository<Surveys> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<List<SurveyResponse>>> Handle(GetAllSurveyQuery request, CancellationToken cancellationToken)
        {
            var allSurveys = await _repository.GetAll();

            if (allSurveys == null) 
                return Response<List<SurveyResponse>>.Success(new List<SurveyResponse>(), 200);

            var response = _mapper.Map<List<SurveyResponse>>(allSurveys);

            return Response<List<SurveyResponse>>.Success(response, 200);
        }
    }
}
