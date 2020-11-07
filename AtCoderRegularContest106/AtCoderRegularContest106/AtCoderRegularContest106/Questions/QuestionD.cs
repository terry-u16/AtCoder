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
using AtCoderRegularContest106.Algorithms;
using AtCoderRegularContest106.Collections;
using AtCoderRegularContest106.Numerics;
using AtCoderRegularContest106.Questions;
using ModInt = AtCoderRegularContest106.Numerics.StaticModInt<AtCoderRegularContest106.Numerics.Mod998244353>;

namespace AtCoderRegularContest106.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public override void Solve(IOManager io)
        {
            var n = io.ReadInt();
            var largestPow = io.ReadInt();

            var a = Load(io, n);

            var prefixSum = new ModInt[n + 1];

            for (int i = 0; i < a.Length; i++)
            {
                prefixSum[i + 1] = prefixSum[i] + a[i];
            }

            var results = Enumerable.Repeat(0, largestPow + 1).Select(_ => new ModInt[n]);


        }

        ModInt[] Load(IOManager io, int n)
        {
            var a = io.ReadIntArray(n);
            a.Sort();
            var results = new ModInt[n];

            for (int i = 0; i < a.Length; i++)
            {
                results[i] = ModInt.Raw(a[i]);
            }

            return results;
        }
    }
}
