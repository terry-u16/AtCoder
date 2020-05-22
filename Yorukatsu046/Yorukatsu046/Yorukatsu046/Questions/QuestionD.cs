using Yorukatsu046.Questions;
using Yorukatsu046.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Yorukatsu046.Questions
{
    /// <summary>
    /// ABC076 C
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine().Replace('?', '.');
            var t = inputStream.ReadLine();

            for (int i = s.Length - t.Length; i >= 0; i--)
            {
                var substring = s.Substring(i, t.Length);
                if (Regex.Match(t, substring).Success)
                {
                    var answer = (s.Substring(0, i) + t + s.Substring(i + t.Length)).Replace('.', 'a');
                    yield return answer;
                    yield break;
                }
            }

            yield return "UNRESTORABLE";
        }
    }
}
