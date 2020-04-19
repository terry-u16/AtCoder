using AtCoderBeginnerContest163.Algorithms;
using AtCoderBeginnerContest163.Collections;
using AtCoderBeginnerContest163.Questions;
using AtCoderBeginnerContest163.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest163.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (summerVacationLength, shukudaiCount) = inputStream.ReadValue<int, int>();
            var shukudai = inputStream.ReadIntArray();
            var holidayCount = summerVacationLength - shukudai.Sum();
            yield return Math.Max(holidayCount, -1);
        }
    }
}
