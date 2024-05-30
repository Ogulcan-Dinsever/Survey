using Survey.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Domain.SurveyAggregate
{
    public class Surveys : BaseEntity
    {
        public string SurveyName { get; set; }
        public List<int>? QuestionIds { get; set; }
    }
}
