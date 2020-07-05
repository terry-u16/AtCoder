using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu021.Algorithms;
using Kujikatsu021.Collections;
using Kujikatsu021.Extensions;
using Kujikatsu021.Numerics;
using Kujikatsu021.Questions;

namespace Kujikatsu021.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/agc014/tasks/agc014_b
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, m) = inputStream.ReadValue<int, int>();
            var count = new int[n];
            for (int i = 0; i < m; i++)
            {
                var (a, b) = inputStream.ReadValue<int, int>();
                a--;
                b--;
                count[a]++;
                count[b]++;
            }

            yield return count.All(c => c % 2 == 0) ? "YES" : "NO";
        }
    }
}
