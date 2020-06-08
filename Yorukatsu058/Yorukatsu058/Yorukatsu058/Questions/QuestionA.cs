using Yorukatsu058.Questions;
using Yorukatsu058.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu058.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc140/tasks/abc140_b
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadIntArray();
            var dishes = inputStream.ReadIntArray().Select(i => i - 1).ToArray();
            var happyness = inputStream.ReadIntArray();
            var bonus = inputStream.ReadIntArray();

            var sum = 0;

            for (int i = 0; i < dishes.Length; i++)
            {
                sum += happyness[dishes[i]];

                if (i + 1 < dishes.Length && dishes[i + 1] - dishes[i] == 1)
                {
                    sum += bonus[dishes[i]];
                }
            }

            yield return sum;
        }
    }
}
