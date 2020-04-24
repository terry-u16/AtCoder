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
    /// ABC107 C
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nk = inputStream.ReadIntArray();
            var n = nk[0];
            var k = nk[1];
            var x = inputStream.ReadIntArray();

            var minDistance = int.MaxValue;
            for (int i = 0; i < n - k + 1; i++)
            {
                var left = x[i];
                var right = x[i + k - 1];
                var distance = right - left + Math.Min(Math.Abs(left), Math.Abs(right));
                minDistance = Math.Min(minDistance, distance);
            }

            yield return minDistance;
        }
    }
}
