using Yorukatsu023.Questions;
using Yorukatsu023.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu023.Questions
{
    /// <summary>
    /// ABC134 D
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = inputStream.ReadIntArray();
            var balls = new Stack<int>();

            var count = new int[n];
            for (int i = a.Length - 1; i >= 0; i--)
            {
                if (count[i] % 2 != a[i])
                {
                    balls.Push(i + 1);
                    foreach (var divisor in GetDivisors(i + 1))
                    {
                        count[divisor - 1]++;
                    }
                }
            }

            yield return balls.Count;
            if (balls.Count > 0)
            {
                yield return string.Join(" ", balls);
            }
        }

        private IEnumerable<int> GetDivisors(int n)
        {
            for (int i = 1; i * i <= n; i++)
            {
                if (n % i == 0)
                {
                    yield return i;
                    if (n / i != i)
                    {
                        yield return n / i;
                    }
                }
            }
        }
    }
}
