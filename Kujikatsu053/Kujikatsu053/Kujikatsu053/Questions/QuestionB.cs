using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu053.Algorithms;
using Kujikatsu053.Collections;
using Kujikatsu053.Extensions;
using Kujikatsu053.Numerics;
using Kujikatsu053.Questions;

namespace Kujikatsu053.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/code-festival-2016-qualb/tasks/codefestival_2016_qualB_b
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, a, b) = inputStream.ReadValue<int, int, int>();
            var domestic = 0;
            var overseas = 0;

            var s = inputStream.ReadLine();

            foreach (var c in s)
            {
                if (c == 'a')
                {
                    if (domestic + overseas < a + b)
                    {
                        yield return "Yes";
                        domestic++;
                    }
                    else
                    {
                        yield return "No";
                    }
                }
                else if (c == 'b')
                {
                    if (domestic + overseas < a + b && overseas < b)
                    {
                        yield return "Yes";
                        overseas++;
                    }
                    else
                    {
                        yield return "No";
                    }
                }
                else
                {
                    yield return "No";
                }
            }
        }
    }
}
