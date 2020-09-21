using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ACLContest1.Algorithms;
using ACLContest1.Collections;
using ACLContest1.Numerics;
using ACLContest1.Questions;
using System.Diagnostics;
using System.Numerics;
using System.Reflection;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
using AtCoder;
using AtCoder.Internal;
using Math = System.Math;

namespace ACLContest1.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var n = io.ReadLong() * 2;
            var primes = PrimeFactorize(n).ToArray();

            long result = long.MaxValue;

            for (var flag = BitSet.Zero; flag < 1 << primes.Length; flag++)
            {
                var me = 1L;
                for (int i = 0; i < primes.Length; i++)
                {
                    if (flag[i])
                    {
                        for (int pow = 0; pow < primes[i].Count; pow++)
                        {
                            me *= primes[i].Prime;
                        }
                    }
                }

                var you = n / me;

                if (you > 1)
                {
                    var (remain, _) = AtCoder.Math.CRT(new long[] { 0, you - 1 }, new long[] { me, you });
                    result = Math.Min(result, remain);
                }
            }

            io.WriteLine(result);
        }

        IEnumerable<PrimeAndCount> PrimeFactorize(long n)
        {
            for (long i = 2; i * i <= n; i++)
            {
                var count = 0;

                while (n % i == 0)
                {
                    count++;
                    n /= i;
                }

                if (count > 0)
                {
                    yield return new PrimeAndCount(i, count);
                }
            }

            if (n > 1)
            {
                yield return new PrimeAndCount(n, 1);
            }
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct PrimeAndCount
        {
            public long Prime { get; }
            public int Count { get; }

            public PrimeAndCount(long prime, int count)
            {
                Prime = prime;
                Count = count;
            }

            public void Deconstruct(out long prime, out int count) => (prime, count) = (Prime, Count);
            public override string ToString() => $"{nameof(Prime)}: {Prime}, {nameof(Count)}: {Count}";
        }
    }
}
