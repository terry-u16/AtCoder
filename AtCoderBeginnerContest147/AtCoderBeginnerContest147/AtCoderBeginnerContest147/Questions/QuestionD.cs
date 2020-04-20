using AtCoderBeginnerContest147.Questions;
using AtCoderBeginnerContest147.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest147.Questions
{
    /// <summary>
    /// 復習
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = inputStream.ReadLongArray();

            var sum = new Modular(0);
            const int maxDigit = 60;

            for (int digit = 0; digit < maxDigit; digit++)
            {
                var mask = 1L << digit;
                var b0 = a.Count(e => (e & mask) > 0);
                var b1 = a.Length - b0;
                sum += new Modular(b0) * new Modular(b1) * new Modular(mask);
            }

            yield return sum.Value;
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

        public static Modular Combination(int n, int r, int mod = _defaultMod)
        {
            CheckNR(n, r);
            return n == r ? new Modular(1, mod) : Factorial(n, mod) / (Factorial(r, mod) * Factorial(n - r, mod));   // nCr = n! / (n-r)!r! = nPr / n!
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

        public override bool Equals(object obj) => obj is Modular && Equals((Modular)obj);

        public int CompareTo(Modular other) => Mod == other.Mod ? _value.CompareTo(other._value) : 0;

        public override int GetHashCode() => Value ^ Mod;
    }

}
