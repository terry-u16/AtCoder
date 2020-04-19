using AtCoderBeginnerContest163.Algorithms;
using AtCoderBeginnerContest163.Collections;
using AtCoderBeginnerContest163.Questions;
using AtCoderBeginnerContest163.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest163.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var subordinates = new int[n];

            var bosses = inputStream.ReadIntArray().Select(i => i - 1).ToArray();

            foreach (var boss in bosses)
            {
                subordinates[boss] += 1;
            }

            foreach (var subordinate in subordinates)
            {
                yield return subordinate;
            }
        }
    }
}
