using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200901.Algorithms;
using Training20200901.Collections;
using Training20200901.Extensions;
using Training20200901.Numerics;
using Training20200901.Questions;

namespace Training20200901.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc113/tasks/abc113_a
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (x, y) = inputStream.ReadValue<int, int>();
            yield return x + y / 2;
        }
    }
}
