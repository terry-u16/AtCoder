using AtCoderBeginnerContest151.Questions;
using AtCoderBeginnerContest151.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest151.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nkm = inputStream.ReadIntArray();
            var n = nkm[0];
            var k = nkm[1];
            var m = nkm[2];
            var a = inputStream.ReadIntArray();

            var target = n * m;
            var total = a.Sum();
            var need = target - total;

            if (need > k)
            {
                yield return -1;
            }
            else if (need <= 0)
            {
                yield return 0;
            }
            else
            {
                yield return need;
            }
        }
    }
}
