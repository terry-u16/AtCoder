﻿using AtCoderBeginnerContest135.Questions;
using AtCoderBeginnerContest135.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest135.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();
            s = string.Concat(s.Reverse());

            var modCount = new Modular[s.Length + 1, 13];

            for (int i = 0; i < modCount.GetLength(0); i++)
            {
                for (int j = 0; j < modCount.GetLength(1); j++)
                {
                    modCount[i, j] = new Modular(0);
                }
            }

            modCount[0, 0] = new Modular(1);

            var tenFactorMod = new Modular(1, 13);

            for (int digit = 0; digit < s.Length; digit++)
            {
                if (s[digit] == '?')
                {
                    for (int wildValue = 0; wildValue < 10; wildValue++)
                    {
                        var currentDigitMod = tenFactorMod * new Modular(wildValue, 13);
                        for (int mod = 0; mod < 13; mod++)
                        {
                            modCount[digit + 1, (new Modular(mod, 13) + currentDigitMod).Value] += modCount[digit, mod];
                        }
                    }
                }
                else
                {
                    var current = s[digit] - '0';
                    var currentDigitMod = tenFactorMod * new Modular(current, 13);
                    for (int mod = 0; mod < 13; mod++)
                    {
                        modCount[digit + 1, (new Modular(mod, 13) + currentDigitMod).Value] = modCount[digit, mod];
                    }
                }

                tenFactorMod *= new Modular(10, 13);
            }

            yield return modCount[s.Length, 5].Value;
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
