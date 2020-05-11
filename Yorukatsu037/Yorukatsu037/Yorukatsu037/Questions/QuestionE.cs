using Yorukatsu037.Questions;
using Yorukatsu037.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu037.Questions
{
    /// <summary>
    /// ABC059 C
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = inputStream.ReadLongArray();
            var plus = CheckCost(a, true);
            var minus = CheckCost(a, false);

            yield return Math.Min(plus, minus);
        }

        long CheckCost(long[] a, bool beginWithPlus)
        {
            long cost = 0;
            long sum = a[0];
            if (beginWithPlus && sum <= 0)
            {
                cost += -sum + 1;
                sum = 1;
            }
            else if (!beginWithPlus && sum >= 0)
            {
                cost += sum + 1;
                sum = -1;
            }

            for (int i = 1; i < a.Length; i++)
            {
                var current = sum + a[i];
                if (sum * current >= 0)
                {
                    cost += Math.Abs(current) + 1;
                    sum = sum > 0 ? -1 : 1;
                }
                else
                {
                    sum = current;
                }
            }

            return cost;
        }
    }
}
