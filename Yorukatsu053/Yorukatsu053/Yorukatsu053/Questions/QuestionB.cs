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
    /// https://atcoder.jp/contests/abc064/tasks/abc064_c
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = inputStream.ReadIntArray();
            var count = new int[9];

            foreach (var ai in a)
            {
                var color = Math.Min(ai / 400, 8);
                count[color]++;
            }

            var min = 0;
            for (int i = 0; i < 8; i++)
            {
                min += count[i] > 0 ? 1 : 0;
            }

            var max = min + count[8];
            min = Math.Max(min, 1);

            yield return $"{min} {max}";
        }
    }
}
