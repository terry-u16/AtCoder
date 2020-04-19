using AtCoderBeginnerContest163.Algorithms;
using AtCoderBeginnerContest163.Collections;
using AtCoderBeginnerContest163.Questions;
using AtCoderBeginnerContest163.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Numerics;

namespace AtCoderBeginnerContest163.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, k) = inputStream.ReadValue<int, int>();
            var digitCount = n + 1;

            var count = new Modular(0);
            for (int i = k; i <= digitCount; i++)
            {
                long canShiftDigit = digitCount - i;
                count += new Modular(i * canShiftDigit + 1);
            }

            yield return count.Value;
        }
    }
}
