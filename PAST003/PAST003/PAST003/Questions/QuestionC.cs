using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using PAST003.Algorithms;
using PAST003.Collections;
using PAST003.Extensions;
using PAST003.Numerics;
using PAST003.Questions;

namespace PAST003.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (init, ratio, n) = inputStream.ReadValue<long, long, int>();

            var current = init;
            for (int i = 2; i <= n; i++)
            {
                current *= ratio;
                if (current > 1_000_000_000)
                {
                    yield return "large";
                    yield break;
                }
            }
            yield return current;
        }
    }
}
