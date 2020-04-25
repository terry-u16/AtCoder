using AtCoderBeginnerContest138.Questions;
using AtCoderBeginnerContest138.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest138.Questions
{
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();
            var t = inputStream.ReadLine();

            var charCounts = new Dictionary<char, List<int>>();

            for (int i = 0; i < s.Length; i++)
            {
                var c = s[i];
                if (!charCounts.ContainsKey(c))
                {
                    charCounts.Add(c, new List<int> { i });
                }
                else
                {
                    charCounts[c].Add(i);
                }
            }

            long index = -1;
            foreach (var c in t)
            {
                var localIndex = (int)(index % s.Length);
                var nextIndex = NextIndexOf(charCounts, c, localIndex);
                if (nextIndex == null)
                {
                    yield return -1;
                    yield break;
                }
                else
                {
                    var progress = nextIndex.Value > localIndex ? nextIndex.Value - localIndex : (nextIndex.Value + s.Length) - localIndex;
                    index += progress;
                }
            }

            yield return index + 1;
        }

        int? NextIndexOf(Dictionary<char, List<int>> charCounts, char c, int index)
        {
            if (!charCounts.ContainsKey(c))
            {
                return null;
            }
            var counts = charCounts[c];

            var availableIndex = BoundaryBinarySearch(counts, i => i > index, -1, counts.Count);

            if (availableIndex < counts.Count)
            {
                return counts[availableIndex];
            }
            else
            {
                return counts[0];
            }
        }

        private static int BoundaryBinarySearch<T>(IList<T> list, Predicate<T> predicate, int ng, int ok)
        {
            // めぐる式二分探索
            // Span.BinarySearchだとできそうでできない（lower_boundがダメ）
            while (Math.Abs(ok - ng) > 1)
            {
                int mid = (ok + ng) / 2;

                if (predicate(list[mid]))
                {
                    ok = mid;
                }
                else
                {
                    ng = mid;
                }
            }
            return ok;
        }

    }
}
