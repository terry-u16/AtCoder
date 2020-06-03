using Yorukatsu055.Questions;
using Yorukatsu055.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu055.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/arc067/tasks/arc067_b
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nab = inputStream.ReadIntArray();
            var townsCount = nab[0];
            long walk = nab[1];
            long teleport = nab[2];

            var x = inputStream.ReadIntArray();
            long totalExhaust = 0;

            for (int i = 0; i + 1 < x.Length; i++)
            {
                var distance = x[i + 1] - x[i];
                totalExhaust += Math.Min(walk * distance, teleport);
            }

            yield return totalExhaust;
        }
    }
}
