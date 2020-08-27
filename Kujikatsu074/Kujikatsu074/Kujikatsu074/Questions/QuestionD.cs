using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu074.Algorithms;
using Kujikatsu074.Collections;
using Kujikatsu074.Extensions;
using Kujikatsu074.Numerics;
using Kujikatsu074.Questions;

namespace Kujikatsu074.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc084/tasks/abc084_d
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            const int Max = 100000;
            var isPrime = GetPrimes(Max);

            var like2017 = new int[Max + 1];
            for (int i = 1; i < like2017.Length; i += 2)
            {
                if (isPrime[i] && isPrime[(i + 1) / 2])
                {
                    like2017[i] += 1;
                }
            }

            for (int i = 0; i + 1 < like2017.Length; i++)
            {
                like2017[i + 1] += like2017[i];
            }

            var queries = inputStream.ReadInt();

            for (int q = 0; q < queries; q++)
            {
                var (l, r) = inputStream.ReadValue<int, int>();
                yield return like2017[r] - like2017[l - 1];
            }
        }

        bool[] GetPrimes(int max)
        {
            var isPrime = Enumerable.Repeat(true, max + 1).ToArray();
            isPrime[0] = false;
            isPrime[1] = false;

            for (int i = 2; i < isPrime.Length; i++)
            {
                if (isPrime[i])
                {
                    for (int j = i * 2; j < isPrime.Length; j += i)
                    {
                        isPrime[j] = false;
                    }
                }
            }

            return isPrime;
        }
    }
}
