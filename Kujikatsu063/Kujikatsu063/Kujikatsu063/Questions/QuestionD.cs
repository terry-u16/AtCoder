using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu063.Algorithms;
using Kujikatsu063.Collections;
using Kujikatsu063.Extensions;
using Kujikatsu063.Numerics;
using Kujikatsu063.Questions;

namespace Kujikatsu063.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/ddcc2020-qual/tasks/ddcc2020_qual_c
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (height, width, k) = inputStream.ReadValue<int, int, int>();
            var cake = new char[height][];

            for (int i = 0; i < cake.Length; i++)
            {
                cake[i] = inputStream.ReadLine().ToCharArray();
            }

            var result = Enumerable.Repeat(0, height).Select(_ => new int[width]).ToArray();

            var square = 0;
            for (int i = 1; i <= k; i++)
            {
                while (true)
                {
                    var row = square / width;
                    var column = square % width;
                    square++;
                    if (cake[row][column] == '#')
                    {
                        result[row][column] = i;
                        break;
                    }
                }
            }

            for (int row = 0; row < height; row++)
            {
                for (int column = 0; column + 1 < width; column++)
                {
                    if (result[row][column + 1] == 0)
                    {
                        result[row][column + 1] = result[row][column];
                    }
                }
            }

            for (int row = 0; row < height; row++)
            {
                for (int column = width - 1; column > 0; column--)
                {
                    if (result[row][column - 1] == 0)
                    {
                        result[row][column - 1] = result[row][column];
                    }
                }
            }

            for (int column = 0; column < width; column++)
            {
                for (int row = 0; row + 1 < height; row++)
                {
                    if (result[row + 1][column] == 0)
                    {
                        result[row + 1][column] = result[row][column];
                    }
                }
            }

            for (int column = 0; column < width; column++)
            {
                for (int row = height - 1; row > 0; row--)
                {
                    if (result[row - 1][column] == 0)
                    {
                        result[row - 1][column] = result[row][column];
                    }
                }
            }

            for (int row = 0; row < result.Length; row++)
            {
                yield return result[row].Join(' ');
            }
        }
    }
}
