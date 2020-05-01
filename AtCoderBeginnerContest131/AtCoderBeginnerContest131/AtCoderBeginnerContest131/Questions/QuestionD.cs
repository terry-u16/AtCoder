using AtCoderBeginnerContest131.Questions;
using AtCoderBeginnerContest131.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest131.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var works = new Work[n];

            for (int i = 0; i < n; i++)
            {
                var ab = inputStream.ReadIntArray();
                works[i] = new Work(ab[0], ab[1]);
            }

            Array.Sort(works);

            long time = 0;
            foreach (var work in works)
            {
                time += work.ManHour;
                if (time > work.Deadline)
                {
                    yield return "No";
                    yield break;
                }
            }
            yield return "Yes";
        }
    }

    struct Work : IComparable<Work>
    {
        public int ManHour { get; }
        public int Deadline { get; }

        public Work(int manHour, int deadline)
        {
            ManHour = manHour;
            Deadline = deadline;
        }

        public int CompareTo(Work other) => Deadline.CompareTo(other.Deadline);

        public override string ToString() => $"ManHour:{ManHour}, Deadline:{Deadline}";
    }
}
