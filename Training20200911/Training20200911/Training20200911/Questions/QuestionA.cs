using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200911.Algorithms;
using Training20200911.Collections;
using Training20200911.Extensions;
using Training20200911.Numerics;
using Training20200911.Questions;

namespace Training20200911.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc040/tasks/abc040_b
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var min = int.MaxValue;

            if (n == 1)
            {
                yield return 0;
                yield break;
            }

            for (int row = 1; row < n; row++)
            {
                var column = n / row;
                var mod = n % row;
                min = Math.Min(min, Math.Abs(row - column) + mod);
            }

            yield return min;
        }
    }
}
