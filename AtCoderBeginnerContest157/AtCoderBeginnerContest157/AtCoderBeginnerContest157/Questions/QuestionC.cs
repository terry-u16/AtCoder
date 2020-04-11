using AtCoderBeginnerContest157.Questions;
using AtCoderBeginnerContest157.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest157.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nm = inputStream.ReadIntArray();
            var n = nm[0];
            var m = nm[1];

            var candidate = new int?[n];

            for (int i = 0; i < m; i++)
            {
                var sc = inputStream.ReadIntArray();
                var s = sc[0];
                var c = sc[1];

                if (n > 1 && s == 1 && c == 0)
                {
                    yield return -1;
                    yield break;
                }
                if (candidate[s - 1] != null && candidate[s - 1] != c)
                {
                    yield return -1;
                    yield break;
                }
                candidate[s - 1] = c;
            }

            yield return Compose(candidate);
        }

        int Compose(int?[] candidate)
        {
            var result = 0;

            for (int i = 0; i < candidate.Length; i++)
            {
                result *= 10;

                if (candidate[i] != null)
                {
                    result += candidate[i].Value;
                }
                else
                {
                    result += (i == 0 && candidate.Length > 1) ? 1 : 0;
                }
            }

            return result;
        }
    }
}
