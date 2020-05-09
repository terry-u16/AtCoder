using AtCoderBeginnerContest122.Questions;
using AtCoderBeginnerContest122.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest122.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();

            var maxLength = 0;
            for (int l = 0; l < s.Length; l++)
            {
                for (int r = l; r < s.Length; r++)
                {
                    var length = r - l + 1;
                    if (s.Substring(l, length).All(c => c == 'A' || c == 'C' || c == 'G' || c == 'T'))
                    {
                        maxLength = Math.Max(maxLength, length);
                    }
                }
            }

            yield return maxLength;
        }
    }
}
