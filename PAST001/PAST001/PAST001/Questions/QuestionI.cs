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
using PAST001.Algorithms;
using PAST001.Collections;
using PAST001.Numerics;
using PAST001.Questions;

namespace PAST001.Questions
{
    public class QuestionI : AtCoderQuestionBase
    {
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public override void Solve(IOManager io)
        {
            const long Inf = 1L << 60;
            var n = io.ReadInt();
            var setCount = io.ReadInt();

            var sets = new Set[setCount];

            for (int i = 0; i < sets.Length; i++)
            {
                var s = io.ReadString();
                var p = io.ReadInt();
                var flags = 0;

                for (int j = 0; j < n; j++)
                {
                    flags <<= 1;
                    if (s[j] == 'Y')
                    {
                        flags |= 1;
                    }
                }

                sets[i] = new Set(flags, p);
            }

            var dp = new long[sets.Length + 1, 1 << n];
            dp.Fill(Inf);
            dp[0, 0] = 0;

            for (int i = 0; i < sets.Length; i++)
            {
                for (int last = 0; last < 1 << n; last++)
                {
                    dp[i + 1, last].ChangeMin(dp[i, last]);
                    dp[i + 1, last | sets[i].Parts].ChangeMin(dp[i, last] + sets[i].Price);
                }
            }

            var result = dp[sets.Length, (1 << n) - 1];

            if (result < Inf)
            {
                io.WriteLine(result);
            }
            else
            {
                io.WriteLine(-1);
            }
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Set
        {
            public readonly int Parts;
            public readonly int Price;

            public Set(int parts, int price)
            {
                Parts = parts;
                Price = price;
            }

            public void Deconstruct(out int parts, out int price) => (parts, price) = (Parts, Price);
            public override string ToString() => $"{nameof(Parts)}: {Parts}, {nameof(Price)}: {Price}";
        }
    }
}
