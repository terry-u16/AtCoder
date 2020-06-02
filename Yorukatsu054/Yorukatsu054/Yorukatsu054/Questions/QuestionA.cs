using Yorukatsu054.Questions;
using Yorukatsu054.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu054.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc068/tasks/abc068_b
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();

            var maxCount = int.MinValue;
            var number = -1;
            for (int i = 1; i <= n; i++)
            {
                var count = CountDiv2(i);
                if (maxCount < count)
                {
                    maxCount = count;
                    number = i;
                }
            }

            yield return number;
        }

        int CountDiv2(int n)
        {
            var count = 0;
            while (n % 2 == 0)
            {
                count++;
                n /= 2;
            }
            return count;
        }
    }
}
