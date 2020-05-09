// ここにQuestionクラスをコピペ
using EducationalDPContest.Questions;
using EducationalDPContest.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EducationalDPContest
{
    class Program
    {
        static void Main(string[] args)
        {
            IAtCoderQuestion question = new QuestionJ();    // 問題に合わせて書き換え
            var answers = question.Solve(Console.In);
            foreach (var answer in answers)
            {
                Console.WriteLine(answer);
            }
        }
    }
}

#region Base Classes

namespace EducationalDPContest.Questions
{

    public interface IAtCoderQuestion
    {
        IEnumerable<object> Solve(string input);
        IEnumerable<object> Solve(TextReader inputStream);
    }

    public abstract class AtCoderQuestionBase : IAtCoderQuestion
    {
        public IEnumerable<object> Solve(string input)
        {
            var stream = new MemoryStream(Encoding.Unicode.GetBytes(input));
            var reader = new StreamReader(stream, Encoding.Unicode);

            return Solve(reader);
        }

        public abstract IEnumerable<object> Solve(TextReader inputStream);

        protected void UpdateWhenSmall<T>(ref T value, T other) where T : IComparable<T>
        {
            if (other.CompareTo(value) < 0)
            {
                value = other;
            }
        }

        protected void UpdateWhenLarge<T>(ref T value, T other) where T : IComparable<T>
        {
            if (other.CompareTo(value) > 0)
            {
                value = other;
            }
        }
    }

}

#endregion

#region Algorithms

namespace EducationalDPContest.Algorithms
{
    public struct Modular : IEquatable<Modular>, IComparable<Modular>
    {
        private const int _defaultMod = 1000000007;
        public int Value { get; }
        public int Mod { get; }     // 配列とかで引数なしコンストラクタが呼ばれると0で初期化されて死ぬ（ガイドライン違反）（int?にすると割り算が2倍遅くなる）（諦め）（運用でカバー）

        public Modular(long value, int mod = _defaultMod)
        {
            if (mod < 2 || mod > 1073741789)
            {
                // 1073741789はint.MaxValue / 2 = 1073741823以下の最大の素数
                throw new ArgumentOutOfRangeException(nameof(mod), $"{nameof(mod)}は2以上1073741789以下の素数でなければなりません。");
            }
            Mod = mod;

            if (value >= 0 && value < mod)
            {
                Value = (int)value;
            }
            else
            {
                Value = (int)(value % mod);
                if (Value < 0)
                {
                    Value += mod;
                }
            }
        }

        public static Modular operator +(Modular a, Modular b)
        {
            CheckModEquals(a, b);

            var result = a.Value + b.Value;
            if (result > a.Mod)
            {
                result -= a.Mod;    // 剰余演算を避ける
            }
            return new Modular(result, a.Mod);
        }

        public static Modular operator -(Modular a, Modular b)
        {
            CheckModEquals(a, b);

            var result = a.Value - b.Value;
            if (result < 0)
            {
                result += a.Mod;    // 剰余演算を避ける
            }
            return new Modular(result, a.Mod);
        }

        public static Modular operator *(Modular a, Modular b)
        {
            CheckModEquals(a, b);
            return new Modular((long)a.Value * b.Value, a.Mod);
        }

        public static Modular operator /(Modular a, Modular b)
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
        public static explicit operator long(Modular a) => a.Value;

        public static Modular Pow(Modular a, int n)
        {
            if (n < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(n), $"べき指数{nameof(n)}は0以上の整数でなければなりません。");
            }
            switch (n)
            {
                case 0:
                    return new Modular(1, a.Mod);
                case 1:
                    return a;
                default:
                    var p = Pow(a, n >> 1);             // m / 2
                    return p * p * Pow(a, n & 0x01);    // m % 2
            }
        }

        private static Dictionary<int, List<int>> FactorialCache = new Dictionary<int, List<int>>();
        private static Dictionary<long, List<int>> PermutationCache = new Dictionary<long, List<int>>();

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

            if (!PermutationCache.ContainsKey(Concat(mod, n)))
            {
                PermutationCache.Add(Concat(mod, n), new List<int>() { 1 });
            }

            var cache = PermutationCache[Concat(mod, n)];
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

        public static Modular[] CreateArray(int length, int mod = _defaultMod) => Enumerable.Repeat(new Modular(0, mod), length).ToArray();

        private static void CheckModEquals(Modular a, Modular b)
        {
            if (a.Mod != b.Mod)
            {
                throw new ArgumentException($"{nameof(a)}, {nameof(b)}", $"両者の法{nameof(Mod)}は等しくなければなりません。");
            }
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

        public override string ToString() => $"{Value} (mod {Mod})";

        public override bool Equals(object obj) => obj is Modular ? Equals((Modular)obj) : false;

        public bool Equals(Modular other) => Value == other.Value && Mod == other.Mod;

        public int CompareTo(Modular other)
        {
            CheckModEquals(this, other);
            return Value.CompareTo(other.Value);
        }

        public override int GetHashCode() => Concat(Value, Mod).GetHashCode();

        static long Concat(int a, int b) => (a << 32) | b;
    }
}

#endregion

#region Collections

namespace EducationalDPContest.Collections
{
    public static class SearchExtension
    {
        public static int GetGreaterEqualIndex<T>(this T[] span, T minValue) where T : IComparable<T>
        {
            int ng = -1;
            int ok = span.Length;

            return BoundaryBinarySearch(span, v => v.CompareTo(minValue) >= 0, ng, ok);
        }

        public static int GetSmallerEqualIndex<T>(this T[] span, T maxValue) where T : IComparable<T>
        {
            int ng = span.Length;
            int ok = -1;

            return BoundaryBinarySearch(span, v => v.CompareTo(maxValue) <= 0, ng, ok);
        }

        private static int BoundaryBinarySearch<T>(T[] span, Predicate<T> predicate, int ng, int ok)
        {
            // めぐる式二分探索
            // Span.BinarySearchだとできそうでできない（lower_boundがダメ）
            while (Math.Abs(ok - ng) > 1)
            {
                int mid = (ok + ng) / 2;

                if (predicate(span[mid]))
                {
                    ok = mid;
                }
                else
                {
                    ng = mid;
                }
            }
            return ok;
        }
    }
}

#endregion

#region Extensions

namespace EducationalDPContest.Extensions
{
    internal static class TextReaderExtensions
    {
        internal static int ReadInt(this TextReader reader) => int.Parse(ReadString(reader));
        internal static long ReadLong(this TextReader reader) => long.Parse(ReadString(reader));
        internal static double ReadDouble(this TextReader reader) => double.Parse(ReadString(reader));
        internal static string ReadString(this TextReader reader) => reader.ReadLine();

        internal static int[] ReadIntArray(this TextReader reader, char separator = ' ') => ReadStringArray(reader, separator).Select(int.Parse).ToArray();
        internal static long[] ReadLongArray(this TextReader reader, char separator = ' ') => ReadStringArray(reader, separator).Select(long.Parse).ToArray();
        internal static double[] ReadDoubleArray(this TextReader reader, char separator = ' ') => ReadStringArray(reader, separator).Select(double.Parse).ToArray();
        internal static string[] ReadStringArray(this TextReader reader, char separator = ' ') => reader.ReadLine().Split(separator);
    }
}

#endregion