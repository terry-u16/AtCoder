using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu020.Algorithms;
using Kujikatsu020.Collections;
using Kujikatsu020.Extensions;
using Kujikatsu020.Numerics;
using Kujikatsu020.Questions;

namespace Kujikatsu020.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc101/tasks/abc101_b
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            if (n % S(n) == 0)
            {
                yield return "Yes";
            }
            else
            {
                yield return "No";
            }
        }

        int S(int n)
        {
            int sum = 0;
            while (n > 0)
            {
                sum += n % 10;
                n /= 10;
            }
            return sum;
        }
    }
}
