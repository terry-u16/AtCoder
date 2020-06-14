using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TokioMarine2020.Algorithms;
using TokioMarine2020.Collections;
using TokioMarine2020.Extensions;
using TokioMarine2020.Numerics;
using TokioMarine2020.Questions;

namespace TokioMarine2020.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (oniInit, oniSpeed) = inputStream.ReadValue<long, long>();
            var (escapeInit, escapeSpeed) = inputStream.ReadValue<long, long>();
            var time = inputStream.ReadInt();

            var diff = Math.Abs(oniInit - escapeInit);
            var speedDiff = oniSpeed - escapeSpeed;

            if (speedDiff > 0 && (diff + speedDiff - 1) / speedDiff <= time)
            {
                yield return "YES";
            }
            else
            {
                yield return "NO";
            }
        }
    }
}
