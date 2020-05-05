using AtCoderBeginnerContest125.Questions;
using AtCoderBeginnerContest125.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest125.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = inputStream.ReadLongArray();
            var segmentTree = new SegmentTree<long?>(a.Cast<long?>().ToArray(), (x, y) =>
            {
                if (x == null)
                {
                    return y;
                }
                else if (y == null)
                {
                    return x;
                }
                else
                {
                    return Gcd(x.Value, y.Value);
                }
            }, null);

            var maxGcd = segmentTree.Query(1, segmentTree.Length).Value;
            for (int i = 1; i < segmentTree.Length - 1; i++)
            {
                maxGcd = Math.Max(maxGcd, Gcd(segmentTree.Query(0, i).Value, segmentTree.Query(i + 1, segmentTree.Length).Value));
            }
            maxGcd = Math.Max(maxGcd, segmentTree.Query(0, segmentTree.Length - 1).Value);

            yield return maxGcd;
        }

        public static long Gcd(long a, long b)
        {
            if (a <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(a), $"{nameof(b)}は正の整数である必要があります。");
            }
            if (b <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(b), $"{nameof(b)}は正の整数である必要があります。");
            }
            if (a < b)
            {
                var temp = a;
                a = b;
                b = temp;
            }

            while (b != 0)
            {
                var temp = a % b;
                a = b;
                b = temp;
            }
            return a;
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

    }
}
