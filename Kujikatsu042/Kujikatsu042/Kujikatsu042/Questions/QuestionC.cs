using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu042.Algorithms;
using Kujikatsu042.Collections;
using Kujikatsu042.Extensions;
using Kujikatsu042.Numerics;
using Kujikatsu042.Questions;

namespace Kujikatsu042.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc166/tasks/abc166_d
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var x = inputStream.ReadLong();
            for (long a = -200; a <= 200; a++)
            {
                for (long b = -200; b <= 200; b++)
                {
                    if (a * a * a * a * a - b * b * b * b * b == x)
                    {
                        yield return $"{a} {b}";
                        yield break;
                    }
                }
            }
        }
    }
}
