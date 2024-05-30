using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Application.Responses
{
    public class OptionResponse
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string OptionName { get; set; }
        public bool IsCheckedOption { get; set; }  //if this choise false == this option is text answer
    }
}
