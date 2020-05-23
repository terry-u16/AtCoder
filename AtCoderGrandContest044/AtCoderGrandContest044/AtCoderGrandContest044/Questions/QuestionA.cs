using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using AtCoderGrandContest044.Algorithms;
using AtCoderGrandContest044.Collections;
using AtCoderGrandContest044.Extensions;
using AtCoderGrandContest044.Numerics;
using AtCoderGrandContest044.Questions;

namespace AtCoderGrandContest044.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();

            for (int t = 0; t < tests; t++)
            {
                long n;
                (n, a, b, c, d) = inputStream.ReadValue<long, long, long, long, long>();
                costs = new Dictionary<long, long>();
                yield return Dfs(n);
            }
        }

        Dictionary<long, long> costs;
        long a;
        long b;
        long c;
        long d;

        long Dfs(long i)
        {
            if (i == 0)
            {
                return 0;
            }
            else if (i == 1)
            {
                return d;
            }

            if (costs.ContainsKey(i))
            {
                return costs[i];
            }

            var min = long.MaxValue;
            if (BigInteger.Multiply(i, d) < min)
            {
                min = i * d;
            }
            for (int diff = -4; diff <= 4; diff++)
            {
                var current = i + diff;
                if (current < 0)
                {
                    continue;
                }

                var extra = d * Math.Abs(diff);
                if (current == 0)
                {
                    min = Math.Min(min, Dfs(0) + extra);
                }
                else
                {
                    if (current % 2 == 0 && current / 2 < i)
                    {
                        min = Math.Min(min, Dfs(current / 2) + a + extra);
                    }
                    if (current % 3 == 0 && current / 3 < i)
                    {
                        min = Math.Min(min, Dfs(current / 3) + b + extra);
                    }
                    if (current % 5 == 0 && current / 5 < i)
                    {
                        min = Math.Min(min, Dfs(current / 5) + c + extra);
                    }
                }
            }

            return costs[i] = min;
        }
    }
}
