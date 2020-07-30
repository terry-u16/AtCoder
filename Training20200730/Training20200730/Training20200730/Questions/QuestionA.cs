using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200730.Algorithms;
using Training20200730.Collections;
using Training20200730.Extensions;
using Training20200730.Numerics;
using Training20200730.Questions;

namespace Training20200730.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/agc009/tasks/agc009_c
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, a, b) = inputStream.ReadValue<int, long, long>();
            var s = new long[n];
            for (int i = 0; i < s.Length; i++)
            {
                s[i] = inputStream.ReadLong();
            }

            var aSet = new BinaryIndexedTreeModInt(n);
            var bSet = new BinaryIndexedTreeModInt(n);
            aSet[0] = 1;
            bSet[0] = 1;

            for (int i = 1; i < s.Length; i++)
            {
                var si = s[i];
                var cantSelectA = aSet.Sum(SearchExtensions.GetGreaterThanIndex(s, si - a)..i);
                var cantSelectB = bSet.Sum(SearchExtensions.GetGreaterThanIndex(s, si - b)..i);
                aSet[i] = aSet[i - 1] + bSet[i - 1] - cantSelectA;
                bSet[i] = aSet[i - 1] + bSet[i - 1] - cantSelectB;
            }

            yield return aSet[^1] + bSet[^1];
        }

        public class BinaryIndexedTreeModInt
        {
            Modular[] _data;
            public int Length { get; }

            public BinaryIndexedTreeModInt(int length)
            {
                _data = new Modular[length + 1];   // 内部的には1-indexedにする
                Length = length;
            }

            public Modular this[Index index]
            {
                get => Sum(index..(index.GetOffset(Length) + 1));
                set
                {
                    if (value < 0)
                    {
                        throw new ArgumentOutOfRangeException(nameof(value), $"{nameof(value)}は0以上の値である必要があります。");
                    }
                    AddAt(index, value - this[index]);
                }
            }

            /// <summary>
            /// BITの<c>index</c>番目の要素に<c>n</c>を加算します。
            /// </summary>
            /// <param name="index">加算するインデックス（0-indexed）</param>
            /// <param name="value">加算する数</param>
            public void AddAt(Index index, Modular value)
            {
                var i = index.GetOffset(Length);
                unchecked
                {
                    if ((uint)i >= (uint)Length)
                    {
                        throw new ArgumentOutOfRangeException(nameof(index));
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
            public Modular Sum(Index end)
            {
                var i = end.GetOffset(Length);  // 0-indexedの半開区間＝1-indexedの閉区間なので+1は不要
                unchecked
                {
                    if ((uint)i >= (uint)_data.Length)
                    {
                        throw new ArgumentOutOfRangeException(nameof(end));
                    }
                }

                Modular sum = 0;
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
            public Modular Sum(Range range) => Sum(range.End) - Sum(range.Start);

            /// <summary>
            /// [<c>start</c>, <c>end</c>)の部分和を返します。
            /// </summary>
            /// <param name="start">部分和を求める半開区間の開始インデックス</param>
            /// <param name="end">部分和を求める半開区間の終了インデックス</param>
            /// <returns>区間の部分和</returns>
            public Modular Sum(int start, int end) => Sum(end) - Sum(start);
        }
    }
}
