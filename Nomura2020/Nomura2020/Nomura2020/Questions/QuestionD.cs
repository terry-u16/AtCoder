using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Nomura2020.Algorithms;
using Nomura2020.Collections;
using Nomura2020.Extensions;
using Nomura2020.Numerics;
using Nomura2020.Questions;

namespace Nomura2020.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var townsCount = inputStream.ReadInt();
            var plan = inputStream.ReadIntArray().Select(i => i - 1).ToArray();

            int baseRoads = 0;
            var unionFind = new UnionFindTree(townsCount);
            for (int town = 0; town < plan.Length; town++)
            {
                if (plan[town] >= 0 && !unionFind.IsInSameGroup(town, plan[town]))
                {
                    unionFind.Unite(town, plan[town]);
                    baseRoads++;
                }
            }

            var parents = new int[townsCount];
            for (int i = 0; i < parents.Length; i++)
            {
                parents[i] = unionFind.GetRootOf(i);
            }

            var roots = parents.Distinct().ToArray();
            var dictionary = new Dictionary<int, int>();
            foreach (var group in parents.GroupBy(i => i))
            {
                dictionary[group.Key] = group.Count();
            }

            for (int i = 0; i < roots.Length; i++)
            {
                for (int j = i + 1; j < roots.Length; j++)
                {

                }
            }
        }
    }
}
