using AtCoderBeginnerContest164.Algorithms;
using AtCoderBeginnerContest164.Collections;
using AtCoderBeginnerContest164.Questions;
using AtCoderBeginnerContest164.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest164.Questions
{
    /// <summary>
    /// 復習
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();

            var mods = new Modular[s.Length + 1];

            mods[s.Length] = new Modular(0, 2019);
            var tenFactor = new Modular(1, 2019);   // 10の位なら10を、100の位なら100を（mod 2019の世界で）かけていく
            for (int index = s.Length - 1; index >= 0; index--)
            {
                mods[index] = mods[index + 1] + tenFactor * new Modular(s[index] - '0', 2019);
                tenFactor *= new Modular(10, 2019);
            }

            var counter = new Counter<Modular>();
            foreach (var mod in mods)
            {
                counter[mod]++;
            }

            yield return counter.Where(pair => pair.count > 1).Sum(pair => pair.count * (pair.count - 1) / 2);
        }
    }
}
