using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200627.Algorithms;
using Training20200627.Collections;
using Training20200627.Extensions;
using Training20200627.Numerics;
using Training20200627.Questions;
using Training20200627.Graphs;
using Training20200627.Graphs.Algorithms;

namespace Training20200627.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc011/tasks/abc011_4
    /// </summary>
    public class QuestionG : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, d) = inputStream.ReadValue<int, int>();
            var (x, y) = inputStream.ReadValue<int, int>();

            if (x % d != 0 || y % d != 0)
            {
                yield return 0;
                yield break;
            }

            var countX = Math.Abs(x) / d;
            var countY = Math.Abs(y) / d;

            if (n < countX + countY || (n - countX - countY) % 2 != 0)
            {
                yield return 0;
                yield break;
            }


        }
    }
}
