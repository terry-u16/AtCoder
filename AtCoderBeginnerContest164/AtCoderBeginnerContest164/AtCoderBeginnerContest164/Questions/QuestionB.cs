using AtCoderBeginnerContest164.Algorithms;
using AtCoderBeginnerContest164.Collections;
using AtCoderBeginnerContest164.Questions;
using AtCoderBeginnerContest164.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest164.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (takahashiHP, takahashiAttack, aokiHP, aokiAttack) = inputStream.ReadValue<int, int, int, int>();

            while (takahashiHP > 0 && aokiHP > 0)
            {
                aokiHP -= takahashiAttack;
                if (aokiHP <= 0)
                {
                    break;
                }
                takahashiHP -= aokiAttack;
            }

            yield return takahashiHP > 0 ? "Yes" : "No";
        }
    }
}
