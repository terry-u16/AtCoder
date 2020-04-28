using Yorukatsu027.Questions;
using Yorukatsu027.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu027.Questions
{
    /// <summary>
    /// ABC095 D
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nc = inputStream.ReadLongArray();
            int n = (int)nc[0];
            var c = nc[1];

            var sushis = new Sushi[n];
            for (int i = 0; i < n; i++)
            {
                var xv = inputStream.ReadLongArray();
                sushis[i] = new Sushi(xv[0], xv[1]);
            }

            var calorieClockwise = new long[n + 1];
            var calorieCounterClockwise = new long[n + 1];
            var calorieClockwiseReturn = new long[n + 1];
            var calorieCounterClockwiseReturn = new long[n + 1];

            long totalSushiCalorie = 0L;
            for (int i = 0; i < n; i++)
            {
                var sushi = sushis[i];
                totalSushiCalorie += sushi.Calorie;
                calorieClockwise[i + 1] = totalSushiCalorie - sushi.Position;
                calorieClockwiseReturn[i + 1] = totalSushiCalorie - 2 * sushi.Position;
            }

            totalSushiCalorie = 0;
            for (int i = n - 1; i >= 0; i--)
            {
                var sushi = sushis[i];
                totalSushiCalorie += sushi.Calorie;
                calorieCounterClockwise[i] = totalSushiCalorie - (c - sushi.Position);
                calorieCounterClockwiseReturn[i] = totalSushiCalorie - 2 * (c - sushi.Position);
            }

            var calorieClockwiseSeg = new SegmentTree<long>(calorieClockwise, (a, b) => Math.Max(a, b), long.MinValue);
            var calorieCounterClockwiseSeg = new SegmentTree<long>(calorieCounterClockwise, (a, b) => Math.Max(a, b), long.MinValue);
            var calorieClockwiseReturnSeg = new SegmentTree<long>(calorieClockwiseReturn, (a, b) => Math.Max(a, b), long.MinValue);
            var calorieCounterClockwiseReturnSeg = new SegmentTree<long>(calorieCounterClockwiseReturn, (a, b) => Math.Max(a, b), long.MinValue);

            var maxCalorie = long.MinValue;
            for (int i = 0; i <= n; i++)
            {
                maxCalorie = Math.Max(maxCalorie, calorieClockwiseSeg.Query(0, i + 1) + calorieCounterClockwiseReturnSeg.Query(i, calorieCounterClockwiseReturnSeg.Length + 1));
                maxCalorie = Math.Max(maxCalorie, calorieClockwiseReturnSeg.Query(0, i + 1) + calorieCounterClockwiseSeg.Query(i, calorieCounterClockwiseSeg.Length + 1));
            }

            yield return maxCalorie;
        }
    }

    struct Sushi
    {
        public long Position { get; }
        public long Calorie { get; }

        public Sushi(long position, long calorie)
        {
            Position = position;
            Calorie = calorie;
        }

        public override string ToString() => $"Position:{Position}, Calorie:{Calorie}";
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
