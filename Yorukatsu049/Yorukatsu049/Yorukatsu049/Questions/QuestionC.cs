using Yorukatsu049.Questions;
using Yorukatsu049.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu049.Questions
{
    /// <summary>
    /// ABC066 C
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = inputStream.ReadIntArray();
            var b = new LinkedList<int>();
            var reversed = false;

            foreach (var ai in a)
            {
                if (reversed)
                {
                    b.AddFirst(ai);
                }
                else
                {
                    b.AddLast(ai);
                }
                reversed = !reversed;
            }

            if (reversed)
            {
                yield return string.Join(" ", b.Reverse());
            }
            else
            {
                yield return string.Join(" ", b);
            }
        }
    }
}
