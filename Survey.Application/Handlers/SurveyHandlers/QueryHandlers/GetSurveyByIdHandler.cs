using AutoMapper;
using MediatR;
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
    public class GetSurveyByIdHandler : IRequestHandler<GetSurveyByIdQuery, Response<SurveyResponse>>
    {
        private readonly IRepository<Surveys> _repository;
        private readonly IRepository<Question> _questionRepository;
        private readonly IRepository<Option> _optionRepository;
        private readonly IMapper _mapper;

        public GetSurveyByIdHandler(IRepository<Surveys> repository, IRepository<Question> questionRepository, IRepository<Option> optionRepository, IMapper mapper)
        {
            _repository = repository;
            _questionRepository = questionRepository;
            _optionRepository = optionRepository;
            _mapper = mapper;
        }
        public async Task<Response<SurveyResponse>> Handle(GetSurveyByIdQuery request, CancellationToken cancellationToken)
        {
            if (request.SurveyId <= 0)
                return Response<SurveyResponse>.Fail("SurveyId cannot be 0 or smaller", 409);

            var survey = await _repository.Find(x=> x.Id == request.SurveyId);

            if (survey == null)
                return Response<SurveyResponse>.Fail("This survey was not found", 409);

            var response = _mapper.Map<SurveyResponse>(survey);

            var questions = await _questionRepository.GetAll(x=> x.SurveyId == survey.Id);

            if (questions == null)
                return Response<SurveyResponse>.Success(response, 200);

            var questionsResponse = _mapper.Map<List<QuestionResponse>>(questions).OrderBy(x=> x.Order).ToList();


            List<Option> options = new List<Option>();

            foreach (var question in questionsResponse)
            {
                if (!question.IsCheckedQuestion)
                    continue;

                options = await _optionRepository.GetAll(x => x.QuestionId == question.Id);

                question.Options = _mapper.Map<List<OptionResponse>>(options);
            }

            response.Questions = questionsResponse;

            return Response<SurveyResponse>.Success(response, 200);
        }
    }
}
