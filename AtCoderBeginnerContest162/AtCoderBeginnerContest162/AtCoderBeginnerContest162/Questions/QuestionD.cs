using AtCoderBeginnerContest162.Algorithms;
using AtCoderBeginnerContest162.Collections;
using AtCoderBeginnerContest162.Questions;
using AtCoderBeginnerContest162.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest162.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var s = inputStream.ReadLine();

            var rIndex = GetIndexOf(s, 'R');
            var gIndex = GetIndexOf(s, 'G');
            var bIndex = GetIndexOf(s, 'B');

            var all = (long)rIndex.Length * gIndex.Length * bIndex.Length;

            var sameDistance = 0;
            sameDistance += GetSameDistanceCount(rIndex, gIndex, bIndex, s.Length);
            sameDistance += GetSameDistanceCount(gIndex, bIndex, rIndex, s.Length);
            sameDistance += GetSameDistanceCount(bIndex, rIndex, gIndex, s.Length);

            yield return all - sameDistance;
        }

        Span<int> GetIndexOf(string s, char c)
        {
            var list = new List<int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == c)
                {
                    list.Add(i);
                }
            }
            return list.ToArray().AsSpan();
        }

        int GetSameDistanceCount(Span<int> center, Span<int> indexA, Span<int> indexB, int sLength)
        {
            int count = 0;
            foreach (var centerIndex in center)
            {
                var upper = Math.Min(centerIndex, sLength - centerIndex - 1);
                for (int distance = 1; distance <= upper; distance++)
                {
                    var small = centerIndex - distance;
                    var large = centerIndex + distance;
                    if (indexA.BinarySearch(small) >= 0 && indexB.BinarySearch(large) >= 0)
                    {
                        count++;
                    }
                    else if (indexB.BinarySearch(small) >= 0 && indexA.BinarySearch(large) >= 0)
                    {
                        count++;
                    }
                }
            }

            return count;
        }
    }
}
