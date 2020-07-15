using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu031.Algorithms;
using Kujikatsu031.Collections;
using Kujikatsu031.Extensions;
using Kujikatsu031.Numerics;
using Kujikatsu031.Questions;

namespace Kujikatsu031.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/agc022/tasks/agc022_c
    /// </summary>
    public class QuestionG : AtCoderQuestionBase
    {
        const int MaxBit = 50;

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = inputStream.ReadIntArray();
            var b = inputStream.ReadIntArray();

            if (a.SequenceEqual(b))
            {
                yield return 0;
                yield break;
            }
            else if (CantSolve(a, b))
            {
                yield return -1;
                yield break;
            }
            else
            {
                var score = (1L << MaxBit) - 1;

                for (int digit = MaxBit - 1; digit >= 0; digit--)
                {
                    var tryingScore = score ^ (1L << digit);
                    if (Check(a, b, tryingScore))
                    {
                        score = tryingScore;
                    }
                }

                yield return score;
            }
        }

        bool CantSolve(int[] a, int[] b)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i] && a[i] <= b[i] * 2)
                {
                    return true;
                }
            }
            return false;
        }

        bool Check(int[] a, int[] b, long flags)
        {
            var ok = true;
            for (int i = 0; i < a.Length; i++)
            {
                ok &= Check(a[i], b[i], flags);
            }
            return ok;
        }

        bool Check(int a, int b, long flags)
        {
            if (a == b)
            {
                return true;
            }
            else
            {
                var ok = false;
                for (int toAdd = b + 1; toAdd < MaxBit && !ok; toAdd++)
                {
                    if (((1L << toAdd) & flags) > 0)
                    {
                        for (int i = 1; !ok; i++)
                        {
                            var next = b + toAdd * i;
                            if (next <= a)
                            {
                                ok |= Check(a, next, flags);
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }

                return ok;
            }
        }
    }
}
