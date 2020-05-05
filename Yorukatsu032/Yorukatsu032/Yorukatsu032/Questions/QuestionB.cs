using Yorukatsu032.Questions;
using Yorukatsu032.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu032.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();

            var max = 0;
            for (int i = 1; i < s.Length / 2; i++)
            {
                var left = s.Substring(0, i);
                var right = s.Substring(i, i);

                if (left == right)
                {
                    max = i * 2;
                }
            }

            yield return max;
        }
    }
}
