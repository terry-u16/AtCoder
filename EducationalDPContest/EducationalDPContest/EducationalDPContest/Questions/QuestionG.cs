using EducationalDPContest.Questions;
using EducationalDPContest.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EducationalDPContest.Questions
{
    public class QuestionG : AtCoderQuestionBase
    {
        List<int>[] graph;
        int[] dpLength;

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nm = inputStream.ReadIntArray();
            var n = nm[0];
            var m = nm[1];
            graph = new List<int>[n];

            for (int i = 0; i < n; i++)
            {
                graph[i] = new List<int>();
            }

            dpLength = Enumerable.Repeat(int.MinValue, n).ToArray();

            for (int i = 0; i < m; i++)
            {
                var xy = inputStream.ReadIntArray();
                graph[xy[0] - 1].Add(xy[1] - 1);
            }

            var longestLength = 0;
            for (int i = 0; i < n; i++)
            {
                UpdateWhenLarge(ref longestLength, Search(i));
            }

            yield return longestLength;
        }

        int Search(int nodeIndex)
        {
            if (dpLength[nodeIndex] >= 0)
            {
                return dpLength[nodeIndex];
            }

            int longestLength = 0;
            foreach (var nextNodeIndex in graph[nodeIndex])
            {
                UpdateWhenLarge(ref longestLength, Search(nextNodeIndex) + 1);
            }
            return dpLength[nodeIndex] = longestLength;
        }
    }
}
