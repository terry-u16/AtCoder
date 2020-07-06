using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200706.Algorithms;
using Training20200706.Collections;
using Training20200706.Extensions;
using Training20200706.Numerics;
using Training20200706.Questions;

namespace Training20200706.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        int width;
        int height;
        bool[,] seen;
        bool[][] canEnter;
        (int dr, int dc)[] delta = new (int dr, int dc)[] { (-1, 0), (1, 0), (0, -1), (0, 1) };

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            width = inputStream.ReadInt();
            height = inputStream.ReadInt();
            canEnter = new bool[height][];
            for (int row = 0; row < height; row++)
            {
                canEnter[row] = inputStream.ReadIntArray().Select(i => i == 1).ToArray();
            }

            seen = new bool[height, width];

            var max = 0;
            for (int row = 0; row < height; row++)
            {
                for (int column = 0; column < width; column++)
                {
                    if (canEnter[row][column])
                    {
                        max = Math.Max(max, Dfs(row, column, 1));
                    }
                }
            }

            yield return max;
        }

        int Dfs(int currentRow, int currentColumn, int depth)
        {
            var max = depth;
            seen[currentRow, currentColumn] = true;

            foreach (var (dr, dc) in delta)
            {
                var nextRow = currentRow + dr;
                var nextColumn = currentColumn + dc;
                if (unchecked((uint)nextRow) < height && unchecked((uint)nextColumn) < width && !seen[nextRow, nextColumn] && canEnter[nextRow][nextColumn])
                {
                    max = Math.Max(max, Dfs(nextRow, nextColumn, depth + 1));
                }
            }

            seen[currentRow, currentColumn] = false;
            return max;
        }
    }
}
