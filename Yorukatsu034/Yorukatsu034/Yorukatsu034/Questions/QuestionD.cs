using Yorukatsu034.Questions;
using Yorukatsu034.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu034.Questions
{
    /// <summary>
    /// ABC110 C
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();
            var t = inputStream.ReadLine();

            var correspondingCharactersS = new Dictionary<char, char>();
            var correspondingCharactersT = new Dictionary<char, char>();

            for (int i = 0; i < s.Length; i++)
            {
                if (correspondingCharactersS.ContainsKey(s[i]))
                {
                    if (correspondingCharactersS[s[i]] != t[i])
                    {
                        yield return "No";
                        yield break;
                    }
                }
                else
                {
                    correspondingCharactersS.Add(s[i], t[i]);
                }

                if (correspondingCharactersT.ContainsKey(t[i]))
                {
                    if (correspondingCharactersT[t[i]] != s[i])
                    {
                        yield return "No";
                        yield break;
                    }
                }
                else
                {
                    correspondingCharactersT.Add(t[i], s[i]);
                }
            }

            yield return "Yes";
        }
    }
}
