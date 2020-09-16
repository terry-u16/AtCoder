using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Test20200915.Extensions;
using Test20200915.Questions;
using System.Diagnostics;
using System.Runtime.Intrinsics.X86;
using System.Numerics;
using AtCoder;

namespace Test20200915.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/practice2/tasks/practice2_f
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (_, _) = inputStream.ReadValue<int, int>();
            var a = inputStream.ReadIntArray();
            var b = inputStream.ReadIntArray();
            var c = AtCoder.Math.Convolution<Mod998244353>(a, b);
            yield return c.Join(' ');
        }
    }
}
