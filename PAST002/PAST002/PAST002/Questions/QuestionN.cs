using PAST002.Algorithms;
using PAST002.Collections;
using PAST002.Questions;
using PAST002.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Diagnostics.CodeAnalysis;

namespace PAST002.Questions
{
    /// <summary>
    /// 復習
    /// </summary>
    public class QuestionN : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (sitesCount, queriesCount) = inputStream.ReadValue<int, int>();
            var yCoordinates = new HashSet<int>();
            var queries = new List<Query>();
            var toAnswer = new Queue<SumQuery>();
            var answers = new Dictionary<SumQuery, long>();

            for (int i = 0; i < sitesCount; i++)
            {
                var (x, y, d, c) = inputStream.ReadValue<int, int, int, int>();
                yCoordinates.Add(y);
                yCoordinates.Add(y + d + 1);
                queries.Add(new AddQuery(x, y, d, c));
                queries.Add(new AddQuery(x + d + 1, y, d, -c));
            }

            for (int i = 0; i < queriesCount; i++)
            {
                var (a, b) = inputStream.ReadValue<int, int>();
                yCoordinates.Add(b);
                var query = new SumQuery(a, b);
                queries.Add(query);
                toAnswer.Enqueue(query);
            }

            queries.Sort();
            var shrinker = new CoordinateShrinker<int>(yCoordinates);
            var costs = new BinaryIndexedTree(shrinker.Count);

            foreach (var query in queries)
            {
                var shrinkedY = shrinker.Shrink(query.Y);

                if (query is AddQuery addQuery)
                {
                    var shrinkedYPlusD = shrinker.Shrink(addQuery.Y + addQuery.Distance + 1);
                    costs.AddAt(shrinkedY, addQuery.Cost);
                    costs.AddAt(shrinkedYPlusD, -addQuery.Cost);
                }
                else if (query is SumQuery sumQuery)
                {
                    answers.Add(sumQuery, costs.Sum(shrinkedY + 1));
                }
            }

            foreach (var query in toAnswer)
            {
                yield return answers[query];
            }
        }


        abstract class Query : IComparable<Query>, IEquatable<Query>
        {
            public int X { get; }
            public int Y { get; }
            protected bool _isAddQuery;

            protected Query(int x, int y)
            {
                X = x;
                Y = y;
            }

            public int CompareTo([AllowNull] Query other)
            {
                var compared = X.CompareTo(other.X);
                if (compared != 0)
                {
                    return compared;
                }

                return -_isAddQuery.CompareTo(other._isAddQuery);
            }

            public override bool Equals(object obj)
            {
                return Equals(obj as Query);
            }

            public bool Equals(Query other)
            {
                return other != null &&
                       X == other.X &&
                       Y == other.Y &&
                       _isAddQuery == other._isAddQuery;
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(X, Y, _isAddQuery);
            }

            public static bool operator ==(Query left, Query right)
            {
                return EqualityComparer<Query>.Default.Equals(left, right);
            }

            public static bool operator !=(Query left, Query right)
            {
                return !(left == right);
            }
        }

        class AddQuery : Query
        {
            public int Cost { get; }
            public int Distance { get; }

            public AddQuery(int x, int y, int distance, int cost) : base(x, y)
            {
                _isAddQuery = true;
                Cost = cost;
                Distance = distance;
            }
        }

        class SumQuery : Query
        {
            public SumQuery(int x, int y) : base(x, y)
            {
            }
        }

        public class CoordinateShrinker<T> : IEnumerable<(int shrinkedIndex, T rawIndex)> where T : IComparable<T>, IEquatable<T>
        {
            Dictionary<T, int> _shrinkMapper;
            T[] _expandMapper;
            public int Count => _expandMapper.Length;

            public CoordinateShrinker(IEnumerable<T> data)
            {
                _expandMapper = data.Distinct().ToArray();
                Array.Sort(_expandMapper);

                _shrinkMapper = new Dictionary<T, int>();
                for (int i = 0; i < _expandMapper.Length; i++)
                {
                    _shrinkMapper.Add(_expandMapper[i], i);
                }
            }

            public int Shrink(T rawCoordinate) => _shrinkMapper[rawCoordinate];
            public T Expand(int shrinkedCoordinate) => _expandMapper[shrinkedCoordinate];

            public IEnumerator<(int shrinkedIndex, T rawIndex)> GetEnumerator()
            {
                for (int i = 0; i < _expandMapper.Length; i++)
                {
                    yield return (i, _expandMapper[i]);
                }
            }

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
        }

        public class BinaryIndexedTree
        {
            long[] _data;
            public ReadOnlySpan<long> Data => _data[1..];
            public int Length { get; }

            public BinaryIndexedTree(int length)
            {
                _data = new long[length + 1];   // 内部的には1-indexedにする
                Length = length;
            }

            public BinaryIndexedTree(IEnumerable<long> data, int length) : this(length)
            {
                var count = 0;
                foreach (var n in data)
                {
                    AddAt(count++, n);
                }
            }

            public BinaryIndexedTree(ICollection<long> collection) : this(collection, collection.Count) { }

            /// <summary>
            /// BITの<c>index</c>番目の要素に<c>n</c>を加算します。
            /// </summary>
            /// <param name="index">加算するインデックス（0-indexed）</param>
            /// <param name="n">加算する数</param>
            public void AddAt(Index index, long n)
            {
                var i = index.GetOffset(Length) + 1;  // 1-indexedにする
                while (i <= Length)
                {
                    _data[i] += n;
                    i += i & -i;    // LSBの加算
                }
            }

            /// <summary>
            /// [0, <c>end</c>)の部分和を返します。
            /// </summary>
            /// <param name="end">部分和を求める半開区間の終了インデックス</param>
            /// <returns>区間の部分和</returns>
            public long Sum(Index end)
            {
                var i = end.GetOffset(Length);  // 0-indexedの半開区間＝1-indexedの閉区間なので+1は不要
                long sum = 0;
                while (i > 0)
                {
                    sum += _data[i];
                    i -= i & -i;    // LSBの減算
                }
                return sum;
            }

            /// <summary>
            /// <c>range</c>の部分和を返します。
            /// </summary>
            /// <param name="range">部分和を求める半開区間</param>
            /// <returns>区間の部分和</returns>
            public long Sum(Range range) => Sum(range.End) - Sum(range.Start);

            /// <summary>
            /// [<c>start</c>, <c>end</c>)の部分和を返します。
            /// </summary>
            /// <param name="start">部分和を求める半開区間の開始インデックス</param>
            /// <param name="end">部分和を求める半開区間の終了インデックス</param>
            /// <returns>区間の部分和</returns>
            public long Sum(int start, int end) => Sum(end) - Sum(start);

            /// <summary>
            /// [0, <c>index</c>)の部分和が<c>sum</c>未満になる最大の<c>index</c>を返します。
            /// BIT上の各要素は0以上の数である必要があります。
            /// </summary>
            /// <param name="sum"></param>
            /// <returns></returns>
            public int GetLowerBound(long sum)
            {
                int index = 0;
                for (int offset = GetMostSignificantBitOf(Length); offset > 0; offset >>= 1)
                {
                    if (index + offset < _data.Length && _data[index + offset] < sum)
                    {
                        index += offset;
                        sum -= _data[index];
                    }
                }

                return index;

                int GetMostSignificantBitOf(int n)
                {
                    int k = 1;
                    while ((k << 1) <= n)
                    {
                        k <<= 1;
                    };
                    return k;
                }
            }
        }

    }
}
