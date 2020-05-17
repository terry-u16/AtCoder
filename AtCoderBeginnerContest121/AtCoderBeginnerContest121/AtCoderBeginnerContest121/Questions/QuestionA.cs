using AtCoderBeginnerContest121.Questions;
using AtCoderBeginnerContest121.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest121.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var HW = inputStream.ReadIntArray();
            var hw = inputStream.ReadIntArray();
            yield return (HW[0] - hw[0]) * (HW[1] - hw[1]);
        }
    }
}
