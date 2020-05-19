using PAST002.Algorithms;
using PAST002.Collections;
using PAST002.Questions;
using PAST002.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PAST002.Questions
{
    public class QuestionI : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var rounds = inputStream.ReadInt();
            var participants = Enumerable.Range(0, rounds + 1).Select(_ => new Queue<(int id, int strength)>()).ToArray();

            var a = inputStream.ReadIntArray();
            var lastRounds = Enumerable.Repeat(rounds, a.Length).ToArray();
            for (int i = 0; i < a.Length; i++)
            {
                participants[0].Enqueue((i, a[i]));
            }

            for (int round = 1; round <= rounds; round++)
            {
                while (participants[round - 1].Count > 0)
                {
                    var man1 = participants[round - 1].Dequeue();
                    var man2 = participants[round - 1].Dequeue();

                    var winner = man1.strength > man2.strength ? man1 : man2;
                    var loser = man1.strength > man2.strength ? man2 : man1;

                    lastRounds[loser.id] = round;
                    participants[round].Enqueue(winner);
                }
            }

            foreach (var lastRound in lastRounds)
            {
                yield return lastRound;
            }
        }
    }
}
