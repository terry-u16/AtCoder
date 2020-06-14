using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AtCoderBeginnerContest170.Algorithms;
using AtCoderBeginnerContest170.Collections;
using AtCoderBeginnerContest170.Extensions;
using AtCoderBeginnerContest170.Numerics;
using AtCoderBeginnerContest170.Questions;

namespace AtCoderBeginnerContest170.Questions
{
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, queries) = inputStream.ReadValue<int, int>();

            var sortedSets = Enumerable.Range(0, 200_000).Select(_ => new SortedSet<int>()).ToArray();
            var infants = new Infant[n];

            for (int i = 0; i < n; i++)
            {
                var (a, b) = inputStream.ReadValue<int, int>();
                b--;
                sortedSets[b].Add(a);
                infants[i] = new Infant(a, b);
            }

            var segmentTree = new SegmentTree<MinInt>(sortedSets.Select(s => new MinInt(s.Count > 0 ? s.Max : int.MaxValue)).ToArray());

            for (int q = 0; q < queries; q++)
            {
                var (c, d) = inputStream.ReadValue<int, int>();
                c--;
                d--;
                var infant = infants[c];
                sortedSets[infant.Youchien].Remove(infant.Rating);

                if (sortedSets[infant.Youchien].Count == 0)
                {
                    segmentTree[infant.Youchien] = new MinInt(int.MaxValue);
                }
                else if (sortedSets[infant.Youchien].Max != infant.Rating)
                {
                    segmentTree[infant.Youchien] = new MinInt(sortedSets[infant.Youchien].Max);
                }

                infant.Youchien = d;
                if (sortedSets[infant.Youchien].Count == 0 || sortedSets[infant.Youchien].Max < infant.Rating)
                {
                    segmentTree[infant.Youchien] = new MinInt(infant.Rating);
                }
                sortedSets[infant.Youchien].Add(infant.Rating);

                yield return segmentTree.Query(..).Value;
            }
        }

        class Infant
        {
            public int Rating { get; }
            public int Youchien { get; set; }

            public Infant(int rating, int youchien)
            {
                Rating = rating;
                Youchien = youchien;
            }
        }

        struct MinInt : IMonoid<MinInt>
        {
            public MinInt Identity => new MinInt(int.MaxValue);
            public int Value { get; }

            public MinInt(int value)
            {
                Value = value;
            }

            public MinInt Multiply(MinInt other) => new MinInt(Math.Min(Value, other.Value));
        }
    }
}
