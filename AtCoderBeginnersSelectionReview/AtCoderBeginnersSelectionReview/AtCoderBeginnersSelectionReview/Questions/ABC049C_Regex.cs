using AtCoderBeginnersSelectionReview.Questions;
using AtCoderBeginnersSelectionReview.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AtCoderBeginnersSelectionReview.Questions
{
    public class ABC049C_Regex : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();
            var reg = new Regex("^(dream|dreamer|erase|eraser)+$");
            if (reg.IsMatch(s))
            {
                yield return "YES";
            }
            else
            {
                yield return "NO";
            }
        }
    }
}
