using Yorukatsu025.Questions;
using Yorukatsu025.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu025.Questions
{
    /// <summary>
    /// ABC114 D
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();

            var primeCounts = new int[101];

            for (int i = 2; i <= n; i++)
            {
                foreach (var prime in PrimeFactorization(i))
                {
                    primeCounts[prime]++;
                }
            }

            var count = 0;
            
            // a^4*b^4*c^2のパターン
            for (int i = 1; i <= 99; i++)
            {
                for (int j = i + 1; j <= 100; j++)
                {
                    for (int k = 1; k <= 100; k++)
                    {
                        if (i != k && j != k && primeCounts[i] >= 4 && primeCounts[j] >= 4 && primeCounts[k] >= 2)
                        {
                            count++;
                        }
                    }
                }
            }

            // a^14*b^4のパターン
            for (int i = 1; i <= 100; i++)
            {
                for (int j = 1; j <= 100; j++)
                {
                    if (i != j && primeCounts[i] >= 14 && primeCounts[j] >= 4)
                    {
                        count++;
                    }
                }
            }

            // a^24*b^2のパターン
            for (int i = 1; i <= 100; i++)
            {
                for (int j = 1; j <= 100; j++)
                {
                    if (i != j && primeCounts[i] >= 24 && primeCounts[j] >= 2)
                    {
                        count++;
                    }
                }
            }

            // a^74のパターン
            for (int i = 1; i <= 100; i++)
            {
                if (primeCounts[i] >= 74)
                { 
                    count++;
                }
            }

            yield return count;
        }

        IEnumerable<int> PrimeFactorization(int n)
        {
            for (int i = 2; i * i <= n; i++)
            {
                while (n % i == 0)
                {
                    n /= i;
                    yield return i;
                }
            }

            if (n != 1)
            {
                yield return n;
            }
        }
    }
}
