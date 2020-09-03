using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu20200830.Algorithms;
using Kujikatsu20200830.Collections;
using Kujikatsu20200830.Extensions;
using Kujikatsu20200830.Numerics;
using Kujikatsu20200830.Questions;

namespace Kujikatsu20200830.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc144/tasks/abc144_b
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();

            for (int i = 1; i < 10; i++)
            {
                for (int j = 1; j < 10; j++)
                {
                    if (i * j == n)
                    {
                        yield return "Yes";
                        yield break;
                    }
                }
            }

            yield return "No";
        }
    }
}
