using AtCoderBeginnerContest156.Questions;
using AtCoderBeginnerContest156.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest156.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        int[] x = null;
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            x = inputStream.ReadIntArray();

            yield return Enumerable.Range(1, 100).Min(c => CalculateHP(c));
        }

        private int CalculateHP(int coodinate)
        {
            var hp = 0;
            for (int i = 0; i < x.Length; i++)
            {
                hp += (x[i] - coodinate) * (x[i] - coodinate);
            }
            return hp;
        }
    }
}
