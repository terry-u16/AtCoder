using Yorukatsu048.Questions;
using Yorukatsu048.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu048.Questions
{
    /// <summary>
    /// ABC158 B
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nab = inputStream.ReadLongArray();
            var n = nab[0];
            var blue = nab[1];
            var red = nab[2];

            var rep = n / (blue + red);
            var mod = n % (blue + red);

            yield return rep * blue + Math.Min(blue, mod);
        }
    }
}
