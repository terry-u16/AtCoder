using PanasonicProgrammingContest2020.Questions;
using PanasonicProgrammingContest2020.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PanasonicProgrammingContest2020.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var hw = inputStream.ReadIntArray();
            long h = hw[0];
            long w = hw[1];

            if (h == 1 || w == 1)
            {
                yield return 1;
            }
            else
            {
                yield return (h * w + 1) / 2;
            }
        }
    }
}
