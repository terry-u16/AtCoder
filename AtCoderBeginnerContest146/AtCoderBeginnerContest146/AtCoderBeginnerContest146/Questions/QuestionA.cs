using AtCoderBeginnerContest146.Questions;
using AtCoderBeginnerContest146.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest146.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();
            if (s == "SUN")
            {
                yield return 7;
            }
            else
            {
                yield return 7 - ToInt(s);
            }
        }

        public int ToInt(string weekday)
        {
            switch (weekday)
            {
                case "SUN":
                    return 0;
                case "MON":
                    return 1;
                case "TUE":
                    return 2;
                case "WED":
                    return 3;
                case "THU":
                    return 4;
                case "FRI":
                    return 5;
                case "SAT":
                    return 6;
                default:
                    throw new ArgumentException();
            }
        }
    }
}
