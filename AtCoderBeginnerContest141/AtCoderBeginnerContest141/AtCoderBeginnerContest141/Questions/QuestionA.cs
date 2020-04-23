using AtCoderBeginnerContest141.Questions;
using AtCoderBeginnerContest141.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest141.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();

            switch (s)
            {
                case "Sunny":
                    yield return "Cloudy";
                    yield break;
                case "Cloudy":
                    yield return "Rainy";
                    yield break;
                case "Rainy":
                    yield return "Sunny";
                    yield break;
            }
        }
    }
}
