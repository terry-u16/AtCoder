using AtCoderBeginnerContest149.Questions;
using AtCoderBeginnerContest149.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest149.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var x = inputStream.ReadInt();
            yield return GetPrimes(x * 10).First(i => i >= x);
        }

        IEnumerable<int> GetPrimes(int max)
        {
            var isMultipleNumber = new bool[max + 1];

            for (int i = 2; i < max; i++)
            {
                if (!isMultipleNumber[i])
                {
                    yield return i;
                    for (int mul = 1; i * mul <= max; mul++)
                    {
                        isMultipleNumber[i * mul] = true;
                    }
                }
            }
        }
    }
}
