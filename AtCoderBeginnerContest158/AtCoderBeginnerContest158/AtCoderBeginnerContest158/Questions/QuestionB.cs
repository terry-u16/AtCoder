using AtCoderBeginnerContest158.Questions;
using AtCoderBeginnerContest158.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest158.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nab = inputStream.ReadLongArray();
            var n = nab[0];
            var a = nab[1];
            var b = nab[2];
            var balls = a + b;

            var div = n / balls;
            var mod = n % balls;
            yield return a * div + Math.Min(mod, a);
        }
    }
}
