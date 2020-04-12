using AtCoderBeginnerContest162.Algorithms;
using AtCoderBeginnerContest162.Collections;
using AtCoderBeginnerContest162.Questions;
using AtCoderBeginnerContest162.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest162.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var k = inputStream.ReadInt();

            long sum = 0;
            for (int a = 1; a <= k; a++)
            {
                for (int b = 1; b <= k; b++)
                {
                    for (int c = 1; c <= k; c++)
                    {
                        sum += BasicAlgorithm.Gcd(BasicAlgorithm.Gcd(a, b), c);
                    }
                }
            }

            yield return sum;
        }
    }
}
