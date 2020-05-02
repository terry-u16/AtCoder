using Asakatsu20200503.Questions;
using Asakatsu20200503.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Asakatsu20200503.Questions
{
    /// <summary>
    /// ARC098 D
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = inputStream.ReadIntArray();

            var r = 0;
            var xor = 0;

            long count = 0;
            for (int l = 0; l < a.Length; l++)
            {
                while (r < a.Length && (xor & a[r]) == 0)
                {
                    xor ^= a[r++];
                }
                count += r - l;
                xor ^= a[l];
            }
            yield return count;
        }

        private static void DecrementCounter(int[] a, int r, int[] counter)
        {
            for (int digit = 0; digit < 20; digit++)
            {
                counter[digit] -= (a[r] & (1 << digit)) > 0 ? 1 : 0;
            }
        }

        private static void IncrementCounter(int[] a, int r, int[] counter)
        {
            for (int digit = 0; digit < 20; digit++)
            {
                counter[digit] += (a[r] & (1 << digit)) > 0 ? 1 : 0;
            }
        }
    }
}
