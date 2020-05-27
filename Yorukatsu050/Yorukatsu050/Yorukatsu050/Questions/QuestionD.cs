using Yorukatsu050.Questions;
using Yorukatsu050.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu050.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc133/tasks/abc133_d
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var dams = inputStream.ReadIntArray();
            var rains = new int[dams.Length];

            for (int i = 0; i < dams.Length; i++)
            {
                rains[0] += (i % 2 == 0 ? 1 : -1) * dams[i];
            }

            for (int i = 1; i < rains.Length; i++)
            {
                rains[i] = 2 * dams[i - 1] - rains[i - 1];
            }

            yield return string.Join(" ", rains);
        }
    }
}
