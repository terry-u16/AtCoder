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
    /// ABC115 C
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nk = inputStream.ReadIntArray();
            var n = nk[0];
            var k = nk[1];

            var h = new int[n];

            for (int i = 0; i < n; i++)
            {
                h[i] = inputStream.ReadInt();
            }

            Array.Sort(h);

            var minDiff = int.MaxValue;

            for (int i = 0; i < n - k + 1; i++)
            {
                minDiff = Math.Min(minDiff, h[i + k - 1] - h[i]);
            }

            yield return minDiff;
        }
    }
}
