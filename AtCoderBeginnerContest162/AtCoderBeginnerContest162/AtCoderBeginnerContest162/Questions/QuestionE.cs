using AtCoderBeginnerContest162.Algorithms;
using AtCoderBeginnerContest162.Collections;
using AtCoderBeginnerContest162.Questions;
using AtCoderBeginnerContest162.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest162.Questions
{
    public class QuestionE : AtCoderQuestionBase
    {
        // 復習
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, k) = inputStream.ReadValue<int, int>();
            var patterns = new Modular[k];

            Modular total = new Modular(0);
            for (int i = k; i >= 1; i--)
            {
                var pattern = Modular.Pow(new Modular(k / i), n);

                for (int j = 2; i * j <= k; j++)
                {
                    pattern -= patterns[i * j - 1];
                }

                patterns[i - 1] = pattern;
                var gcd = new Modular(i) * pattern;

                total += gcd;
            }

            yield return total.Value;
        }
    }
}
