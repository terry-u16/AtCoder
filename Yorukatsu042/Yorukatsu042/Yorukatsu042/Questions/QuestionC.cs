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
    /// ABC058 C
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var charSet = new int['z' - 'a' + 1];

            foreach (var c in inputStream.ReadLine())
            {
                charSet[c - 'a']++;
            }

            for (int i = 1; i < n; i++)
            {
                var s = inputStream.ReadLine();

                for (int j = 0; j < charSet.Length; j++)
                {
                    charSet[j] = Math.Min(charSet[j], s.Count(c => c - 'a' == j));
                }
            }

            var builder = new List<char>();

            for (int i = 0; i < charSet.Length; i++)
            {
                for (int j = 0; j < charSet[i]; j++)
                {
                    builder.Add((char)(i + 'a'));
                }
            }

            yield return string.Concat(builder);
        }
    }
}
