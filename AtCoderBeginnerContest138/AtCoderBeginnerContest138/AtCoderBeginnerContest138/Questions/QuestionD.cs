using AtCoderBeginnerContest138.Questions;
using AtCoderBeginnerContest138.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest138.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        List<int>[] connectedNodes;
        int[] counts;

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nq = inputStream.ReadIntArray();
            var n = nq[0];
            var q = nq[1];

            connectedNodes = Enumerable.Range(0, n).Select(_ => new List<int>()).ToArray();
            counts = new int[n];

            for (int i = 0; i < n - 1; i++)
            {
                var ab = inputStream.ReadIntArray();
                var a = ab[0] - 1;
                var b = ab[1] - 1;
                connectedNodes[a].Add(b);
                connectedNodes[b].Add(a);
            }

            for (int i = 0; i < q; i++)
            {
                var px = inputStream.ReadIntArray();
                var p = px[0] - 1;
                var x = px[1];
                counts[p] += x;
            }

            IncrementCountsOfSubtree(0, -1);

            yield return string.Join(" ", counts);
        }


        void IncrementCountsOfSubtree(int root, int parent)
        {
            foreach (var child in connectedNodes[root])
            {
                if (child != parent)
                {
                    counts[child] += counts[root];
                    IncrementCountsOfSubtree(child, root);
                }
            }
        }
    }
}
