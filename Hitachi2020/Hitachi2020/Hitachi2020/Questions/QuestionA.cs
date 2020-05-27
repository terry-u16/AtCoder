using Hitachi2020.Questions;
using Hitachi2020.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Hitachi2020.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();
            s = s.Replace("hi", "");
            yield return s == string.Empty ? "Yes" : "No";
        }
    }
}
