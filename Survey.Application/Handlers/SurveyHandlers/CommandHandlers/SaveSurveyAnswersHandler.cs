using MediatR;
using Survey.Application.Commands.SurveyCommands;
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
    public class SaveSurveyAnswersHandler : IRequestHandler<SaveSurveyAnswersCommand, Response<bool>>
    {
        private readonly IRepository<Answers> _repository;
        private readonly IRepository<Surveys> _surveyRepository;
        private readonly IRepository<Question> _questionRepository;
        private readonly IRepository<Option> _optionRepository;

        public SaveSurveyAnswersHandler(IRepository<Answers> repository, IRepository<Surveys> surveyRepository, IRepository<Question> questionRepository, IRepository<Option> optionRepository)
        {
            _repository = repository;
            _surveyRepository = surveyRepository;
            _questionRepository = questionRepository;
            _optionRepository = optionRepository;
        }
        public async Task<Response<bool>> Handle(SaveSurveyAnswersCommand request, CancellationToken cancellationToken)
        {
            if (request == null) { return Response<bool>.Fail("Request cannot be empty", 409); }

            if (request.SurveyId <= 0 || request.UserId <= 0) { return Response<bool>.Fail("Request cannot be empty", 409); }

            if (request.QuestionAnswers == null || request.QuestionAnswers.Count <= 0)
            {
                Answers answer = new Answers
                {
                    SurveyId = request.SurveyId,
                    UserId = request.UserId,
                    CreatedDate = DateTime.UtcNow
                };

                await _repository.Create(answer);

                return Response<bool>.Success(true, 201);
            }

            foreach (var questionAnswer in request.QuestionAnswers)
            {
                Answers answer = new Answers
                {
                    SurveyId = request.SurveyId,
                    QuestionId = questionAnswer.QuestionId,
                    UserId = request.UserId,
                    OptionIds = questionAnswer.OptionIds,
                    TextAnswer = questionAnswer.TextAnswer,
                    CreatedDate = DateTime.UtcNow
                };
                await _repository.Create(answer);
            }

            return Response<bool>.Success(true, 201);
        }
    }
}
