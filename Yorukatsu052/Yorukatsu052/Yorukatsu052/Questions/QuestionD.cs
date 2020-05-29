using Yorukatsu052.Questions;
using Yorukatsu052.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu052.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc152/tasks/abc152_d
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();

            var counts = new long[10, 10];

            for (int i = 1; i <= n; i++)
            {
                counts[GetTopDigit(i), GetBottomDigit(i)]++;
            }

            long count = 0;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    count += counts[i, j] * counts[j, i];
                }
            }

            yield return count;
        }

        int GetTopDigit(int n)
        {
            while (n >= 10)
            {
                n /= 10;
            }

            return n;
        }

        int GetBottomDigit(int n) => n % 10;
    }
}
