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
                while (right < a.Length && (right <= left || CanAdd(current, a[right])))
                {
                    current ^= a[right++];
                }
                count += right - left;
                if (left == right)
                {
                    current ^= a[right++];
                }
                current ^= a[left];
            }

            yield return count;
        }

        bool CanAdd(int current, int next) => (current & next) == 0;
    }
}
