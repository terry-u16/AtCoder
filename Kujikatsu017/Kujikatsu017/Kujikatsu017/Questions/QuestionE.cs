using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu017.Algorithms;
using Kujikatsu017.Collections;
using Kujikatsu017.Extensions;
using Kujikatsu017.Numerics;
using Kujikatsu017.Questions;

namespace Kujikatsu017.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc119/tasks/abc119_c
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        int n, a, b, c;
        int[] lengths;
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            (n, a, b, c) = inputStream.ReadValue<int, int, int, int>();
            lengths = new int[n];

            for (int i = 0; i < n; i++)
            {
                lengths[i] = inputStream.ReadInt();
            }

            yield return GetMinMp(0, 0, 0, 0) - 30;
        }

        int GetMinMp(int lengthA, int lengthB, int lengthC, int depth)
        {
            if (depth == lengths.Length)
            {
                if (lengthA == 0 || lengthB == 0 || lengthC == 0)
                {
                    return 1 << 28;
                }
                else
                {
                    return Math.Abs(lengthA - a) + Math.Abs(lengthB - b) + Math.Abs(lengthC - c);
                }
            }
            else
            {
                var mp = 1 << 28;
                mp = Math.Min(mp, GetMinMp(lengthA + lengths[depth], lengthB, lengthC, depth + 1) + 10);
                mp = Math.Min(mp, GetMinMp(lengthA, lengthB + lengths[depth], lengthC, depth + 1) + 10);
                mp = Math.Min(mp, GetMinMp(lengthA, lengthB, lengthC + lengths[depth], depth + 1) + 10);
                mp = Math.Min(mp, GetMinMp(lengthA, lengthB, lengthC, depth + 1));
                return mp;
            }
        }
        
    }
}
