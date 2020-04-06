using AtCoderBeginnersSelectionReview.Questions;
using AtCoderBeginnersSelectionReview.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnersSelectionReview.Questions
{
    public class ABC049C : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var S = inputStream.ReadLine();
            var reversedS = new string(S.Reverse().ToArray());

            var words = new string[] { "dream", "dreamer", "erase", "eraser" };
            var reversedWords = (words.Select(s => new string(s.Reverse().ToArray())));

            for (int i = 0; i < reversedS.Length;)
            {
                bool flag = false;
                foreach (var reversedWord in reversedWords)
                {
                    if (reversedS.Length - i < reversedWord.Length)
                    {
                        continue;
                    }

                    var subS = reversedS.AsSpan(i, reversedWord.Length);
                    var dividerSpan = reversedWord.AsSpan();
                    if (subS.SequenceEqual(dividerSpan))
                    {
                        flag = true;
                        i += reversedWord.Length;
                    }
                }

                if (!flag)
                {
                    yield return "NO";
                    yield break;
                }
            }

            yield return "YES";
        }
    }
}
