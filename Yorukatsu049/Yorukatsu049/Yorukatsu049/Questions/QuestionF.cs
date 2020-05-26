using Yorukatsu049.Questions;
using Yorukatsu049.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu049.Questions
{
    /// <summary>
    /// ABC059 D
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var xy = inputStream.ReadLongArray();
            var x = xy[0];
            var y = xy[1];

            if (Math.Abs(x - y) <= 1)
            {
                yield return "Brown";
            }
            else
            {
                yield return "Alice";
            }
        }
    }
}
