using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu102.Algorithms;
using Kujikatsu102.Collections;
using Kujikatsu102.Numerics;
using Kujikatsu102.Questions;

namespace Kujikatsu102.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc069/tasks/abc069_b
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var s = io.ReadString();
            io.WriteLine(s[0] + (s.Length - 2).ToString() + s[^1]);
        }
    }
}
