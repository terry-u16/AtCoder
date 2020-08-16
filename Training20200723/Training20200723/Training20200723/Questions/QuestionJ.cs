using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200723.Algorithms;
using Training20200723.Collections;
using Training20200723.Extensions;
using Training20200723.Numerics;
using Training20200723.Questions;

namespace Training20200723.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/arc050/tasks/arc050_b
    /// </summary>
    public class QuestionJ : AtCoderQuestionBase
    {
        long reds, blues, redNeeded, blueNeeded;
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            (reds, blues) = inputStream.ReadValue<long, long>();
            (redNeeded, blueNeeded) = inputStream.ReadValue<long, long>();

            long left = -1;
            long right = Math.Min(reds, blues / blueNeeded) + 1;
            while (left + 2 < right)
            {
                var mid1 = left + (right - left) / 3;
                var mid2 = left + ((right - left) + 1) * 2 / 3;
                if (mid1 + ComposeRedBouquets(mid1) >= mid2 + ComposeRedBouquets(mid2))
                {
                    right = mid2;
                }
                else
                {
                    left = mid1;
                }
            }

            yield return Math.Max(left + 1 + ComposeRedBouquets(left + 1), right - 1 + ComposeRedBouquets(right - 1));
        }

        long ComposeRedBouquets(long blueBouquets)
        {
            var redRemain = reds - blueBouquets;
            var blueRemain = blues - blueBouquets * blueNeeded;
            return Math.Min(redRemain / redNeeded, blueRemain);
        }
    }
}
