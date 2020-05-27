using Training20200527.Questions;
using Training20200527.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Training20200527.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc136/tasks/abc136_e
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nk = inputStream.ReadIntArray();
            var n = nk[0];
            var k = nk[1];
            var a = inputStream.ReadIntArray();
            var sum = a.Sum();
            var divisiors = GetDivisiors(sum);

            var max = 1;
            foreach (var divisior in divisiors)
            {
                if (CountToDivisibleBy(divisior, a) <= k)
                {
                    max = Math.Max(max, divisior);
                }
            }

            yield return max;
        }

        IEnumerable<int> GetDivisiors(int n)
        {
            for (int i = 1; i * i <= n; i++)
            {
                if (n % i == 0)
                {
                    var other = n / i;
                    yield return i;
                    if (i != other)
                    {
                        yield return other;
                    }
                }
            }
        }

        int CountToDivisibleBy(int divisior, int[] a)
        {
            var mods = a.Select(i => i % divisior).ToArray();
            Array.Sort(mods);

            var count = 0;
            var smallCursor = 0;
            var largeCursor = a.Length - 1;
            while (smallCursor < largeCursor)
            {
                var small = mods[smallCursor];
                var large = divisior - mods[largeCursor];
                if (small < large)
                {
                    count += small;
                    mods[largeCursor] += small;
                    smallCursor++;
                }
                else if (small > large)
                {
                    count += large;
                    mods[smallCursor] -= large;
                    largeCursor--;
                }
                else
                {
                    count += small;
                    smallCursor++;
                    largeCursor--;
                }
            }
            return count;
        }
    }
}
