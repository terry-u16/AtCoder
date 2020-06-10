using Training20200610.Questions;
using Training20200610.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Training20200610.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc014/tasks/abc014_3
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var popularity = new int[1000002];

            for (int i = 0; i < n; i++)
            {
                var ab = inputStream.ReadIntArray();
                var a = ab[0];
                var b = ab[1];
                popularity[a]++;
                popularity[b + 1]--;
            }

            for (int i = 0; i + 1 < popularity.Length; i++)
            {
                popularity[i + 1] += popularity[i];
            }

            yield return popularity.Max();
        }
    }
}
