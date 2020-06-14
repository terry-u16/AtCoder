using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AtCoderBeginnerContest170.Algorithms;
using AtCoderBeginnerContest170.Collections;
using AtCoderBeginnerContest170.Extensions;
using AtCoderBeginnerContest170.Numerics;
using AtCoderBeginnerContest170.Questions;

namespace AtCoderBeginnerContest170.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var x = inputStream.ReadIntArray();

            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] == 0)
                {
                    yield return i + 1;
                }
            }
        }
    }
}
