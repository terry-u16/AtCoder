using AtCoderBeginnerContest158.Questions;
using AtCoderBeginnerContest158.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest158.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var ab = inputStream.ReadIntArray();
            var a = ab[0];
            var b = ab[1];

            for (int i = 1; i <= 1010; i++)
            {
                var tax8 = (int)(i * 0.08);
                var tax10 = (int)(i * 0.1);

                if (tax8 == a && tax10 == b)
                {
                    yield return i;
                    yield break;
                }
            }

            yield return -1;
        }
    }
}
