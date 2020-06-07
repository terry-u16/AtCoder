using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AtCoderGrandContest045.Algorithms;
using AtCoderGrandContest045.Collections;
using AtCoderGrandContest045.Extensions;
using AtCoderGrandContest045.Numerics;
using AtCoderGrandContest045.Questions;

namespace AtCoderGrandContest045.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();

            for (int t = 0; t < tests; t++)
            {
                var n = inputStream.ReadInt();
                var a = inputStream.ReadLongArray();
                var s = inputStream.ReadLine();

                const int maxRow = 62;
                var isOne = new bool[n];
                var matrix = new int[maxRow, n];
                var index = 0;

                for (int i = a.Length - 1; i >= 0; i--)
                {
                    var v = a[i];
                    if (s[i] == '0')
                    {
                        for (int digit = 0; digit < maxRow; digit++)
                        {
                            matrix[digit, index] = (int)(v >> digit) & 1;
                        }
                        isOne[index] = false;
                    }
                    else
                    {
                        for (int digit = 0; digit < maxRow; digit++)
                        {
                            matrix[digit, index] = (int)(v >> digit) & 1;
                        }
                        isOne[index] = true;
                    }
                    index++;
                }

                yield return GaussJordan(matrix, isOne) ? 0 : 1;
            }
        }

        bool GaussJordan(int[,] matrix, bool[] isOne)
        {
            int rank = 0;
            var maxRow = matrix.GetLength(0);
            var maxColumn = matrix.GetLength(1);
            for (int column = 0; column < maxColumn; column++)
            {
                int pivot = -1;
                for (int row = rank; row < maxRow; row++)
                {
                    if (matrix[row, column] > 0)
                    {
                        pivot = row;
                        break;
                    }
                }

                if (pivot == -1)
                {
                    continue;
                }
                else if (isOne[column])
                {
                    return false;
                }

                for (int col = 0; col < maxColumn; col++)
                {
                    Swap(ref matrix[pivot, col], ref matrix[rank, col]);
                }

                for (int row = 0; row < maxRow; row++)
                {
                    if (row != rank && matrix[row, column] > 0)
                    {
                        for (int col = 0; col < maxColumn; col++)
                        {
                            matrix[row, col] ^= matrix[rank, col];
                        }
                    }
                }

                rank++;
            }

            return true;
        }

        static void Swap<T>(ref T value1, ref T value2)
        {
            var temp = value1;
            value1 = value2;
            value2 = temp;
        }

        static bool GetAt(int digit, long value) => ((value >> digit) & 1) > 0;
    }
}
