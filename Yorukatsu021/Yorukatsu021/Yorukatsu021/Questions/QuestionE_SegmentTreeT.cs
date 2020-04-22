using Yorukatsu021.Questions;
using Yorukatsu021.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu021.Questions
{
    /// <summary>
    /// ABC157 E SegmentTree&lt;T&gt;使用版
    /// </summary>
    public class QuestionE_SegmentTreeT : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var s = inputStream.ReadLine();
            var q = inputStream.ReadInt();

            var segmentTree = new SegmentTree<AlphabetFlag>(
                s.Select(c => new AlphabetFlag(c)).ToArray(),
                (a, b) => a | b,
                new AlphabetFlag());

            for (int i = 0; i < q; i++)
            {
                var query = inputStream.ReadLine().Split(' ');

                switch (query[0])
                {
                    case "1":
                        var index = int.Parse(query[1]) - 1;
                        var c = query[2][0];
                        segmentTree[index] = new AlphabetFlag(c);
                        break;
                    case "2":
                        var left = int.Parse(query[1]) - 1;
                        var right = int.Parse(query[2]) - 1;
                        yield return segmentTree.Query(left, right + 1).GetValiations();
                        break;
                    default:
                        break;
                }
            }
        }
    }

    public struct AlphabetFlag
    {
        private readonly uint _flags;

        public AlphabetFlag(char c)
        {
            _flags = 1u << (c - 'a');
        }

        private AlphabetFlag(uint flags)
        {
            _flags = flags;
        }

        public int GetValiations()
        {
            var count = 0;
            var bit = _flags;
            while (bit > 0)
            {
                if ((bit & 0x01) > 0)
                {
                    count++;
                }
                bit >>= 1;
            }
            return count;
        }

        public static AlphabetFlag operator |(AlphabetFlag left, AlphabetFlag right) => new AlphabetFlag(left._flags | right._flags);
    }

    public class AlphabetCount
    {
        const int alphabets = 'z' - 'a' + 1;
        public int[] Count { get; }

        public AlphabetCount()
        {
            Count = new int[alphabets];
        }

        public AlphabetCount(char c)
        {
            Count = new int[alphabets];
            Count[c - 'a'] = 1;
        }

        private AlphabetCount(int[] count)
        {
            Count = count;
        }

        public int Valiations => Count.Count(i => i > 0);

        public static AlphabetCount operator +(AlphabetCount left, AlphabetCount right)
        {
            var sum = new int[alphabets];
            for (int i = 0; i < sum.Length; i++)
            {
                sum[i] = left.Count[i] + right.Count[i];
            }
            return new AlphabetCount(sum);
        }
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
            get
            {
                return _data[_leafOffset + index];
            }
            set
            {
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

        public T Query(int begin, int end) => Query(begin, end, 0, 0, _leafLength);

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
            for (int i = _leafOffset + Length; i < _data.Length; i++)
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
