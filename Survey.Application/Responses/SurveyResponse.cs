using Survey.Domain.SurveyAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Application.Responses
{
    public class SurveyResponse
    {
        public int Id { get; set; }
        public string SurveyName { get; set; }
        public List<QuestionResponse>? Questions { get; set; }
    }
}
