using Yorukatsu027.Questions;
using Yorukatsu027.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu027.Questions
{
    /// <summary>
    /// ABC125 D
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = inputStream.ReadLongArray();

            var minusCount = a.Count(i => i < 0);
            var absSum = a.Sum(i => Math.Abs(i));
            var absMin = a.Min(i => Math.Abs(i));

            if (minusCount % 2 == 0)
            {
                yield return absSum;
            }
            else
            {
                yield return absSum - 2 * absMin;
            }
        }
    }
}
