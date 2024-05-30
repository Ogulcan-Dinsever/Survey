using Survey.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Domain.SurveyAggregate
{
    public class Question : BaseEntity
    {
        public string QuestionText { get; set; }
        public int Order { get; set; }
        public List<int>? OptionsIds { get; set; }
    }
}
