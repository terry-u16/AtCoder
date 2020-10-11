using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using KUPC2020.Algorithms;
using KUPC2020.Collections;
using KUPC2020.Numerics;
using KUPC2020.Questions;

namespace KUPC2020.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            Modular.Mod = 1000000007;
            var n = io.ReadInt();
            var k = io.ReadInt();

            var numbers = new int[n][];
            var all = new int[n * k + 1];   // include 0

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = io.ReadIntArray(k);
                numbers[i].AsSpan().CopyTo(all.AsSpan(k * i));
            }

            var shrinker = new CoordinateShrinker<int>(all);

            var last = new BinaryIndexedTree(shrinker.Count);
            last[0] = 1;

            for (int i = 0; i < numbers.Length; i++)
            {
                var current = new BinaryIndexedTree(shrinker.Count);

                foreach (var value in numbers[i])
                {
                    var index = shrinker.Shrink(value);
                    current[index] = last.Sum(index + 1);
                }

                last = current;
            }

            io.WriteLine(last.Sum(last.Length));
        }

        public class BinaryIndexedTree
        {
            Modular[] _data;
            public int Length { get; }

            public BinaryIndexedTree(int length)
            {
                _data = new Modular[length + 1];   // 内部的には1-indexedにする
                Length = length;
            }

            public BinaryIndexedTree(IEnumerable<Modular> data, int length) : this(length)
            {
                var count = 0;
                foreach (var n in data)
                {
                    AddAt(count++, n);
                }
            }

            public BinaryIndexedTree(ICollection<Modular> collection) : this(collection, collection.Count) { }

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
