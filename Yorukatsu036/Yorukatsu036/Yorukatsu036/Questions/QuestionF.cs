using Yorukatsu036.Questions;
using Yorukatsu036.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace Yorukatsu036.Questions
{
    /// <summary>
    /// ABC160 F
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        List<int>[] edges;
        private DPState[] dpStates;

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nodesCount = inputStream.ReadInt();

            edges = Enumerable.Repeat(0, nodesCount).Select(_ => new List<int>()).ToArray();

            for (int i = 0; i < nodesCount - 1; i++)
            {
                var ab = inputStream.ReadIntArray().Select(j => j - 1).ToArray();
                edges[ab[0]].Add(ab[1]);
                edges[ab[1]].Add(ab[0]);
            }

            dpStates = new DPState[nodesCount];

            for (int i = 0; i < dpStates.Length; i++)
            {
                dpStates[i] = new DPState(new Modular(1), 0);
            }

            Dfs(0, -1); // 0の答えだけはOK
            Bfs(0, -1); // 1,2,...について、足りない分を足してあげる
            foreach (var dpState in dpStates)
            {
                yield return dpState.AddRoot().Count.Value;
            }
        }

        /// <summary>
        /// 下がっていくやつ
        /// </summary>
        /// <param name="root"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        private void Dfs(int root, int parent)
        {
            foreach (var child in edges[root])
            {
                if (child != parent)
                {
                    Dfs(child, root);
                    dpStates[root] += dpStates[child].AddRoot();
                }
            }
        }

        /// <summary>
        /// 上がっていくやつ
        /// </summary>
        /// <param name="root"></param>
        /// <param name="parent"></param>
        void Bfs(int root, int parent)
        {
            foreach (var child in edges[root])
            {
                if (child != parent)
                {
                    var d = dpStates[root] - dpStates[child].AddRoot();
                    dpStates[child] += d.AddRoot();
                    Bfs(child, root);
                }
            }
        }

        struct DPState
        {
            public Modular Count { get; }
            public int Size { get; }

            public DPState(Modular count, int size)
            {
                Count = count;
                Size = size;
            }

            public static DPState operator+(DPState state1, DPState state2)
            {
                var size = state1.Size + state2.Size;
                var count = Modular.Combination(size, state1.Size) * state1.Count * state2.Count;
                return new DPState(count, size);
            }

            public static DPState operator-(DPState state1, DPState state2)
            {
                var size = state1.Size - state2.Size;
                var count = state1.Count / (Modular.Combination(state1.Size, state2.Size) * state2.Count);
                return new DPState(count, size);
            }

            public DPState AddRoot() => new DPState(Count, Size + 1);
        }

        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Auto)]
        public struct Modular : IEquatable<Modular>, IComparable<Modular>
        {
            private const int _defaultMod = 1000000007;
            private readonly long _value;    // 0 <= value < Mod の値をとる
            public int Mod { get; }
            public int Value => (int)_value;

            public Modular(long value, int mod = _defaultMod)
            {
                if (mod < 2)
                {
                    throw new ArgumentOutOfRangeException(nameof(mod), $"{nameof(mod)}は2以上の素数でなければなりません。");
                }
                Mod = mod;

                if (value >= 0 && value < mod)
                {
                    _value = value;
                }
                else
                {
                    _value = value % mod;
                    if (Value < 0)
                    {
                        _value += mod;
                    }
                }
            }

            private static void CheckModEquals(Modular a, Modular b)
            {
                if (a.Mod != b.Mod)
                {
                    throw new ArgumentException($"{nameof(a)}, {nameof(b)}", $"両者の法（{nameof(Mod)}）は等しくなければなりません。");
                }
            }

            public static Modular operator +(Modular a, Modular b)
            {
                CheckModEquals(a, b);

                var result = a._value + b._value;
                if (result > a.Mod)
                {
                    result -= a.Mod;    // 剰余演算を避ける
                }
                return new Modular(result, a.Mod);
            }

            public static Modular operator -(Modular a, Modular b)
            {
                CheckModEquals(a, b);

                var result = a._value - b._value;
                if (result < 0)
                {
                    result += a.Mod;    // 剰余演算を避ける
                }
                return new Modular(result, a.Mod);
            }

            public static Modular operator *(Modular a, Modular b)
            {
                CheckModEquals(a, b);
                return new Modular(a._value * b._value, a.Mod);
            }

            public static Modular operator /(Modular a, Modular b)  // こいつは値渡しの方が速いっぽい
            {
                CheckModEquals(a, b);
                return a * Pow(b, a.Mod - 2);
            }

            // 需要は不明だけど一応
            public static bool operator ==(Modular left, Modular right) => left.Equals(right);
            public static bool operator !=(Modular left, Modular right) => !(left == right);
            public static bool operator <(Modular left, Modular right) => left.CompareTo(right) < 0;
            public static bool operator <=(Modular left, Modular right) => left.CompareTo(right) <= 0;
            public static bool operator >(Modular left, Modular right) => left.CompareTo(right) > 0;
            public static bool operator >=(Modular left, Modular right) => left.CompareTo(right) >= 0;

            public static explicit operator int(Modular a) => a.Value;
            public static explicit operator long(Modular a) => a._value;

            public static Modular Pow(Modular a, int n)
            {
                switch (n)
                {
                    case 0:
                        return new Modular(1, a.Mod);
                    case 1:
                        return a;
                    default:
                        var p = Pow(a, n / 2);
                        return p * p * Pow(a, n % 2);
                }
            }

            private static Dictionary<int, List<int>> FactorialCache { get; } = new Dictionary<int, List<int>>();
            private static Dictionary<int, List<int>> PermutationCache { get; } = new Dictionary<int, List<int>>();

            public static Modular Factorial(int n, int mod = _defaultMod)
            {
                if (n < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(n), $"{nameof(n)}は0以上の整数でなければなりません。");
                }
                if (mod < 2)
                {
                    throw new ArgumentOutOfRangeException(nameof(mod), $"{nameof(mod)}は2以上の素数でなければなりません。");
                }

                if (!FactorialCache.ContainsKey(mod))
                {
                    FactorialCache.Add(mod, new List<int>() { 1 });
                }

                var cache = FactorialCache[mod];
                for (int i = cache.Count; i <= n; i++)  // Countが1（0!までキャッシュ済み）のとき1!～n!まで計算
                {
                    cache.Add((int)((long)cache[i - 1] * i % mod));
                }
                return new Modular(cache[n], mod);
            }

            public static Modular Permutation(int n, int r, int mod = _defaultMod)
            {
                CheckNR(n, r);

                if (!PermutationCache.ContainsKey(mod ^ n))
                {
                    PermutationCache.Add(mod ^ n, new List<int>() { 1 });
                }

                var cache = PermutationCache[mod ^ n];
                for (int i = cache.Count; i <= r; i++)  // Countが1（nP0までキャッシュ済み）のときnP1～nPrまで計算
                {
                    cache.Add((int)((long)cache[i - 1] * (n - (i - 1)) % mod));
                }
                return new Modular(cache[r], mod);
            }

            public static Modular Combination(int n, int r, int mod = _defaultMod)
            {
                CheckNR(n, r);
                r = Math.Min(r, n - r);
                return n == r ? new Modular(1, mod) : Permutation(n, r, mod) / Factorial(r, mod);   // nCr = n! / (n-r)!r! = nPr / n!
            }

            public static Modular CombinationWithRepetition(int n, int r, int mod = _defaultMod) => Combination(n + r - 1, r, mod);

            private static void CheckNR(int n, int r)
            {
                if (n <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(n), $"{nameof(n)}は正の整数でなければなりません。");
                }
                if (r < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(r), $"{nameof(r)}は0以上の整数でなければなりません。");
                }
                if (n < r)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(n)},{nameof(r)}", $"{nameof(r)}は{nameof(n)}以下でなければなりません。");
                }
            }

            public override string ToString() => $"{_value} (mod {Mod})";

            public bool Equals(Modular other) => _value == other._value && Mod == other.Mod;

            public int CompareTo(Modular other) => Mod == other.Mod ? _value.CompareTo(other._value) : 0;

            public override int GetHashCode() => Value ^ Mod;
        }

    }
}
