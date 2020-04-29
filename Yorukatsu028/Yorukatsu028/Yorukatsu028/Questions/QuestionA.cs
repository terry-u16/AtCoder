using Yorukatsu028.Questions;
using Yorukatsu028.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu028.Questions
{
    /// <summary>
    /// ABC101 A
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();

            yield return s.Count(c => c == '+') - s.Count(c => c == '-');
        }
    }
}
