using Kujikatsu002.Questions;
using Kujikatsu002.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Kujikatsu002.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/arc098/tasks/arc098_b
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = inputStream.ReadIntArray();

            var current = 0;
            var right = 0;
            long count = 0;
            for (int left = 0; left < a.Length; left++)
            {
                while (right < a.Length && CanProceed(current, a[right]))
                {
                    current ^= a[right++];
                }

                count += right - left;

                if (right == left)
                {
                    right++;
                }
                else
                {
                    current ^= a[left];
                }
            }

            yield return count;
        }

        bool CanProceed(int current, int added) => (current ^ added) == (current + added);
    }
}
