using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu055.Algorithms;
using Kujikatsu055.Collections;
using Kujikatsu055.Extensions;
using Kujikatsu055.Numerics;
using Kujikatsu055.Questions;

namespace Kujikatsu055.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/code-festival-2016-qualc/tasks/codefestival_2016_qualC_a
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();
            var count = 0;

            foreach (var c in s)
            {
                if (count == 0)
                {
                    if (c == 'C')
                    {
                        count++;
                    }
                }
                else if (count == 1)
                {
                    if (c == 'F')
                    {
                        count++;
                    }
                }
            }

            yield return count == 2 ? "Yes" : "No";
        }
    }
}
