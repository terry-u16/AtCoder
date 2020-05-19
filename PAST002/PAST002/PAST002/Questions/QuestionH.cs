using PAST002.Algorithms;
using PAST002.Collections;
using PAST002.Questions;
using PAST002.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PAST002.Questions
{
    public class QuestionH : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (h, w) = inputStream.ReadValue<int, int>();
            var panels = InitializeMap(inputStream, h, w);
            var start = panels[0][0];
            var goal = panels[10][0];

            const int Inf = 1 << 28;
            var counts = new int[h, w, 11].SetAll((i, j, k) => Inf);
            counts[start.row, start.column, 0] = 0;

            if (panels.Any(l => l.Count == 0))
            {
                yield return -1;
                yield break;
            }

            for (int current = 0; current < 10; current++)
            {
                foreach (var begin in panels[current])
                {
                    foreach (var end in panels[current + 1])
                    {
                        var distance = Math.Abs(begin.row - end.row) + Math.Abs(begin.column - end.column);
                        AlgorithmHelpers.UpdateWhenSmall(ref counts[end.row, end.column, current + 1], counts[begin.row, begin.column, current] + distance);
                    }
                }
            }

            yield return counts[goal.row, goal.column, 10];
        }

        private static List<(int row, int column)>[] InitializeMap(TextReader inputStream, int h, int w)
        {
            var panels = Enumerable.Repeat(0, 11).Select(_ => new List<(int row, int column)>()).ToArray();
            for (int row = 0; row < h; row++)
            {
                var s = inputStream.ReadLine();
                for (int column = 0; column < w; column++)
                {
                    var c = s[column];
                    if (c == 'S')
                    {
                        panels[0].Add((row, column));
                    }
                    else if (c == 'G')
                    {
                        panels[10].Add((row, column));
                    }
                    else
                    {
                        panels[c - '0'].Add((row, column));
                    }
                }
            }

            return panels;
        }
    }
}
