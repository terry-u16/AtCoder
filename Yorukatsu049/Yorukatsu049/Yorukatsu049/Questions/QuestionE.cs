using Yorukatsu049.Questions;
using Yorukatsu049.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu049.Questions
{
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();
            var t = inputStream.ReadLine();

            if (!new HashSet<char>(s).IsSupersetOf(t))
            {
                yield return -1;
                yield break;
            }

            var doubleS = s + s;
            var counts = Enumerable.Range(0, 26).Select(_ => new BinaryIndexedTree(doubleS.Length)).ToArray();
            for (int i = 0; i < doubleS.Length; i++)
            {
                counts[doubleS[i] - 'a'].AddAt(i, 1);
            }

            long cursor = 0;
            foreach (var c in t)
            {
                var targetBit = counts[c - 'a'];
                var nextIndex = targetBit.GetLowerBound(targetBit.Sum((int)(cursor % s.Length)) + 1) + 1;
                cursor += nextIndex - cursor % s.Length;
            }

            yield return cursor;
        }

        public class BinaryIndexedTree
        {
            long[] _data;
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
            /// <param name="value">加算する数</param>
            public void AddAt(int i, long value)
            {
                unchecked
                {
                    if ((uint)i >= (uint)Length)
                    {
                        throw new ArgumentOutOfRangeException(nameof(i));
                    }
                }

                i++;  // 1-indexedにする

                while (i <= Length)
                {
                    _data[i] += value;
                    i += i & -i;    // LSBの加算
                }
            }

            /// <summary>
            /// [0, <c>end</c>)の部分和を返します。
            /// </summary>
            /// <param name="end">部分和を求める半開区間の終了インデックス</param>
            /// <returns>区間の部分和</returns>
            public long Sum(int i)
            {
                unchecked
                {
                    if ((uint)i >= (uint)_data.Length)
                    {
                        throw new ArgumentOutOfRangeException(nameof(i));
                    }
                }

                long sum = 0;
                while (i > 0)
                {
                    sum += _data[i];
                    i -= i & -i;    // LSBの減算
                }
                return sum;
            }

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
            }

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
