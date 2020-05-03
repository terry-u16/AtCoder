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
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, a, b, c) = inputStream.ReadValue<int, long, long, long>();

            var counter = new Counter<string>();

            var diff = new int[3];

            for (int i = 0; i < n; i++)
            {
                var s = inputStream.ReadLine();
                counter[s]++;
                if (a == 0 && b == 0)
                {

                } 
            }
        }
    }
}
