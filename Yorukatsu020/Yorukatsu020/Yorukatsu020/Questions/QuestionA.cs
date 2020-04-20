using Yorukatsu020.Questions;
using Yorukatsu020.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu020.Questions
{
    /// <summary>
    /// ABC123 B
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var a = inputStream.ReadInt();
            var b = inputStream.ReadInt();
            var c = inputStream.ReadInt();
            var d = inputStream.ReadInt();
            var e = inputStream.ReadInt();

            var dishes = new[] { a, b, c, d, e };
            var minDishTime = int.MaxValue;
            var minDishIndex = 0;

            for (int i = 0; i < dishes.Length; i++)
            {
                if (dishes[i] % 10 < minDishTime && dishes[i] % 10 != 0)
                {
                    minDishIndex = i;
                    minDishTime = dishes[i] % 10;
                }
            }

            var totalTime = 0;

            for (int i = 0; i < dishes.Length; i++)
            {
                if (i == minDishIndex)
                {
                    totalTime += dishes[i];
                }
                else
                {
                    totalTime += (int)Math.Ceiling((double)dishes[i] / 10) * 10;
                }
            }

            yield return totalTime;
        }
    }
}
