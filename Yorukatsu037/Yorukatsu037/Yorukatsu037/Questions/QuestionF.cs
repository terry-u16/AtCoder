using Yorukatsu037.Questions;
using Yorukatsu037.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu037.Questions
{
    /// <summary>
    /// ABC158 F
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var robots = new Robot[n];

            for (int i = 0; i < n; i++)
            {
                var xd = inputStream.ReadIntArray();
                robots[i] = new Robot(xd[0], xd[1]);
            }

            Array.Sort(robots);
            Array.Reverse(robots);

            var unitedRobots = new UnionFindTree(robots.Select(r => r.Destination));
            var destinations = new SegmentTree<int>(robots.Select(r => r.Destination).ToArray(), (d1, d2) => Math.Max(d1, d2), int.MinValue);

            const int mod = 998244353;
            var counts = new Modular[robots.Length + 1];
            for (int i = 0; i < counts.Length; i++)
            {
                counts[i] = new Modular(0, mod);
            }
            counts[0] = new Modular(1, mod);

            for (int i = 0; i < robots.Length; i++)
            {
                var currentRobot = robots[i];
                var inRangeRobotIndex = BoundaryBinarySearch(mid => robots[mid].Coordinate < currentRobot.Destination, -1, i);

                while (!unitedRobots.IsInSameGroup(inRangeRobotIndex, i))
                {
                    var hasntUnited = BoundaryBinarySearch(mid => !unitedRobots.IsInSameGroup(mid, i), i, inRangeRobotIndex);
                    unitedRobots.Unite(hasntUnited, i);
                }

                var outOfRangeRobotIndex = BoundaryBinarySearch(mid => !unitedRobots.IsInSameGroup(mid, i), i, -1);

                counts[i + 1] += counts[i] + counts[outOfRangeRobotIndex + 1];
            }

            yield return counts[robots.Length].Value;
        }

        struct Robot : IComparable<Robot>
        {
            public int Coordinate { get; }
            public int Length { get; }
            public int Destination { get; }

            public Robot(int coordinate, int length)
            {
                Coordinate = coordinate;
                Length = length;
                Destination = coordinate + length;
            }

            public int CompareTo(Robot other) => Coordinate.CompareTo(other.Coordinate);

            public override string ToString() => $"X:{Coordinate}, D:{Length}";
        }

        private static int BoundaryBinarySearch(Predicate<int> predicate, int ng, int ok)
        {
            // めぐる式二分探索
            // Span.BinarySearchだとできそうでできない（lower_boundがダメ）
            while (Math.Abs(ok - ng) > 1)
            {
                int mid = (ok + ng) / 2;

                if (predicate(mid))
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

        public class SegmentTree<T> : IEnumerable<T>
        {
            private readonly T[] _data;
            private readonly T _identityElement;
            private readonly Func<T, T, T> _queryOperation;

            private readonly int _leafOffset;   // n - 1
            private readonly int _leafLength;   // n (= 2^k)

            public int Length { get; }          // 実データ長

            public SegmentTree(ICollection<T> data, Func<T, T, T> queryOperation, T identityElement)
            {
                Length = data.Count;
                _leafLength = GetMinimumPow2(data.Count);
                _leafOffset = _leafLength - 1;
                _data = new T[_leafOffset + _leafLength];
                _queryOperation = queryOperation;
                _identityElement = identityElement;

                data.CopyTo(_data, _leafOffset);
                BuildTree();
            }

            public T this[int index]
            {
                set
                {
                    if (index < 0 || index >= Length)
                    {
                        throw new IndexOutOfRangeException($"{nameof(index)}がデータの範囲外です。");
                    }
                    index += _leafOffset;
                    _data[index] = value;
                    while (index > 0)
                    {
                        // 一つ上の親の更新
                        index = (index - 1) / 2;
                        _data[index] = _queryOperation(_data[index * 2 + 1], _data[index * 2 + 2]);
                    }
                }
            }

            public T Query(int begin, int end)
            {
                if (begin < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(begin), $"{nameof(begin)}は0以上の数でなければなりません。");
                }
                if (end > Length)
                {
                    throw new ArgumentOutOfRangeException(nameof(end), $"{nameof(end)}は{nameof(Length)}以下でなければなりません。");
                }
                if (begin >= end)
                {
                    throw new ArgumentException($"{nameof(begin)},{nameof(end)}", $"{nameof(end)}は{nameof(begin)}より大きい数でなければなりません。");
                }
                return Query(begin, end, 0, 0, _leafLength);
            }

            private T Query(int begin, int end, int index, int left, int right)
            {
                if (right <= begin || end <= left)      // 範囲外
                {
                    return _identityElement;
                }
                else if (begin <= left && right <= end) // 全部含まれる
                {
                    return _data[index];
                }
                else    // 一部だけ含まれる
                {
                    var leftValue = Query(begin, end, index * 2 + 1, left, (left + right) / 2);     // 左の子
                    var rightValue = Query(begin, end, index * 2 + 2, (left + right) / 2, right);   // 右の子
                    return _queryOperation(leftValue, rightValue);
                }
            }

            private void BuildTree()
            {
                for (int i = _leafLength + Length; i < _data.Length; i++)
                {
                    _data[i] = _identityElement;
                }

                for (int i = _leafLength - 2; i >= 0; i--)  // 葉の親から順番に一つずつ上がっていく
                {
                    _data[i] = _queryOperation(_data[2 * i + 1], _data[2 * i + 2]); // f(left, right)
                }
            }

            private int GetMinimumPow2(int n)
            {
                var p = 1;
                while (p < n)
                {
                    p *= 2;
                }
                return p;
            }

            public IEnumerator<T> GetEnumerator()
            {
                var upperIndex = _leafOffset + Length;
                for (int i = _leafOffset; i < upperIndex; i++)
                {
                    yield return _data[i];
                }
            }

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
        }


        // See https://kumikomiya.com/competitive-programming-with-c-sharp/
        public class UnionFindTree
        {
            private UnionFindNode[] _nodes;
            public int Count => _nodes.Length;
            public int Groups { get; private set; }

            public UnionFindTree(IEnumerable<int> destinations)
            {
                _nodes = destinations.Select(i => new UnionFindNode(i)).ToArray();
                Groups = _nodes.Length;
            }

            public void Unite(int index1, int index2)
            {
                var united = _nodes[index1].Unite(_nodes[index2]);
                if (united)
                {
                    Groups--;
                }
            }

            public bool IsInSameGroup(int index1, int index2) => _nodes[index1].IsInSameGroup(_nodes[index2]);
            public int GetGroupSizeOf(int index) => _nodes[index].GetGroupSize();
            public int this[int index] => _nodes[index].Destination;

            private class UnionFindNode
            {
                private int _height;        // rootのときのみ有効
                private int _groupSize;     // 同上
                private UnionFindNode _parent;
                public int Destination { get; private set; }

                public UnionFindNode(int id)
                {
                    _height = 0;
                    _groupSize = 1;
                    _parent = this;
                    Destination = id;
                }

                public UnionFindNode FindRoot()
                {
                    if (_parent != this) // not ref equals
                    {
                        var root = _parent.FindRoot();
                        _parent = root;
                    }

                    return _parent;
                }

                public int GetGroupSize() => FindRoot()._groupSize;

                public bool Unite(UnionFindNode other)
                {
                    var thisRoot = this.FindRoot();
                    var otherRoot = other.FindRoot();

                    var max = Math.Max(thisRoot.Destination, otherRoot.Destination);
                    thisRoot.Destination = max;
                    otherRoot.Destination = max;

                    if (thisRoot == otherRoot)
                    {
                        return false;
                    }

                    if (thisRoot._height < otherRoot._height)
                    {
                        thisRoot._parent = otherRoot;
                        otherRoot._groupSize += thisRoot._groupSize;
                        otherRoot._height = Math.Max(thisRoot._height + 1, otherRoot._height);
                        return true;
                    }
                    else
                    {
                        otherRoot._parent = thisRoot;
                        thisRoot._groupSize += otherRoot._groupSize;
                        thisRoot._height = Math.Max(otherRoot._height + 1, thisRoot._height);
                        return true;
                    }
                }

                public bool IsInSameGroup(UnionFindNode other) => this.FindRoot() == other.FindRoot();

                public override string ToString() => $"{Destination} root:{FindRoot().Destination}";
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
