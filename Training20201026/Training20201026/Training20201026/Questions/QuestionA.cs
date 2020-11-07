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
using Training20201026.Algorithms;
using Training20201026.Collections;
using Training20201026.Numerics;
using Training20201026.Questions;
using ModInt = Training20201026.Numerics.StaticModInt<Training20201026.Numerics.Mod998244353>;

namespace Training20201026.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public override void Solve(IOManager io)
        {
            var n = io.ReadInt();
            var k = io.ReadInt();
            var pows = new ModInt[k + 1][];
            pows[0] = new ModInt[n];
            pows[0].Fill(ModInt.One);
            pows[1] = new ModInt[n];

            for (int i = 0; i < pows[1].Length; i++)
            {
                pows[1][i] = ModInt.Raw(io.ReadInt());
            }

            var combination = new ModCombination<Mod998244353>(300);

            for (int p = 2; p < pows.Length; p++)
            {
                pows[p] = new ModInt[n];
                for (int i = 0; i < pows[p].Length; i++)
                {
                    pows[p][i] = pows[p - 1][i] * pows[1][i];
                }
            }

            var sums = new ModInt[k + 1];

            for (int p = 0; p < pows.Length; p++)
            {
                var sum = ModInt.Zero;
                for (int i = 0; i < pows[p].Length; i++)
                {
                    sum += pows[p][i];
                }
                sums[p] = sum;
            }

            var invTwo = ModInt.Raw(2).Inverse();

            for (int x = 1; x < pows.Length; x++)
            {
                var result = ModInt.Zero;
                for (int r = 0; r <= x; r++)
                {
                    result += combination.Combination(x, r) * sums[r] * sums[x - r];
                }

                var sub = ModInt.Raw(2).Pow(x) * sums[x];
                result -= sub;
                result *= invTwo;
                io.WriteLine(result);
            }
        }
    }
}
