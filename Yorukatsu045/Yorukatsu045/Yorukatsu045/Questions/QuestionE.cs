using Yorukatsu045.Questions;
using Yorukatsu045.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu045.Questions
{
    /// <summary>
    /// ARC059 D
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();

            for (int begin = 0; begin < s.Length - 1; begin++)
            {
                if (s[begin] == s[begin + 1])
                {
                    yield return $"{begin + 1} {begin + 2}";
                    yield break;
                }
                else if (begin + 2 < s.Length && s[begin] == s[begin + 2])
                {
                    yield return $"{begin + 1} {begin + 3}";
                    yield break;
                }
            }

            yield return "-1 -1";
        }
    }
}
