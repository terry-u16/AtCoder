using Training20200528.Questions;
using Training20200528.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Training20200528.Questions
{
    /// <summary>
    /// ABC080 D
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nc = inputStream.ReadIntArray();
            var totalContents = nc[0];
            var channelCounts = nc[1];
            var contents = Enumerable.Repeat(0, channelCounts).Select(_ => new List<Content>()).ToArray();

            for (int i = 0; i < totalContents; i++)
            {
                var stc = inputStream.ReadIntArray();
                contents[stc[2] - 1].Add(new Content(stc[0], stc[1]));
            }

            var decks = new int[100001];
            foreach (var contentsInChannel in contents)
            {
                contentsInChannel.Sort();
                var lastEnd = -10000;
                foreach (var content in contentsInChannel)
                {
                    if (lastEnd == content.Begin)
                    {
                        decks[content.Begin]++;
                    }
                    else
                    {
                        decks[content.Begin - 1]++;
                    }
                    decks[content.End]--;
                    lastEnd = content.End;
                }
            }

            for (int t = 0; t + 1 < decks.Length; t++)
            {
                decks[t + 1] += decks[t];
            }

            yield return decks.Max();
        }

        struct Content : IComparable<Content>
        {
            public int Begin { get; }
            public int End { get; }

            public Content(int begin, int end)
            {
                Begin = begin;
                End = end;
            }

            public int CompareTo(Content other) => Begin.CompareTo(other.Begin);
        }
    }
}
