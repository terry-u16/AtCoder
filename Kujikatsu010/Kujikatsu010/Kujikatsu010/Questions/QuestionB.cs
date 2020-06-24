using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu010.Algorithms;
using Kujikatsu010.Collections;
using Kujikatsu010.Extensions;
using Kujikatsu010.Numerics;
using Kujikatsu010.Questions;

namespace Kujikatsu010.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc060/tasks/abc060_b
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (a, b, c) = inputStream.ReadValue<int, int, int>();

            for (int i = 1; i < 1000000; i++)
            {
                if ((a * i) % b == c)
                {
                    yield return "YES";
                    yield break;
                }
            }

            yield return "NO";
        }
    }
}
