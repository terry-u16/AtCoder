using Yorukatsu056.Questions;
using Yorukatsu056.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu056.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc095/tasks/arc096_a
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var abcxy = inputStream.ReadIntArray();
            var aCost = abcxy[0];
            var bCost = abcxy[1];
            var abCost = abcxy[2];
            var aNeeded = abcxy[3];
            var bNeeded = abcxy[4];

            if (aCost + bCost <= 2 * abCost)
            {
                yield return aCost * aNeeded + bCost * bNeeded;
            }
            else
            {
                var totalCost = 0;
                var minAB = Math.Min(aNeeded, bNeeded);
                totalCost += 2 * minAB * abCost;
                aNeeded -= minAB;
                bNeeded -= minAB;

                if (aNeeded > 0)
                {
                    totalCost += Math.Min(aCost, 2 * abCost) * aNeeded;
                }

                if (bNeeded > 0)
                {
                    totalCost += Math.Min(bCost, 2 * abCost) * bNeeded;
                }

                yield return totalCost;
            }
        }
    }
}
