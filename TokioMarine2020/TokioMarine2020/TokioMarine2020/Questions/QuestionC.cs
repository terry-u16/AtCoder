using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TokioMarine2020.Algorithms;
using TokioMarine2020.Collections;
using TokioMarine2020.Extensions;
using TokioMarine2020.Numerics;
using TokioMarine2020.Questions;

namespace TokioMarine2020.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, k) = inputStream.ReadValue<int, int>();
            var brightnesses = inputStream.ReadIntArray();

            for (int repeat = 0; repeat < k; repeat++)
            {
                var nextBrightnesses = new int[n + 1];
                for (int light = 0; light < n; light++)
                {
                    nextBrightnesses[Math.Max(0, light - brightnesses[light])] += 1;
                    nextBrightnesses[Math.Min(n, light + brightnesses[light] + 1)] -= 1;
                }

                var all = true;
                for (int i = 0; i + 1 < nextBrightnesses.Length; i++)
                {
                    all = all && nextBrightnesses[i] == n;
                    nextBrightnesses[i + 1] += nextBrightnesses[i];
                }

                if (all)
                {
                    yield return string.Join(" ", nextBrightnesses.Take(n));
                    yield break;
                }

                brightnesses = nextBrightnesses;
            }

            yield return string.Join(" ", brightnesses.Take(n));
        }
    }
}
