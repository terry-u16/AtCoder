using AtCoderBeginnerContest148.Questions;
using AtCoderBeginnerContest148.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest148.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var brickCount = inputStream.ReadInt();
            var bricks = inputStream.ReadIntArray();

            var currentNo = 1;
            var breakCount = 0;
            foreach (var brick in bricks)
            {
                if (brick != currentNo)
                {
                    breakCount++;
                }
                else
                {
                    currentNo++;
                }
            }

            if (brickCount == breakCount)
            {
                yield return -1;
            }
            else
            {
                yield return breakCount;
            }
        }
    }
}
