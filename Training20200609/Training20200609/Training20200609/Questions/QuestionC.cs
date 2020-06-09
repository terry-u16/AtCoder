using Training20200609.Questions;
using Training20200609.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Training20200609.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/agc007/tasks/agc007_b
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var p = inputStream.ReadIntArray().Select(i => i - 1).ToArray();

            var enumrator = Enumerable.Range(0, n).Select(i => i * 40000);
            var a = enumrator.ToArray();
            var b = enumrator.Reverse().ToArray();

            for (int i = 0; i < n; i++)
            {
                a[p[i]] += i + 1;
                b[p[i]] += i + 1;
            }

            yield return string.Join(" ", a);
            yield return string.Join(" ", b);
        }
    }
}
