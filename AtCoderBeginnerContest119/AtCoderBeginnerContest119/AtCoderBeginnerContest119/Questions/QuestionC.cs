using AtCoderBeginnerContest119.Questions;
using AtCoderBeginnerContest119.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest119.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nabc = inputStream.ReadIntArray();
            var bamboosCount = nabc[0];
            var neededKadomatsu = nabc.Skip(1).ToArray();
            var bamboos = new int[bamboosCount];
            for (int i = 0; i < bamboosCount; i++)
            {
                bamboos[i] = inputStream.ReadInt();
            }

            var minMP = int.MaxValue;
            for (int flag = 0; flag < 1 << (bamboosCount * 2); flag++)
            {
                var kadomatsu = new int[3];
                var mp = 0;

                for (int bamboo = 0; bamboo < bamboosCount; bamboo++)
                {
                    var usage = (flag & (0x03 << (bamboo * 2))) >> (bamboo * 2);
                    if (usage > 0)
                    {
                        var number = usage - 1;
                        if (kadomatsu[number] > 0)
                        {
                            mp += 10;
                        }
                        kadomatsu[number] += bamboos[bamboo];
                    }
                }

                if (kadomatsu.All(k => k > 0))
                {
                    for (int i = 0; i < neededKadomatsu.Length; i++)
                    {
                        mp += Math.Abs(neededKadomatsu[i] - kadomatsu[i]);
                    }
                    minMP = Math.Min(minMP, mp);
                }
            }

            yield return minMP;
        }
    }
}
