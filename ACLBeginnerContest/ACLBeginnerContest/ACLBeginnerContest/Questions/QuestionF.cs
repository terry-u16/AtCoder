using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Runtime.Intrinsics.X86;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ACLBeginnerContest.Algorithms;
using ACLBeginnerContest.Collections;
using ACLBeginnerContest.Numerics;
using ACLBeginnerContest.Questions;
using AtCoder;
using AtCoder.Internal;
using ModInt = AtCoder.StaticModInt<AtCoder.Mod998244353>;
using System.Diagnostics.CodeAnalysis;

namespace ACLBeginnerContest.Questions
{
    public class QuestionF : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var n = io.ReadInt();
            var combination = new Combinations<Mod998244353>(2 * n);
            var h = new int[1000001];
            var doubleFacts = GetDoubleFactorials(2 * n + 1);

            for (int i = 0; i < 2 * n; i++)
            {
                h[io.ReadInt()]++;
            }

            var queue = new PriorityQueue<ArrayWrapper>(false);

            for (int i = 0; i < h.Length; i++)
            {
                if (h[i] > 0)
                {
                    var a = new ModInt[h[i] / 2 + 1];
                    for (int j = 0; j < a.Length; j++)
                    {
                        a[j] = combination.Combination(h[i], 2 * j) * MakePair(2 * j);
                    }
                    queue.Enqueue(new ArrayWrapper(a));
                }
            }

            while (queue.Count > 1)
            {
                var a = queue.Dequeue().Array;
                var b = queue.Dequeue().Array;
                var c = AtCoder.Math.Convolution(a, b);
                queue.Enqueue(new ArrayWrapper(c));
            }

            var choosings = queue.Dequeue().Array;

            var result = new ModInt();

            for (int i = 0; i < choosings.Length; i++)
            {
                result += (i % 2 == 0 ? 1 : -1) * choosings[i] * MakePair(2 * n - 2 * i);
            }

            io.WriteLine(result);

            ModInt MakePair(int n) => unchecked((uint)(n - 1) < doubleFacts.Length) ? doubleFacts[n - 1] : ModInt.Raw(1);
        }

        ModInt[] GetDoubleFactorials(int n)
        {
            var result = new ModInt[n + 1];
            result[0] = 1;
            result[1] = 1;

            for (int i = 2; i < result.Length; i++)
            {
                result[i] = result[i - 2] * ModInt.Raw(i);
            }

            return result;
        }

        readonly struct ArrayWrapper : IComparable<ArrayWrapper>
        {
            public ModInt[] Array { get; }

            public ArrayWrapper(ModInt[] array)
            {
                Array = array;
            }

            public int CompareTo([AllowNull] ArrayWrapper other) => Array.Length - other.Array.Length;
        }

        public class Combinations<T> where T : struct, IStaticMod
        {
            StaticModInt<T>[] _factorials;
            StaticModInt<T>[] _invFactorials;

            public Combinations(int max)
            {
                if (!default(T).IsPrime)
                {
                    throw new InvalidOperationException("modは素数である必要があります。");
                }

                var length = max + 1;
                _factorials = new StaticModInt<T>[length];
                _invFactorials = new StaticModInt<T>[length];

                _factorials[0] = 1;
                _factorials[1] = 1;

                for (int i = 2; i < _factorials.Length; i++)
                {
                    _factorials[i] = _factorials[i - 1] * i;
                }

                _invFactorials[^1] = _factorials[^1].Inv();

                for (int i = _factorials.Length - 1; i >= 1; i--)
                {
                    _invFactorials[i - 1] = _invFactorials[i] * i;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public StaticModInt<T> Combination(int n, int k)
            {
                if (n < 0 || unchecked(n < (uint)k))
                {
                    ThrowArgumentException("0 <= n, 0 <= k <= n でなければなりません。");
                }

                return _factorials[n] * _invFactorials[k] * _invFactorials[n - k];
            }

            public StaticModInt<T> Permutation(int n, int k) => _factorials[n] * _invFactorials[n - k];

            public StaticModInt<T> Factorial(int n) => _factorials[n];

            private void ThrowArgumentException(string s) => throw new ArgumentException(s);
        }

    }
}
