using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Nomura2020.Algorithms;
using Nomura2020.Collections;
using Nomura2020.Extensions;
using Nomura2020.Numerics;
using Nomura2020.Questions;

namespace Nomura2020.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (h1, m1, h2, m2, k) = inputStream.ReadValue<int, int, int, int, int>();
            var time1 = new DateTime(2020, 1, 1, h1, m1, 0);
            var time2 = new DateTime(2020, 1, 1, h2, m2, 0);
            var diff = (time2 - time1).TotalMinutes;
            yield return diff - k;
        }
    }
}
 