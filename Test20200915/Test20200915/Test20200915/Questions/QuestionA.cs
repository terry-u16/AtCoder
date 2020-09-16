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
using ModInt = AtCoder.StaticModInt<AtCoder.Mod998244353>;

namespace Test20200915.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/practice2/tasks/practice2_f
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (_, _) = inputStream.ReadValue<int, int>();
            var a = inputStream.ReadIntArray().Select(ai => ModInt.Raw(ai)).ToArray();
            var b = inputStream.ReadIntArray().Select(bi => ModInt.Raw(bi)).ToArray();
            var c = AtCoder.Math.Convolution(a, b);
            yield return c.Join(' ');
        }
    }
}
