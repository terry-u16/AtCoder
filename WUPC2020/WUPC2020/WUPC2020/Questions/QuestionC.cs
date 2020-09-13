using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using WUPC2020.Extensions;
using WUPC2020.Questions;

namespace WUPC2020.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            Modular.InitializeCombinationTable();
            var n = inputStream.ReadInt();
            var a = inputStream.ReadIntArray();
            var diffs = new Modular[a.Length - 1];

            for (int i = 0; i < diffs.Length; i++)
            {
                diffs[i] = new Modular(Math.Abs(a[i] - a[i + 1]));
            }

            var result = Modular.GetZero();
            for (int i = 0; i < diffs.Length; i++)
            {
                result += diffs[i] * Modular.Combination(diffs.Length - 1, i);
            }

            yield return result;
        }

        public struct Modular : IEquatable<Modular>, IComparable<Modular>
        {
            private const int DefaultMod = 1000000007;
            public int Value;
            public static int Mod = DefaultMod;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Modular(long value)
            {
                if (unchecked((ulong)value) < unchecked((ulong)Mod))
                {
                    Value = (int)value;
                }
                else
                {
                    Value = (int)(value % Mod);
                    if (Value < 0)
                    {
                        Value += Mod;
                    }
                }
            }

            private Modular(int value)
            {
                Value = value;
            }

            public static Modular GetZero()
            {
                return new Modular(0);
            }

            public static Modular GetOne()
            {
                return new Modular(1);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static Modular operator +(Modular a, Modular b)
            {
                var result = a.Value + b.Value;
                if (result >= Mod)
                {
                    result -= Mod;    // 剰余演算を避ける
                }
                return new Modular(result);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static Modular operator -(Modular a, Modular b)
            {
                var result = a.Value - b.Value;
                if (result < 0)
                {
                    result += Mod;    // 剰余演算を避ける
                }
                return new Modular(result);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static Modular operator *(Modular a, Modular b)
            {
                return new Modular((long)a.Value * b.Value);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static Modular operator /(Modular a, Modular b)
            {
                return a * Pow(b.Value, Mod - 2);
            }

            public static implicit operator Modular(long a)
            {
                return new Modular(a);
            }

            public static explicit operator int(Modular a)
            {
                return a.Value;
            }

            public static explicit operator long(Modular a)
            {
                return a.Value;
            }

            public static Modular Pow(int a, int n)
            {
                if (n == 0)
                {
                    return Modular.GetOne();
                }
                else if (n == 1)
                {
                    return a;
                }
                else if (n > 0)
                {
                    var p = Pow(a, n >> 1);             // m / 2
                    return p * p * Pow(a, n & 0x01);    // m % 2
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(n), $"べき指数{nameof(n)}は0以上の整数でなければなりません。");
                }
            }

            private static List<int> _factorialCache;

            private static List<int> GetFactorialCache()
            {
                if (_factorialCache == null)
                {
                    _factorialCache = new List<int>() { 1 };
                }
                return _factorialCache;
            }

            private static int[] FactorialInverseCache { get; set; }
            const int defaultMaxFactorial = 1000000;

            public static Modular Factorial(int n)
            {
                if (n < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(n), $"{nameof(n)}は0以上の整数でなければなりません。");
                }

                for (int i = GetFactorialCache().Count; i <= n; i++)  // Countが1（0!までキャッシュ済み）のとき1!～n!まで計算
                {
                    GetFactorialCache().Add((int)((long)GetFactorialCache()[i - 1] * i % Mod));
                }
                return new Modular(GetFactorialCache()[n]);
            }

            public static Modular Permutation(int n, int r)
            {
                CheckNR(n, r);
                return Factorial(n) / Factorial(n - r);
            }

            public static Modular Combination(int n, int r)
            {
                CheckNR(n, r);
                r = Math.Min(r, n - r);
                try
                {
                    return new Modular(GetFactorialCache()[n]) * new Modular(FactorialInverseCache[r]) * new Modular(FactorialInverseCache[n - r]);
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException($"{nameof(Combination)}を呼び出す前に{nameof(InitializeCombinationTable)}により前計算を行う必要があります。", ex);
                }
            }

            public static void InitializeCombinationTable(int max = defaultMaxFactorial)
            {
                Factorial(max);
                FactorialInverseCache = new int[max + 1];

                var fInv = (Modular.GetOne() / Factorial(max)).Value;
                FactorialInverseCache[max] = fInv;
                for (int i = max - 1; i >= 0; i--)
                {
                    fInv = (int)((long)fInv * (i + 1) % Mod);
                    FactorialInverseCache[i] = fInv;
                }
            }

            private static void CheckNR(int n, int r)
            {
                if (n < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(n), $"{nameof(n)}は0以上の整数でなければなりません。");
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

            public override string ToString()
            {
                return Value.ToString();
            }

            public override bool Equals(object obj)
            {
                if (obj is Modular)
                {
                    return Equals((Modular)obj);
                }
                else
                {
                    return false;
                }
            }

            public bool Equals(Modular other)
            {
                return Value == other.Value;
            }

            public int CompareTo(Modular other)
            {
                return Value.CompareTo(other.Value);
            }

            public override int GetHashCode()
            {
                return Value.GetHashCode();
            }
        }
    }
}
