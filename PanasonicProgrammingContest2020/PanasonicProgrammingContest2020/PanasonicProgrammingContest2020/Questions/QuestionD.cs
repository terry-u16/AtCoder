using PanasonicProgrammingContest2020.Questions;
using PanasonicProgrammingContest2020.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace PanasonicProgrammingContest2020.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();

            foreach (var normalForm in GetNormalForms(new int[] { 0 }, 1, n))
            {
                yield return string.Concat(normalForm.Select(i => (char)(i + 'a')));
            }
        }

        IEnumerable<int[]> GetNormalForms(int[] current, int currentDigit, int maxDigit)
        {
            if (currentDigit == maxDigit)
            {
                yield return current;
                yield break;
            }

            var max = current.Max();
            for (int i = 0; i <= max + 1; i++)
            {
                var next = current.Concat(Enumerable.Range(i, 1)).ToArray();
                foreach (var normalForm in GetNormalForms(next, currentDigit + 1, maxDigit))
                {
                    yield return normalForm;
                }
            }
        }
    }
}
