using AtCoderBeginnerContest153.Questions;
using AtCoderBeginnerContest153.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest153.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            long h = inputStream.ReadLong();
            long count = 0;
            long monsters = 1;

            while (h > 0)
            {
                count += monsters;
                h >>= 1;
                monsters <<= 1;
            }

            yield return count;
        }
    }
}
