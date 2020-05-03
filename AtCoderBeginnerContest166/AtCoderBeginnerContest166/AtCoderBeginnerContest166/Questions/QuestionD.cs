using AtCoderBeginnerContest166.Algorithms;
using AtCoderBeginnerContest166.Collections;
using AtCoderBeginnerContest166.Questions;
using AtCoderBeginnerContest166.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest166.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var x = inputStream.ReadInt();
            var divisiorsX = GetDivisiors(x).OrderBy(i => i).ToArray();

            foreach (var aMinusB in divisiorsX)
            {
                var fact = x / aMinusB;

                for (long a = 1; a * a * a * a <= fact; a++)
                {
                    var b = a - aMinusB;
                    if (a * a * a * a + a * a * a * b + a * a * b * b + a * b * b * b + b * b * b * b == fact)
                    {
                        yield return $"{a} {b}";
                        yield break;
                    }
                }
            }
        }

        IEnumerable<int> GetDivisiors(int n)
        {
            for (int i = 1; i * i <= n; i++)
            {
                if (n % i == 0)
                {
                    yield return i;
                    if (i * i != n)
                    {
                        yield return n / i;
                    }
                }
            }
        }
    }
}
