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
    /// https://atcoder.jp/contests/abc079/tasks/abc079_c
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var abcd = inputStream.ReadLine().Select(c => c - '0').ToArray();

            for (int i = -1; i <= 1; i += 2)
            {
                for (int j = -1; j <= 1; j += 2)
                {
                    for (int k = -1; k <= 1; k += 2)
                    {
                        var result = abcd[0] + i * abcd[1] + j * abcd[2] + k * abcd[3];
                        if (result == 7)
                        {
                            var op1 = ToSign(i);
                            var op2 = ToSign(j);
                            var op3 = ToSign(k);
                            yield return $"{abcd[0]}{op1}{abcd[1]}{op2}{abcd[2]}{op3}{abcd[3]}=7";
                            yield break;
                        }
                    }
                }
            }
        }

        char ToSign(int i)
        {
            if (i == 1)
            {
                return '+';
            }
            else
            {
                return '-';
            }
        }
    }
}
