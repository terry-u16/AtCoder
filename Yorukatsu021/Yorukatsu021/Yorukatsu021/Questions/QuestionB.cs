using Yorukatsu021.Questions;
using Yorukatsu021.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Yorukatsu021.Questions
{
    /// <summary>
    /// ABC100 C
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = inputStream.ReadIntArray();
            yield return a.Sum(i => GetPrimeFactor2(i));
        }

        int GetPrimeFactor2(int n)
        {
            var count = 0;
            while ((n & 0x01) == 0)
            {
                n >>= 1;
                count++;
            }
            return count;
        }
    }
}
