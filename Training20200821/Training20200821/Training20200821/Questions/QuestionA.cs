using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200821.Algorithms;
using Training20200821.Collections;
using Training20200821.Extensions;
using Training20200821.Numerics;
using Training20200821.Questions;

namespace Training20200821.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc098/tasks/abc098_a
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (a, b) = inputStream.ReadValue<int, int>();
            var max = Math.Max(a + b, Math.Max(a - b, a * b));
            yield return max;
        }
    }
}
