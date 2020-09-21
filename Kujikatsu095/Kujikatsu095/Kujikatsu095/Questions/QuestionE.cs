using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu095.Algorithms;
using Kujikatsu095.Collections;
using Kujikatsu095.Extensions;
using Kujikatsu095.Numerics;
using Kujikatsu095.Questions;

namespace Kujikatsu095.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/arc086/tasks/arc086_b
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = inputStream.ReadIntArray();
            var maxIndex = 0;
            var minIndex = 0;

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] > a[maxIndex])
                {
                    maxIndex = i;
                }
                if (a[i] < a[minIndex])
                {
                    minIndex = i;
                }
            }

            yield return 2 * a.Length - 1;

            if (-a[minIndex] < a[maxIndex])
            {
                for (int i = 0; i < a.Length; i++)
                {
                    yield return $"{maxIndex + 1} {i + 1}";
                }

                for (int i = 0; i + 1 < a.Length; i++)
                {
                    yield return $"{i + 1} {i + 2}";
                }
            }
            else
            {
                for (int i = 0; i < a.Length; i++)
                {
                    yield return $"{minIndex + 1} {i + 1}";
                }

                for (int i = a.Length - 2; i >= 0; i--)
                {
                    yield return $"{i + 2} {i + 1}";
                }
            }
        }
    }
}
