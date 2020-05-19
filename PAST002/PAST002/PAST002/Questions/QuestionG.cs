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
    public class QuestionG : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var queries = inputStream.ReadInt();
            var s = new LinkedList<RepeatingChar>();

            for (int q = 0; q < queries; q++)
            {
                var query = inputStream.ReadStringArray();

                if (query[0] == "1")
                {
                    var c = query[1][0];
                    var count = int.Parse(query[2]);

                    s.AddLast(new RepeatingChar(c, count));
                }
                else
                {
                    var score = Remove(s, query);
                    yield return score;
                }
            }
        }

        private static long Remove(LinkedList<RepeatingChar> s, string[] query)
        {
            var removingCount = int.Parse(query[1]);
            Span<int> totalRemoved = stackalloc int[26];

            while (s.Count > 0 && removingCount > 0)
            {
                var (character, count) = s.First();
                s.RemoveFirst();
                var removing = Math.Min(count, removingCount);
                removingCount -= removing;
                totalRemoved[character - 'a'] += removing;

                if (removing < count)
                {
                    s.AddFirst(new RepeatingChar(character, count - removing));
                }
            }

            long score = 0;
            foreach (long removed in totalRemoved)
            {
                score += removed * removed;
            }

            return score;
        }

        readonly struct RepeatingChar
        {
            public char Character { get; }
            public int Count { get; }

            public RepeatingChar(char character, int count)
            {
                Character = character;
                Count = count;
            }

            public void Deconstruct(out char character, out int count)
            {
                character = Character;
                count = Count;
            }
        }
    }
}
