using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using AtCoderBeginnerContest169.Algorithms;
using AtCoderBeginnerContest169.Collections;
using AtCoderBeginnerContest169.Extensions;
using AtCoderBeginnerContest169.Numerics;
using AtCoderBeginnerContest169.Questions;

namespace AtCoderBeginnerContest169.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (a, b) = inputStream.ReadValue<long, string>();
            var bBigInt = new BigInteger(int.Parse(b.Replace(".", "")));
            var answer = a * bBigInt / 100;
            yield return answer;
        }
    }
}
