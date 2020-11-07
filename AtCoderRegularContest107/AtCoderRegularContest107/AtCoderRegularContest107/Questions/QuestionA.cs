using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
using AtCoderRegularContest107.Algorithms;
using AtCoderRegularContest107.Collections;
using AtCoderRegularContest107.Numerics;
using AtCoderRegularContest107.Questions;
using ModInt = AtCoderRegularContest107.Numerics.StaticModInt<AtCoderRegularContest107.Numerics.Mod998244353>;

namespace AtCoderRegularContest107.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public override void Solve(IOManager io)
        {
            var abc = io.ReadIntArray(3);

            var result = ModInt.One;

            foreach (var v in abc)
            {
                result *= new ModInt(v) * new ModInt(1 + v) / ModInt.Raw(2);
            }

            io.WriteLine(result);
        }
    }
}
