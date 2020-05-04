using AtCoderBeginnerContest127.Questions;
using AtCoderBeginnerContest127.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest127.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nm = inputStream.ReadIntArray();
            var idCards = nm[0];
            var gates = nm[1];

            var increment = new int[idCards + 1];
            var decrement = new int[idCards + 1];

            for (int gate = 0; gate < gates; gate++)
            {
                var lr = inputStream.ReadIntArray().Select(i => i - 1).ToArray();
                increment[lr[0]]++;
                decrement[lr[1] + 1]++;
            }

            var count = 0;
            var availableGates = 0;
            for (int idCard = 0; idCard < idCards; idCard++)
            {
                availableGates += increment[idCard] - decrement[idCard];
                if (availableGates == gates)
                {
                    count++;
                }
            }

            yield return count;
        }
    }
}
