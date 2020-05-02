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
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var x = inputStream.ReadLong();

            long yokin = 100;
            for (int year = 1; true; year++)
            {
                yokin = (long)(yokin * 1.01d);

                if (yokin >= x)
                {
                    yield return year;
                    yield break;
                }
            }
        }
    }
}
