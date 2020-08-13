using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu060.Algorithms;
using Kujikatsu060.Collections;
using Kujikatsu060.Extensions;
using Kujikatsu060.Numerics;
using Kujikatsu060.Questions;

namespace Kujikatsu060.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/agc005/tasks/agc005_a
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();
            var current = 0;
            var result = s.Length;

            foreach (var c in s)
            {
                if (c == 'T')
                {
                    if (current > 0)
                    {
                        result -= 2;
                        current--;
                    }
                }
                else
                {
                    current++;
                }
            }

            yield return result;
        }
    }
}
