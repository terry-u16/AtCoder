using Yorukatsu032.Questions;
using Yorukatsu032.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu032.Questions
{
    /// <summary>
    /// ABC094 C
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var x = inputStream.ReadIntArray();
            var orderedX = new int[n];
            x.CopyTo(orderedX, 0);
            Array.Sort(orderedX);

            var left = orderedX[orderedX.Length / 2 - 1];
            var right = orderedX[orderedX.Length / 2];

            foreach (var xi in x)
            {
                if (xi <= left)
                {
                    yield return right;
                }
                else
                {
                    yield return left;
                }
            }
        }
    }
}
