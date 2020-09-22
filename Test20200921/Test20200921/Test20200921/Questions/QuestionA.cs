using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Test20200921.Questions;
using System.Diagnostics;
using AtCoder;
using AtCoder.Internal;
using System.Numerics;
using System.Runtime.Intrinsics.X86;
using ModInt = AtCoder.StaticModInt<AtCoder.Mod998244353>;

namespace Test20200921.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var n = io.ReadInt();
            var m = io.ReadInt();
            var a = new ModInt[n];
            var b = new ModInt[m];

            for (int i = 0; i < a.Length; i++)
            {
                a[i] = ModInt.Raw(io.ReadInt());
            }

            for (int i = 0; i < b.Length; i++)
            {
                b[i] = ModInt.Raw(io.ReadInt());
            }

            var c = AtCoder.Math.Convolution(a, b);
            io.WriteLine(c, ' ');
        }
    }
}
