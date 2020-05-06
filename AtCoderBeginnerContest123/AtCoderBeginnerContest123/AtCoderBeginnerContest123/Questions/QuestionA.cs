using AtCoderBeginnerContest123.Questions;
using AtCoderBeginnerContest123.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest123.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var antennas = new int[5];
            for (int i = 0; i < 5; i++)
            {
                antennas[i] = inputStream.ReadInt();
            }
            var range = inputStream.ReadInt();

            yield return antennas[4] - antennas[0] > range ? ":(" : "Yay!";
        }
    }
}
