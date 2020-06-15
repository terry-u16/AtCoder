using Kujikatsu001.Questions;
using Kujikatsu001.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Kujikatsu001.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc073/tasks/abc073_b
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var count = 0;

            for (int i = 0; i < n; i++)
            {
                var lr = inputStream.ReadIntArray();
                count += lr[1] - lr[0] + 1;
            }

            yield return count;
        }
    }
}
