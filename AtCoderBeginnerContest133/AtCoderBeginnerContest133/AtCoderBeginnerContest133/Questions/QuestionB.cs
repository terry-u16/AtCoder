using AtCoderBeginnerContest133.Questions;
using AtCoderBeginnerContest133.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest133.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nd = inputStream.ReadIntArray();
            var n = nd[0];
            var d = nd[1];
            var x = new int[n][];

            for (int i = 0; i < n; i++)
            {
                x[i] = inputStream.ReadIntArray();
            }

            var count = 0;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    var distanceSquared = 0;
                    for (int dimension = 0; dimension < d; dimension++)
                    {
                        distanceSquared += (x[i][dimension] - x[j][dimension]) * (x[i][dimension] - x[j][dimension]);
                    }

                    if (IsSquared(distanceSquared))
                    {
                        count++;
                    }
                }
            }

            yield return count;
        }

        bool IsSquared(int n)
        {
            var sqrt = (int)Math.Sqrt(n);
            return (sqrt * sqrt) == n || ((sqrt + 1) * (sqrt + 1)) == n;
        }
    }
}
