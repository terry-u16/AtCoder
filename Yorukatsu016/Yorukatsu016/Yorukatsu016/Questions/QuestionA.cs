using Yorukatsu016.Questions;
using Yorukatsu016.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu016.Questions
{
    /// <summary>
    /// ABC074 B
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var k = inputStream.ReadInt();
            var x = inputStream.ReadIntArray();

            yield return x.Select(i => 2 * Math.Min(Math.Abs(i), Math.Abs(i - k))).Sum();
        }
    }
}
