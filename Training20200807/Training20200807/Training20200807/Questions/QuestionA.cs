using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200807.Algorithms;
using Training20200807.Collections;
using Training20200807.Extensions;
using Training20200807.Numerics;
using Training20200807.Questions;

namespace Training20200807.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            yield return GetPrimes(55555).Select(p => p.ToString()).Where(p => p[^1] == '1').Take(n).Join(' ');
        }


        IEnumerable<int> GetPrimes(int n)
        {
            var isNotPrime = new bool[n + 1];
            isNotPrime[0] = true;
            isNotPrime[1] = true;

            for (int i = 2; i <= n; i++)
            {
                if (!isNotPrime[i])
                {
                    for (int j = i * 2; j <= n; j += i)
                    {
                        isNotPrime[j] = true;
                    }
                }
            }

            for (int i = 0; i < isNotPrime.Length; i++)
            {
                if (!isNotPrime[i])
                {
                    yield return i;
                }
            }
        }
    }
}
