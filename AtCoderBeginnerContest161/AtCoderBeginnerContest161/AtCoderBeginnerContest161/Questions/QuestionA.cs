using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AtCoderBeginnerContest161.Extensions;

namespace AtCoderBeginnerContest161.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<string> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadIntArray();
            Swap(ref n[0], ref n[1]);
            Swap(ref n[0], ref n[2]);
            yield return $"{n[0]} {n[1]} {n[2]}";
        }

        private void Swap(ref int a, ref int b)
        {
            int temp = b;
            b = a;
            a = temp;
        }
    }
}
