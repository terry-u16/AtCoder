using Training20200612.Questions;
using Training20200612.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Training20200612.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/arc017/tasks/arc017_3
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nx = inputStream.ReadIntArray();
            var n = nx[0];
            var capacity = nx[1];
            var weights1 = new int[n / 2];
            var weights2 = new int[n - weights1.Length];
            for (int i = 0; i < weights1.Length; i++)
            {
                weights1[i] = inputStream.ReadInt();
            }
            for (int i = 0; i < weights2.Length; i++)
            {
                weights2[i] = inputStream.ReadInt();
            }

            var counts1 = Count(weights1);
            var counts2 = Count(weights2);

            var count = 0;
            foreach (var c in counts1)
            {
                var remain = capacity - c.Key;
                if (counts2.ContainsKey(remain))
                {
                    count += c.Value * counts2[remain];
                }
            }

            yield return count;
        }

        Dictionary<int, int> Count(int[] weights)
        {
            var counts = new Dictionary<int, int>();
            counts.Add(0, 1);

            foreach (var weight in weights)
            {
                var toAdds = new Dictionary<int, int>();
                foreach (var count in counts)
                {
                    toAdds.Add(count.Key + weight, count.Value);
                }
                foreach (var toAdd in toAdds)
                {
                    if (counts.ContainsKey(toAdd.Key))
                    {
                        counts[toAdd.Key] += toAdd.Value;
                    }
                    else
                    {
                        counts[toAdd.Key] = toAdd.Value;
                    }
                }
            }

            return counts;
        }
    }
}
