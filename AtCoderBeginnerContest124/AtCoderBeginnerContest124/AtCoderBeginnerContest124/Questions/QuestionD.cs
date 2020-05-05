using AtCoderBeginnerContest124.Questions;
using AtCoderBeginnerContest124.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest124.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nk = inputStream.ReadIntArray();
            var maxInverseCount = nk[1];
            var rawStates = inputStream.ReadLine().Select(c => c - '0').ToArray();

            var states = new List<State>();
            var lastState = rawStates[0];
            var streak = 1;
            if (lastState == 0)
            {
                states.Add(new State(true, 0));
            }
            foreach (var state in rawStates.Skip(1))
            {
                if (state == lastState)
                {
                    streak++;
                }
                else
                {
                    states.Add(new State(lastState == 1, streak));
                    streak = 1;
                    lastState = state;
                }
            }
            states.Add(new State(lastState == 1, streak));
            if (lastState == 0)
            {
                states.Add(new State(true, 0));
            }


            var validMaxInverseCount = Math.Min(maxInverseCount, states.Count(s => !s.IsHandstand));

            var current = states.Take(2 * validMaxInverseCount + 1).Sum(s => s.Count);
            var max = current;
            for (int begin = 2; begin + (2 * validMaxInverseCount) < states.Count; begin += 2)
            {
                var lastIndex = begin + (2 * validMaxInverseCount);
                current -= states[begin - 2].Count + states[begin - 1].Count;
                current += states[lastIndex - 1].Count + states[lastIndex].Count;
                max = Math.Max(max, current);
            }

            yield return max;
        }

        struct State
        {
            public bool IsHandstand { get; }
            public int Count { get; }

            public State(bool isHandstand, int count)
            {
                IsHandstand = isHandstand;
                Count = count;
            }
        }
    }
}
