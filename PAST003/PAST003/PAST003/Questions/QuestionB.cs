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
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (people, questions, queries) = inputStream.ReadValue<int, int, int>();
            var solved = Enumerable.Repeat(0, people).Select(_ => new bool[questions]).ToArray();
            var solvedCount = new int[questions];

            for (int q = 0; q < queries; q++)
            {
                var input = inputStream.ReadIntArray();
                var person = input[1] - 1;
                if (input[0] == 1)
                {
                    var sum = 0;
                    for (int question = 0; question < questions; question++)
                    {
                        if (solved[person][question])
                        {
                            sum += people - solvedCount[question];
                        }
                    }
                    yield return sum;
                }
                else
                {
                    var question = input[2] - 1;
                    solved[person][question] = true;
                    solvedCount[question]++;
                }
            }
        }
    }
}
