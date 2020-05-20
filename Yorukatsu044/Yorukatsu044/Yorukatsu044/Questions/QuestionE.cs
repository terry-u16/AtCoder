using Yorukatsu044.Questions;
using Yorukatsu044.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu044.Questions
{
    /// <summary>
    /// ABC154 E
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadString();
            var k = inputStream.ReadInt();

            var count = new long[n.Length + 1, 2, k + 1];
            const int MayExceed = 0;
            const int Less = 1;
            count[0, MayExceed, 0] = 1;

            for (int digit = 0; digit < n.Length; digit++)
            {
                var current = n[digit] - '0';

                // 超えるかも？→超えるかも？
                if (current > 0)
                {
                    // 0以外
                    for (int i = 0; i + 1 <= k; i++)
                    {
                        count[digit + 1, MayExceed, i + 1] += count[digit, MayExceed, i];
                    }
                }
                else
                {
                    // 0
                    for (int i = 0; i <= k; i++)
                    {
                        count[digit + 1, MayExceed, i] += count[digit, MayExceed, i];
                    }
                }

                // 超えるかも？→超えない
                if (current > 1)
                {
                    // 1～max-1
                    for (int i = 0; i + 1 <= k; i++)
                    {
                        count[digit + 1, Less, i + 1] += (current - 1) * count[digit, MayExceed, i];
                    }
                }

                if (current >= 1)
                {
                    // 0
                    for (int i = 0; i <= k; i++)
                    {
                        count[digit + 1, Less, i] += count[digit, MayExceed, i];
                    }
                }

                // 超えない
                for (int i = 0; i + 1 <= k; i++)
                {
                    count[digit + 1, Less, i + 1] += 9 * count[digit, Less, i];
                }
                for (int i = 0; i <= k; i++)
                {
                    count[digit + 1, Less, i] += count[digit, Less, i];
                }
            }

            yield return count[n.Length, MayExceed, k] + count[n.Length, Less, k];
        }
    }
}
