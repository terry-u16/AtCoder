using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Training20200621.Algorithms;
using Training20200621.Collections;
using Training20200621.Extensions;
using Training20200621.Numerics;
using Training20200621.Questions;

namespace Training20200621.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/agc018/tasks/agc018_b
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (people, sports) = inputStream.ReadValue<int, int>();
            var favorites = new int[people][];
            for (int i = 0; i < people; i++)
            {
                favorites[i] = inputStream.ReadIntArray().Select(f => f - 1).ToArray();
            }

            var cancelledSports = new HashSet<int>();
            var maxParticipants = int.MaxValue;

            while (cancelledSports.Count < sports)
            {
                var participants = GetParticipants(favorites, cancelledSports);

                var max = 0;
                var index = -1;
                for (int i = 0; i < participants.Length; i++)
                {
                    if (max < participants[i])
                    {
                        max = participants[i];
                        index = i;
                    }
                }
                maxParticipants = Math.Min(maxParticipants, max);
                cancelledSports.Add(index);
            }

            yield return maxParticipants;
        }

        int[] GetParticipants(int[][] favorites, HashSet<int> cancelledSports)
        {
            var people = favorites.Length;
            var sports = favorites[0].Length;

            var participants = new int[sports];

            foreach (var favoritesOfPerson in favorites)
            {
                foreach (var sport in favoritesOfPerson)
                {
                    if (!cancelledSports.Contains(sport))
                    {
                        participants[sport]++;
                        break;
                    }
                }
            }

            return participants;
        }
    }
}
