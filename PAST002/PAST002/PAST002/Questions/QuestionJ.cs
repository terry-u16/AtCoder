using PAST002.Algorithms;
using PAST002.Collections;
using PAST002.Questions;
using PAST002.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PAST002.Questions
{
    public class QuestionJ : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();
            yield return Process(s);
        }

        string Process(string s)
        {
            var confirmed = new StringBuilder();
            var buffer = new StringBuilder();
            var brackets = 0;

            foreach (var c in s)
            {
                if (brackets == 0)
                {
                    if (c == '(')
                    {
                        brackets++;
                    }
                    else
                    {
                        confirmed.Append(c);
                    }
                }
                else
                {
                    if (c == ')' && --brackets == 0)
                    {
                        var processed = Process(buffer.ToString());
                        confirmed.Append(processed + string.Concat(processed.Reverse()));
                        buffer.Clear();
                    }
                    else
                    {
                        buffer.Append(c);
                        if (c == '(')
                        {
                            brackets++;
                        }
                    }
                }
            }

            return confirmed.ToString();
        }
    }
}
