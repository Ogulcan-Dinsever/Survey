using AutoMapper;
using MediatR;
using Survey.Application.Commands.QuestionCommands;
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

namespace Survey.Application.Handlers.QuestionHandlers.CommandHandlers
{
    public class CreateQuestionHandler : IRequestHandler<CreateQuestionCommand, Response<QuestionResponse>>
    {
        private readonly IRepository<Question> _repository;
        private readonly IRepository<Option> _optionRepository;
        private readonly IMapper _mapper;

        public CreateQuestionHandler(IRepository<Question> repository, IRepository<Option> optionRepository, IMapper mapper)
        {
            _repository = repository;
            _optionRepository = optionRepository;
            _mapper = mapper;
        }
        public async Task<Response<QuestionResponse>> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
        {
            if (String.IsNullOrEmpty(request.QuestionText))
                return Response<QuestionResponse>.Fail("Question Text cannot be empty", 409);

            var isThere = await _repository.Any(x => x.SurveyId == request.SurveyId && x.QuestionText == request.QuestionText);

            if (isThere)
                return Response<QuestionResponse>.Fail("This Question is already exist", 409);

            Question question = new Question
            {
                QuestionText = request.QuestionText,
                SurveyId = request.SurveyId,
                CreatedDate = DateTime.UtcNow,
                IsCheckedQuestion = request.IsCheckedQuestion,
                Order = request.Order
            };

            await _repository.Create(question);

            var response = _mapper.Map<QuestionResponse>(question);

            if (request.IsCheckedQuestion)
                return Response<QuestionResponse>.Success(response, 201);

            List<OptionResponse> optionResponse = new List<OptionResponse>();

            foreach (var option in request.Options)
            {
                Option data = new Option
                {
                    QuestionId = question.Id,
                    OptionText = option.OptionText,
                    CreatedDate = DateTime.UtcNow,
                };

                await _optionRepository.Create(data);

                var mapOption = _mapper.Map<OptionResponse>(data);

                optionResponse.Add(mapOption);
            }

            response.Options = optionResponse;

            return Response<QuestionResponse>.Success(response, 201);
        }
    }
}
