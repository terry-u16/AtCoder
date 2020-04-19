using AtCoderBeginnerContest149.Questions;
using AtCoderBeginnerContest149.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest149.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var abk = inputStream.ReadLongArray();
            var takahashiCookie = abk[0];
            var aokiCookie = abk[1];
            var toEat = abk[2];

            if (takahashiCookie > toEat)
            {
                yield return $"{takahashiCookie - toEat} {aokiCookie}";
            }
            else if (takahashiCookie + aokiCookie > toEat)
            {
                yield return $"0 {takahashiCookie + aokiCookie - toEat}";
            }
            else
            {
                yield return "0 0";
            }
        }
    }
}
