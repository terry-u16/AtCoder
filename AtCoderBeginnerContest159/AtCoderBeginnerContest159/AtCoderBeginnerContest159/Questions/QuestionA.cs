using AtCoderBeginnerContest159.Questions;
using AtCoderBeginnerContest159.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest159.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nm = inputStream.ReadIntArray();
            var n = nm[0];
            var m = nm[1];

            yield return nCr(n, 2) + nCr(m, 2);
        }

        private int nCr(int n, int r)
        {
            if (n < r)
            {
                return 0;
            }

            if (n - r < r)
            {
                r = n - r;
            }

            int result = 1;

            for (int i = 0; i < r; i++)
            {
                result *= (n - i);
            }

            for (int i = 0; i < r; i++)
            {
                result /= (i + 1);
            }

            return result;
        }
    }
}
