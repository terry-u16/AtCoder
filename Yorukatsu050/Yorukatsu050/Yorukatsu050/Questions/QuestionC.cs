using Yorukatsu050.Questions;
using Yorukatsu050.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu050.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc116/tasks/abc116_c
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var height = new[] { 0 }.Concat(inputStream.ReadIntArray()).ToArray();

            var count = 0;
            for (int i = 0; i + 1 < height.Length; i++)
            {
                if (height[i + 1] > height[i])
                {
                    count += height[i + 1] - height[i];
                }
            }

            yield return count;
        }
    }
}
