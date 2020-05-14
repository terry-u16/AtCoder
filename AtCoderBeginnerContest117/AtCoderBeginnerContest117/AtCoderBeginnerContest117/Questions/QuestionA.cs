using AtCoderBeginnerContest117.Algorithms;
using AtCoderBeginnerContest117.Collections;
using AtCoderBeginnerContest117.Questions;
using AtCoderBeginnerContest117.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest117.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (t, x) = inputStream.ReadValue<decimal, decimal>();
            yield return t / x;
        }
    }
}
