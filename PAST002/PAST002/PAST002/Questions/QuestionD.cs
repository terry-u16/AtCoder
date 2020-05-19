using PAST002.Algorithms;
using PAST002.Collections;
using PAST002.Questions;
using PAST002.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace PAST002.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();
            var count = GenerateT(string.Empty).Count(t => Regex.Match(s, t).Success);
            yield return count;
        }

        IEnumerable<string> GenerateT(string current)
        {
            if (current.Length != 0)
            {
                yield return current;
            }

            if (current.Length < 3)
            {
                for (char c = 'a'; c <= 'z'; c++)
                {
                    foreach (var t in GenerateT(current + c))
                    {
                        yield return t;
                    }
                }

                foreach (var t in GenerateT(current + '.'))
                {
                    yield return t;
                }
            }
        }
    }
}
