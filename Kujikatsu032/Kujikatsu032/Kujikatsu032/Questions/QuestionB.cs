using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu032.Algorithms;
using Kujikatsu032.Collections;
using Kujikatsu032.Extensions;
using Kujikatsu032.Numerics;
using Kujikatsu032.Questions;

namespace Kujikatsu032.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc087/tasks/abc087_b
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var a = inputStream.ReadInt();
            var b = inputStream.ReadInt();
            var c = inputStream.ReadInt();

            var x = inputStream.ReadInt();

            int count = 0;

            for (int fiveHundred = 0; fiveHundred <= a; fiveHundred++)
            {
                for (int hundred = 0; hundred <= b; hundred++)
                {
                    for (int fifty = 0; fifty <= c; fifty++)
                    {
                        var yen = 500 * fiveHundred + 100 * hundred + 50 * fifty;
                        if (yen == x)
                        {
                            count++;
                        }
                    }
                }
            }

            yield return count;
        }
    }
}
