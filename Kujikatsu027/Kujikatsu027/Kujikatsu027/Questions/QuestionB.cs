using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu027.Algorithms;
using Kujikatsu027.Collections;
using Kujikatsu027.Extensions;
using Kujikatsu027.Numerics;
using Kujikatsu027.Questions;

namespace Kujikatsu027.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/sumitrust2019/tasks/sumitb2019_d
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            _ = inputStream.ReadInt();
            var s = inputStream.ReadLine();

            var count = 0;
            for (int pin = 0; pin <= 999; pin++)
            {
                var pinString = pin.ToString("000");
                var digit = 0;
                foreach (var c in s)
                {
                    if (c == pinString[digit])
                    {
                        digit++;
                        if (digit == 3)
                        {
                            count++;
                            break;
                        }
                    }
                }
            }
            yield return count;
        }
    }
}
