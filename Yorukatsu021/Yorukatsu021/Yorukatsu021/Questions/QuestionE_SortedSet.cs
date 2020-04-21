using Yorukatsu021.Questions;
using Yorukatsu021.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu021.Questions
{
    /// <summary>
    /// ABC157 E
    /// </summary>
    public class QuestionE_SortedSet : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var s = inputStream.ReadLine();
            var q = inputStream.ReadInt();

            const int alphabetCount = 'z' - 'a' + 1;
            var charIndexes = Enumerable.Range(0, alphabetCount).Select(_ => new SortedSet<int>()).ToArray();
            for (int i = 0; i < s.Length; i++)
            {
                charIndexes[s[i] - 'a'].Add(i);
            }

            for (int i = 0; i < q; i++)
            {
                var query = inputStream.ReadLine().Split(' ');

                switch (query[0])
                {
                    case "1":
                        var index = int.Parse(query[1]) - 1;
                        var oldChar = s[index] - 'a';
                        var newChar = query[2][0] - 'a';
                        charIndexes[oldChar].Remove(index);
                        charIndexes[newChar].Add(index);
                        break;
                    case "2":
                        var left = int.Parse(query[1]) - 1;
                        var right = int.Parse(query[2]) - 1;
                        yield return Enumerable.Range(0, alphabetCount).Count(c => charIndexes[c].GetViewBetween(left, right).Any());
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
