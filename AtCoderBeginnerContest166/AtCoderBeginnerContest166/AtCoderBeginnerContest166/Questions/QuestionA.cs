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
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();
            switch (s)
            {
                case "ABC":
                    yield return "ARC";
                    yield break;
                case "ARC":
                    yield return "ABC";
                    yield break;
                default:
                    break;
            }
        }
    }
}
