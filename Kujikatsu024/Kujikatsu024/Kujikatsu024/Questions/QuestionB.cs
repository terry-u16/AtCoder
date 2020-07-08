using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu024.Algorithms;
using Kujikatsu024.Collections;
using Kujikatsu024.Extensions;
using Kujikatsu024.Numerics;
using Kujikatsu024.Questions;

namespace Kujikatsu024.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc096/tasks/abc096_c
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (h, w) = inputStream.ReadValue<int, int>();
            var s = new char[h][];
            for (int r = 0; r < h; r++)
            {
                s[r] = inputStream.ReadLine().ToCharArray();
            }

            yield return Check(h, w, s) ? "Yes" : "No";
        }

        bool Check(int h, int w, char[][] s)
        {
            Span<(int dr, int dc)> diffs = stackalloc[] { (-1, 0), (1, 0), (0, -1), (0, 1) };
            for (int row = 0; row < s.Length; row++)
            {
                for (int column = 0; column < s[row].Length; column++)
                {
                    if (s[row][column] == '#')
                    {
                        var ok = false;
                        foreach (var (dr, dc) in diffs)
                        {
                            var r = row + dr;
                            var c = column + dc;
                            if (unchecked((uint)r) < h && unchecked((uint)c) < w && s[r][c] == '#')
                            {
                                ok = true;
                            }
                        }
                        if (!ok)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
    }
}
