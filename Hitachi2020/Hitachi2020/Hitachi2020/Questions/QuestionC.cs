using Hitachi2020.Questions;
using Hitachi2020.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Hitachi2020.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        List<int>[] _graph;
        bool[] _colors;

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            _graph = Enumerable.Range(0, n).Select(_ => new List<int>()).ToArray();
            _colors = new bool[n];

            for (int i = 0; i < n - 1; i++)
            {
                var ab = inputStream.ReadIntArray();
                var a = ab[0] - 1;
                var b = ab[1] - 1;
                _graph[a].Add(b);
                _graph[b].Add(a);
            }

            Paint(0, -1, true);

            var reds = Enumerable.Range(0, n).Where(i => _colors[i]).ToArray();
            var blues = Enumerable.Range(0, n).Where(i => !_colors[i]).ToArray();
            var result = new int[n];

            if (reds.Length <= n / 3 || blues.Length <= n / 3)
            {
                var many = reds.Length <= n / 3 ? blues : reds;
                var few = reds.Length <= n / 3 ? reds : blues;

                // mod 0埋め
                var cursor = 0;
                for (int i = 1; i * 3 <= n; i++)
                {
                    if (cursor >= few.Length)
                    {
                        break;
                    }
                    result[few[cursor++]] = i * 3;
                }

                cursor = 0;
                for (int i = result[few[few.Length - 1]] / 3 + 1; i * 3 <= n; i++)
                {
                    result[many[cursor++]] = i * 3;
                }

                for (int i = 0; i * 3 + 1 <= n; i++)
                {
                    result[many[cursor++]] = i * 3 + 1;
                }

                for (int i = 0; i * 3 + 2 <= n; i++)
                {
                    result[many[cursor++]] = i * 3 + 2;
                }
            }
            else
            {
                var redCursor = 0;
                for (int i = 0; i * 3 + 1 <= n; i++)
                {
                    result[reds[redCursor++]] = i * 3 + 1;
                }

                var blueCursor = 0;
                for (int i = 0; i * 3 + 2 <= n; i++)
                {
                    result[blues[blueCursor++]] = i * 3 + 2;
                }

                for (int i = 1; i * 3 <= n; i++)
                {
                    if (redCursor < reds.Length)
                    {
                        result[reds[redCursor++]] = i * 3;
                    }
                    else
                    {
                        result[blues[blueCursor++]] = i * 3;
                    }
                }
            }

            yield return string.Join(" ", result);
        }

        void Paint(int current, int prev, bool color)
        {
            _colors[current] = color;

            foreach (var next in _graph[current])
            {
                if (next == prev)
                {
                    continue;
                }

                Paint(next, current, !color);
            }
        }
    }
}
