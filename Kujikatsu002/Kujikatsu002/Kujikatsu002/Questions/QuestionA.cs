using Kujikatsu002.Questions;
using Kujikatsu002.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace Kujikatsu002.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/caddi2018b/tasks/caddi2018b_b
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nhw = inputStream.ReadIntArray();
            var n = nhw[0];
            long h = nhw[1];
            long w = nhw[2];

            long count = 0;

            for (int i = 0; i < n; i++)
            {
                var ab = inputStream.ReadIntArray();
                long a = ab[0];
                long b = ab[1];
                if (a / h >= 1 && b / w >= 1)
                {
                    count++;
                }
            }

            yield return count;
        }
    }
}
