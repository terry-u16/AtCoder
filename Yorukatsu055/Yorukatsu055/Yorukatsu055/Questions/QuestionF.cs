﻿using Yorukatsu055.Questions;
using Yorukatsu055.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu055.Questions
{
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = inputStream.ReadIntArray();

            var duplicated = a.GroupBy(i => i).Single(g => g.Count() > 1).Key;
            var leftIndex = -1;
            var rightIndex = -1;


            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == duplicated)
                {
                    if (leftIndex == -1)
                    {
                        leftIndex = i;
                    }
                    else
                    {
                        rightIndex = i;
                    }
                }
            }

            var left = leftIndex;
            var right = a.Length - rightIndex - 1;
            var center = rightIndex - leftIndex - 1;

            for (int length = 1; length <= a.Length; length++)
            {
                var total = Modular.Combination(a.Length, length);

                if (left + right >= length - 1)
                {
                    total -= Modular.Combination(left + right, length - 1);
                }

                yield return total.Value;
            }


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
            private static Dictionary<int, int[]> FactorialInverseCache { get; } = new Dictionary<int, int[]>();
            private static Dictionary<int, List<int>> PermutationCache { get; } = new Dictionary<int, List<int>>();
            const int maxFactorial = 1000000;

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
                if (!FactorialInverseCache.ContainsKey(mod))
                {
                    InitializeCombinationTable(maxFactorial, mod);
                }
                CheckNR(n, r);
                r = Math.Min(r, n - r);
                return n == r ? new Modular(1, mod) : new Modular(FactorialCache[mod][n], mod) * new Modular(FactorialInverseCache[mod][r], mod) * new Modular(FactorialInverseCache[mod][n - r], mod);
            }

            private static void InitializeCombinationTable(int max, int mod)
            {
                Factorial(max);
                FactorialInverseCache.Add(mod, new int[max + 1]);

                long fInv = (new Modular(1, mod) / Factorial(max, mod)).Value;
                FactorialInverseCache[mod][max] = (int)fInv;
                for (int i = max - 1; i >= 0; i--)
                {
                    fInv = (fInv * (i + 1)) % mod;
                    FactorialInverseCache[mod][i] = (int)fInv;
                }
            }

            public static Modular CombinationWithRepetition(int n, int r, int mod = _defaultMod) => Combination(n + r - 1, r, mod);

            private static void CheckNR(int n, int r)
            {
                if (n < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(n), $"{nameof(n)}は0以上の整数でなければなりません");
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
