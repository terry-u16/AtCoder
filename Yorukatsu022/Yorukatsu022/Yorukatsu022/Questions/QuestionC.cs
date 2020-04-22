using Yorukatsu022.Questions;
using Yorukatsu022.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu022.Questions
{
    /// <summary>
    /// ABC045 B
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = new[] { inputStream.ReadLine(), inputStream.ReadLine(), inputStream.ReadLine() };
            var index = new[] { 0, 0, 0 };

            var player = 0;   // Aさんは0,以下1,2

            while (index[player] != s[player].Length)
            {
                player = s[player][index[player]++] - 'a';
            }

            yield return (char)(player + 'A');
            yield break;
        }
    }
}
