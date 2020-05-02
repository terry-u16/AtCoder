using Asakatsu20200503.Questions;
using Asakatsu20200503.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Asakatsu20200503.Questions
{
    /// <summary>
    /// AGC015 B
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();

            long total = 0;
            for (int floor = 0; floor < s.Length; floor++)
            {
                var upstairs = s.Length - floor - 1;
                var downstairs = floor;
                if (s[floor] == 'U')
                {
                    total += upstairs + 2 * downstairs;
                }
                else
                {
                    total += 2 * upstairs + downstairs;
                }
            }
            yield return total;
        }
    }
}
