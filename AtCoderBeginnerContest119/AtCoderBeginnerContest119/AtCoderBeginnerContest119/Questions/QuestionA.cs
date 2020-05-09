using AtCoderBeginnerContest119.Questions;
using AtCoderBeginnerContest119.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest119.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var datetime = DateTime.Parse(inputStream.ReadLine());
            if (datetime < new DateTime(2019, 5, 1))
            {
                yield return "Heisei";
            }
            else
            {
                yield return "TBD";
            }
        }
    }
}
