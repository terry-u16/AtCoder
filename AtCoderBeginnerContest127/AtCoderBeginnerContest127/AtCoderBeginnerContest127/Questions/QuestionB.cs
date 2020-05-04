using AtCoderBeginnerContest127.Questions;
using AtCoderBeginnerContest127.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest127.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var rdx = inputStream.ReadIntArray();
            var r = rdx[0];
            var d = rdx[1];
            var x = rdx[2];

            for (int i = 2001; i <= 2010; i++)
            {
                x = r * x - d;
                yield return x;
            }
        }
    }
}
