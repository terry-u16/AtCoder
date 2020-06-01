using Yorukatsu053.Questions;
using Yorukatsu053.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu053.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc067/tasks/arc078_a
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = inputStream.ReadLongArray();
            var sum = new long[a.Length + 1];

            for (int i = 0; i < a.Length; i++)
            {
                sum[i + 1] = sum[i] + a[i];
            }

            long min = long.MaxValue;
            for (int i = 1; i + 1 < sum.Length; i++)
            {
                var snuke = sum[i];
                var arai = sum[sum.Length - 1] - sum[i];
                var diff = Math.Abs(arai - snuke);

                min = Math.Min(min, diff);
            }

            yield return min;
        }
    }
}
