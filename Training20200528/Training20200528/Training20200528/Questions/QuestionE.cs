using Training20200528.Questions;
using Training20200528.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Training20200528.Questions
{
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nm = inputStream.ReadIntArray();
            var s = inputStream.ReadIntArray();
            var t = inputStream.ReadIntArray();

            var countSum = new BinaryIndexedTree2D(s.Length, t.Length);

            for (int row = 0; row < countSum.Height; row++)
            {
                for (int column = 0; column < countSum.Width; column++)
                {
                    if (s[row] == t[column])
                    {
                        countSum.AddAt(row, column, countSum.Sum(row, column) + 1);
                    }
                }
            }

            yield return (countSum.Sum(countSum.Height, countSum.Width) + 1) % 1000000007;
        }

        public class BinaryIndexedTree2D
        {
            long[,] _data;
            public int Height { get; }
            public int Width { get; }

            public BinaryIndexedTree2D(int height, int width)
            {
                Height = height;
                Width = width;
                _data = new long[height + 1, width + 1];
            }

            /// <summary>
            /// 2次元BITの[<c>row</c>, <c>column</c>]に<c>value</c>を足します。
            /// </summary>
            /// <param name="row">加算する行（0-indexed）</param>
            /// <param name="column">加算する列（0-indexed）</param>
            /// <param name="value">加算する値</param>
            public void AddAt(int row, int column, long value)
            {
                unchecked
                {
                    if ((ulong)row >= (ulong)Height)
                    {
                        throw new ArgumentOutOfRangeException(nameof(row));
                    }
                    if ((ulong)column >= (ulong)Width)
                    {
                        throw new ArgumentOutOfRangeException(nameof(column));
                    }
                }

                row++;    // 1-indexed
                column++;

                for (int i = row; i <= Height; i += i & -i)
                {
                    for (int j = column; j <= Width; j += j & -j)
                    {
                        _data[i, j] += value;
                        if (_data[i, j] >= 1000000007)
                        {
                            _data[i, j] -= 1000000007;
                        }
                    }
                }
            }

            /// <summary>
            /// 指定した半開区間の部分和を返します。
            /// </summary>
            /// <param name="row"></param>
            /// <param name="column"></param>
            /// <returns></returns>
            public long Sum(int row, int column)
            {
                long sum = 0;
                unchecked
                {
                    if ((ulong)row >= (ulong)(Height + 1))
                    {
                        throw new ArgumentOutOfRangeException(nameof(row));
                    }
                    if ((ulong)column >= (ulong)(Width + 1))
                    {
                        throw new ArgumentOutOfRangeException(nameof(column));
                    }
                }

                for (int i = row; i > 0; i -= i & -i)
                {
                    for (int j = column; j > 0; j -= j & -j)
                    {
                        sum += _data[i, j];
                    }
                }
                return sum % 1000000007;
            }
        }
    }
}
