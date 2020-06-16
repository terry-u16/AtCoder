using Kujikatsu002.Questions;
using Kujikatsu002.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Kujikatsu002.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc136/tasks/abc136_e
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nk = inputStream.ReadIntArray();
            var k = nk[1];
            var a = inputStream.ReadIntArray();


            yield return GetDivisors(a.Sum()).Where(div => Check(a, k, div)).Max();
        }

        private static bool Check(int[] a, int k, int divisior)
        {
            var mods = a.Select(i => i % divisior).ToArray();
            Array.Sort(mods);

            var count = 0;
            var left = 0;
            var right = mods.Length - 1;

            while (left < right)
            {
                var abs = Math.Min(mods[left], divisior - mods[right]);
                count += abs;
                mods[left] -= abs;
                mods[right] += abs;

                if (mods[left] == 0)
                {
                    left++;
                }
                if (mods[right] == divisior)
                {
                    right--;
                }
            }

            return mods[left] % divisior == 0 && mods[right] % divisior == 0 && count <= k;
        }

        IEnumerable<int> GetDivisors(int n)
        {
            for (int i = 1; i * i <= n; i++)
            {
                if (n % i == 0)
                {
                    yield return i;
                    var other = n / i;
                    if (other != i)
                    {
                        yield return other;
                    }
                }
            }
        }
    }
}
