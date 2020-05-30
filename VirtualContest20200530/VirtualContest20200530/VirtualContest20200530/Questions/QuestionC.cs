using VirtualContest20200530.Questions;
using VirtualContest20200530.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace VirtualContest20200530.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/mujin-pc-2018/tasks/mujin_pc_2018_c
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nm = inputStream.ReadIntArray();
            var height = nm[0];
            var width = nm[1];

            var map = new char[height][];

            for (int i = 0; i < height; i++)
            {
                map[i] = inputStream.ReadLine().ToCharArray();
            }

            var left = new int[height, width];
            var right = new int[height, width];
            var up = new int[height, width];
            var down = new int[height, width];

            for (int row = 0; row < height; row++)
            {
                var leftSum = 0;
                for (int column = 0; column < width; column++)
                {
                    left[row, column] = leftSum;
                    leftSum = IncrementOrReset(leftSum, map[row][column]);
                }

                var rightSum = 0;
                for (int column = width - 1; column >= 0; column--)
                {
                    right[row, column] = rightSum;
                    rightSum = IncrementOrReset(rightSum, map[row][column]);
                }
            }

            for (int column = 0; column < width; column++)
            {
                var upSum = 0;
                for (int row = 0; row < height; row++)
                {
                    up[row, column] = upSum;
                    upSum = IncrementOrReset(upSum, map[row][column]);
                }

                var downSum = 0;
                for (int row = height - 1; row >= 0; row--)
                {
                    down[row, column] = downSum;
                    downSum = IncrementOrReset(downSum, map[row][column]);
                }
            }

            long total = 0;
            for (int row = 0; row < height; row++)
            {
                for (int column = 0; column < width; column++)
                {
                    if (map[row][column] == '.')
                    {
                        var u = up[row, column];
                        var d = down[row, column];
                        var l = left[row, column];
                        var r = right[row, column];

                        total += u * r;
                        total += r * d;
                        total += d * l;
                        total += l * u;
                    }
                }
            }

            yield return total;
        }

        int IncrementOrReset(int count, char c)
        {
            if (c == '.')
            {
                return count + 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
