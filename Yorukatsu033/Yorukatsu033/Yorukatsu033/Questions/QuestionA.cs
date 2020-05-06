using Yorukatsu033.Questions;
using Yorukatsu033.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu033.Questions
{
    /// <summary>
    /// ABC120 A
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var abc = inputStream.ReadIntArray();
            yield return Math.Min(abc[1] / abc[0], abc[2]);
        }
    }
}
