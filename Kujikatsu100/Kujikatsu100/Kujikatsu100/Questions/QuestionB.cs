using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu100.Algorithms;
using Kujikatsu100.Collections;
using Kujikatsu100.Numerics;
using Kujikatsu100.Questions;

namespace Kujikatsu100.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc075/tasks/abc075_b
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            Span<(int dr, int dc)> diffs = stackalloc (int, int)[] { (-1, -1), (-1, 0), (-1, 1), (0, -1), (0, 1), (1, -1), (1, 0), (1, 1) };

            var height = io.ReadInt();
            var width = io.ReadInt();
            var map = new char[height][];

            for (int i = 0; i < map.Length; i++)
            {
                map[i] = io.ReadString().ToCharArray();
            }

            var result = new char[height, width];

            for (int row = 0; row < height; row++)
            {
                for (int column = 0; column < width; column++)
                {
                    if (map[row][column] == '#')
                    {
                        result[row, column] = '#';
                    }
                    else
                    {
                        var count = 0;
                        foreach (var (dr, dc) in diffs)
                        {
                            var r = row + dr;
                            var c = column + dc;

                            if (unchecked((uint)r < height && (uint) c < width) && map[r][c] == '#')
                            {
                                count++;
                            }
                        }
                        result[row, column] = (char)(count + '0');
                    }
                }
            }

            for (int row = 0; row < height; row++)
            {
                var s = "";
                for (int column = 0; column < width; column++)
                {
                    s += result[row, column];
                }
                io.WriteLine(s);
            }
        }
    }
}
