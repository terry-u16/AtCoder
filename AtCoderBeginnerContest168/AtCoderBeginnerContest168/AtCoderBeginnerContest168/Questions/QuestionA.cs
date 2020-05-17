using AtCoderBeginnerContest168.Algorithms;
using AtCoderBeginnerContest168.Collections;
using AtCoderBeginnerContest168.Questions;
using AtCoderBeginnerContest168.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest168.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt() % 10;

            var answer = n switch
            {
                2 => "hon",
                4 => "hon",
                5 => "hon",
                7 => "hon",
                9 => "hon",
                0 => "pon",
                1 => "pon",
                6 => "pon",
                8 => "pon",
                3 => "bon",
                _ => ""
            };

            yield return answer;
        }
    }
}
