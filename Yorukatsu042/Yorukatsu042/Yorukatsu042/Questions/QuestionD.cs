using Yorukatsu042.Questions;
using Yorukatsu042.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu042.Questions
{
    /// <summary>
    /// ARC097 C
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();
            var k = inputStream.ReadInt();

            yield return SmallSubstring(s, k, string.Empty);
        }

        int count = 0;

        private string SmallSubstring(string s, int k, string current)
        {
            for (char c = 'a'; c <= 'z'; c++)
            {
                var next = current + c;
                if (s.Contains(next))
                {
                    count++;
                    if (count == k)
                    {
                        return next;
                    }
                    else
                    {
                        var searched = SmallSubstring(s, k, next);
                        if (searched != string.Empty)
                        {
                            return searched;
                        }
                    }
                }
            }

            return string.Empty;
        }
    }
}
