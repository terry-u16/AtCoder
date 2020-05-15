using Yorukatsu040.Questions;
using Yorukatsu040.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu040.Questions
{
    /// <summary>
    /// ABC119 C
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nabc = inputStream.ReadIntArray();
            var n = nabc[0];
            var desiredLength = nabc.Skip(1).ToArray();

            var bamboos = new int[n];
            for (int i = 0; i < n; i++)
            {
                bamboos[i] = inputStream.ReadInt();
            }

            var minMP = int.MaxValue;
            for (int flags = 0; flags < 1 << n * 2; flags++)
            {
                var usedBamboo = Enumerable.Repeat(0, 4).Select(_ => new List<int>()).ToArray();
                for (int bamboo = 0; bamboo < n; bamboo++)
                {
                    var flag = (flags & (3 << (bamboo * 2))) >> (bamboo * 2);
                    usedBamboo[flag].Add(bamboos[bamboo]);
                }
                if (Enumerable.Range(1, 3).Any(i => usedBamboo[i].Count == 0))
                {
                    continue;
                }

                var mp = Enumerable.Range(1, 3).Sum(i => (usedBamboo[i].Count - 1) * 10 + Math.Abs(usedBamboo[i].Sum() - desiredLength[i - 1]));
                minMP = Math.Min(minMP, mp);
            }

            yield return minMP;
        }
    }
}
