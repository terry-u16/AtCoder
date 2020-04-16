using Yorukatsu017.Questions;
using Yorukatsu017.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu017.Questions
{
    /// <summary>
    /// ABC051 C
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var input = inputStream.ReadIntArray();
            var sx = input[0];
            var sy = input[1];
            var tx = input[2];
            var ty = input[3];

            var builder = new StringBuilder();

            for (int y = sy; y < ty; y++)
            {
                builder.Append('U');
            }

            for (int x = sx; x < tx; x++)
            {
                builder.Append('R');
            }

            for (int y = ty; y > sy; y--)
            {
                builder.Append('D');
            }

            for (int x = tx; x > sx; x--)
            {
                builder.Append('L');
            }

            // 2周目
            builder.Append('L');

            for (int y = sy; y < ty + 1; y++)
            {
                builder.Append('U');
            }

            for (int x = sx - 1; x < tx; x++)
            {
                builder.Append('R');
            }

            builder.Append('D');
            builder.Append('R');

            for (int y = ty; y > sy - 1; y--)
            {
                builder.Append('D');
            }

            for (int x = tx + 1; x > sx; x--)
            {
                builder.Append('L');
            }
            builder.Append('U');

            yield return builder.ToString();
        }
    }
}
