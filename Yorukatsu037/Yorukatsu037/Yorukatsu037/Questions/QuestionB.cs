using Yorukatsu037.Questions;
using Yorukatsu037.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu037.Questions
{
    /// <summary>
    /// ABC115 C
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nk = inputStream.ReadIntArray();
            var treeCount = nk[0];
            var illuminations = nk[1];
            var height = new int[treeCount];
            for (int i = 0; i < treeCount; i++)
            {
                height[i] = inputStream.ReadInt();
            }

            Array.Sort(height);

            var min = int.MaxValue;
            for (int i = 0; i + illuminations - 1 < height.Length; i++)
            {
                var diff = height[i + illuminations - 1] - height[i];
                min = Math.Min(min, diff);
            }

            yield return min;
        }
    }
}
