using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Asakatsu20200810.Algorithms;
using Asakatsu20200810.Collections;
using Asakatsu20200810.Extensions;
using Asakatsu20200810.Numerics;
using Asakatsu20200810.Questions;

namespace Asakatsu20200810.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            foreach (var s in Compose("a", 'a', n))
            {
                yield return s;
            }
        }

        IEnumerable<string> Compose(string s, char max, int maxLength)
        {
            if (s.Length == maxLength)
            {
                yield return s;
            }
            else
            {
                for (char c = 'a'; c <= max + 1; c++)
                {
                    foreach (var child in Compose(s + c, (char)Math.Max(max, c), maxLength))
                    {
                        yield return child;
                    }
                }
            }
        }
    }
}
