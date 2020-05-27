using Training20200527.Questions;
using Training20200527.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Training20200527.Questions
{
    /// <summary>
    /// AGC009 B
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        List<int>[] _edges;

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            _edges = Enumerable.Range(0, n + 1).Select(_ => new List<int>()).ToArray();

            for (int loser = 2; loser <= n; loser++)
            {
                var winner = inputStream.ReadInt();
                _edges[winner].Add(loser);
            }

            yield return GetMinimumBattles(1) - 1;
        }

        int GetMinimumBattles(int start)
        {
            var going = new Stack<int>();
            var back = new Stack<int>();
            going.Push(start);
            back.Push(start);

            while (going.Count > 0)
            {
                var current = going.Pop();
                foreach (var next in _edges[current])
                {
                    going.Push(next);
                    back.Push(next);
                }
            }

            var results = new int[_edges.Length];
            while (back.Count > 0)
            {
                var current = back.Pop();
                if (_edges[current].Count == 0)
                {
                    results[current] = 1;
                }
                else
                {
                    var battleCounts = new int[_edges[current].Count];
                    for (int i = 0; i < _edges[current].Count; i++)
                    {
                        battleCounts[i] = results[_edges[current][i]];
                    }
                    Array.Sort(battleCounts);

                    var max = 0;
                    var additional = battleCounts.Length;
                    foreach (var battleCount in battleCounts)
                    {
                        max = Math.Max(max, battleCount + additional--);
                    }

                    results[current] = max;
                }
            }

            return results[start];
        }
    }
}
