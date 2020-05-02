using AtCoderBeginnerContest165.Algorithms;
using AtCoderBeginnerContest165.Collections;
using AtCoderBeginnerContest165.Questions;
using AtCoderBeginnerContest165.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest165.Questions
{
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, m) = inputStream.ReadValue<int, int>();

            var half = n / 2;

            var arena = 0;
            foreach (var disjoint in GetDisjoints(n))
            {

            }

            throw new NotImplementedException();
        }

        IEnumerable<int> GetDisjoints(int n)
        {
            for (int i = 1; i < n; i++)
            {
                if (n % i != 0)
                {
                    yield return i;
                }
            }
        }
    }
}
