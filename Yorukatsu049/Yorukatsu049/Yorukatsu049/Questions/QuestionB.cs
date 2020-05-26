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
    /// ABC120 C
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();
            var red = s.Count(c => c == '0');
            var blue = s.Count(c => c == '1');
            yield return Math.Min(red, blue) * 2;
        }
    }
}
