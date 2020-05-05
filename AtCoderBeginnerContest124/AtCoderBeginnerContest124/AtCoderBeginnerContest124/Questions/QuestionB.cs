using AtCoderBeginnerContest124.Questions;
using AtCoderBeginnerContest124.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest124.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var heights = inputStream.ReadIntArray();

            var max = int.MinValue;
            var count = 0;
            foreach (var height in heights)
            {
                if (max <= height)
                {
                    count++;
                    max = height;
                }
            }

            yield return count;
        }
    }
}
