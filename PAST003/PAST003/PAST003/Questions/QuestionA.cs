using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using PAST003.Algorithms;
using PAST003.Collections;
using PAST003.Extensions;
using PAST003.Numerics;
using PAST003.Questions;

namespace PAST003.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();
            var t = inputStream.ReadLine();

            if (s.Equals(t, StringComparison.Ordinal))
            {
                yield return "same";
            }
            else if (s.Equals(t, StringComparison.OrdinalIgnoreCase))
            {
                yield return "case-insensitive";
            }
            else
            {
                yield return "different";
            }
        }
    }
}
