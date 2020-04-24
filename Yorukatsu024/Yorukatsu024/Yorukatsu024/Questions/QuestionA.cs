using Yorukatsu024.Questions;
using Yorukatsu024.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu024.Questions
{
    /// <summary>
    /// ABC142 A
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var odds = (n + 1) / 2;

            yield return (double)odds / n;
        }
    }
}
