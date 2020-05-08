using Yorukatsu035.Questions;
using Yorukatsu035.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;

namespace Yorukatsu035.Questions
{
    /// <summary>
    /// ABC159 F
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var ns = inputStream.ReadIntArray();
            var s = ns[1];
            var a = inputStream.ReadIntArray();

            const int mod = 998244353;
            var counts = new Modular[a.Length + 1, s + 1, 3];   // 3引数目は状態（0:L未決定, 1:R未決定, 2:両方決定）
            Clear(counts, mod);
            counts[0, 0, 0] = new Modular(1);

            for (int item = 0; item < a.Length; item++)
            {
                var ai = a[item];
                for (int sum = 0; sum <= s; sum++)
                {
                    // 0
                    counts[item + 1, sum, 0] += counts[item, sum, 0];   // 0 -> 0
                    counts[item + 1, sum, 1] += counts[item, sum, 1];   // 1 -> 1
                    counts[item + 1, sum, 2] += counts[item, sum, 2];   // 2 -> 2

                    if (sum + ai <= s)
                    {
                        counts[item + 1, sum + ai, 1] += counts[item, sum, 0] * new Modular(item + 1);   // 0 -> 1
                        counts[item + 1, sum + ai, 2] += counts[item, sum, 0] * new Modular((item + 1) * (a.Length - item));   // 0 -> 1 -> 2
                        counts[item + 1, sum + ai, 1] += counts[item, sum, 1]; // 1 -> 1
                        counts[item + 1, sum + ai, 2] += counts[item, sum, 1] * new Modular(a.Length - item); // 1 -> 2
                    }
                }
            }

            yield return counts[a.Length, s, 2].Value;
        }

        private static void Clear(Modular[,,] counts, int mod)
        {
            for (int i = 0; i < counts.GetLength(0); i++)
            {
                for (int j = 0; j < counts.GetLength(1); j++)
                {
                    for (int k = 0; k < counts.GetLength(2); k++)
                    {
                        counts[i, j, k] = new Modular(0);
                    }
                }
            }
        }

        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Auto)]
        public struct Modular : IEquatable<Modular>, IComparable<Modular>
        {
            private const int Mod = 998244353;
            private readonly long _value;    // 0 <= value < Mod の値をとる
            public int Value => (int)_value;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Modular(long value)
            {
                if (value >= 0 && value < Mod)
                {
                    _value = value;
                }
                else
                {
                    _value = value % Mod;
                    if (Value < 0)
                    {
                        _value += Mod;
                    }
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static Modular operator +(Modular a, Modular b)
            {
                var result = a._value + b._value;
                if (result > Mod)
                {
                    result -= Mod;    // 剰余演算を避ける
                }
                return new Modular(result);
            }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static Modular operator -(Modular a, Modular b)
            {
                var result = a._value - b._value;
                if (result < 0)
                {
                    result += Mod;    // 剰余演算を避ける
                }
                return new Modular(result);
            }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static Modular operator *(Modular a, Modular b)
            {
                return new Modular(a._value * b._value);
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


            public override string ToString() => $"{_value} (mod {Mod})";

            public bool Equals(Modular other) => _value == other._value;

            public int CompareTo(Modular other) => _value.CompareTo(other._value);

            public override int GetHashCode() => Value ^ Mod;
        }

    }
}
