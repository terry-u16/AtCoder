using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu038.Algorithms;
using Kujikatsu038.Collections;
using Kujikatsu038.Extensions;
using Kujikatsu038.Numerics;
using Kujikatsu038.Questions;

namespace Kujikatsu038.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/ddcc2020-qual/tasks/ddcc2020_qual_c
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (height, width, strawberries) = inputStream.ReadValue<int, int, int>();

            var cake = new char[height][];
            for (int i = 0; i < cake.Length; i++)
            {
                cake[i] = inputStream.ReadLine().ToCharArray();
            }

            var result = Enumerable.Repeat(0, height).Select(_ => new int[width]).ToArray();
            var number = 1;

            for (int row = 0; row < cake.Length; row++)
            {
                for (int column = 0; column < width; column++)
                {
                    if (cake[row][column] == '#')
                    {
                        result[row][column] = number++;
                    }
                }
            }


            for (int row = 0; row < result.Length; row++)
            {
                for (int column = 1; column < width; column++)
                {
                    if (result[row][column] == 0)
                    {
                        result[row][column] = result[row][column - 1];
                    }
                }

                for (int column = width - 2; column >= 0; column--)
                {
                    if (result[row][column] == 0)
                    {
                        result[row][column] = result[row][column + 1];
                    }
                }
            }

            for (int row = 1; row < result.Length; row++)
            {
                if (result[row][0] == 0)
                {
                    result[row] = result[row - 1];
                }
            }

            for (int row = result.Length - 2; row >= 0; row--)
            {
                if (result[row][0] == 0)
                {
                    result[row] = result[row + 1];
                }
            }

            for (int row = 0; row < result.Length; row++)
            {
                yield return result[row].Join(' ');
            }
        }
    }
}
