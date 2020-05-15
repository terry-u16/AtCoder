using AtCoderBeginnerContest116.Questions;
using AtCoderBeginnerContest116.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest116.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var heights = inputStream.ReadIntArray();
            var current = 0;
            var count = 0;
            foreach (var height in heights)
            {
                if (height > current)
                {
                    count += height - current;
                }
                current = height;
            }

            yield return count;
        }
    }
}
