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
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();
            yield return s.Substring(0, 3);
        }
    }
}
