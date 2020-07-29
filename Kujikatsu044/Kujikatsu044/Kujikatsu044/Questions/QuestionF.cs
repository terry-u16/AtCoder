using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu044.Algorithms;
using Kujikatsu044.Collections;
using Kujikatsu044.Extensions;
using Kujikatsu044.Numerics;
using Kujikatsu044.Questions;

namespace Kujikatsu044.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/ddcc2020-qual/tasks/ddcc2020_qual_d
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var m = inputStream.ReadInt();
            long current = 0;
            long count = 0;

            for (int i = 0; i < m; i++)
            {
                var (d, c) = inputStream.ReadValue<int, long>();
                current += d * c;
                count += c;
                count += (current - 1) / 9;
                current = (current - 1) % 9 + 1;
            }

            yield return count - 1;
        }
    }
}
