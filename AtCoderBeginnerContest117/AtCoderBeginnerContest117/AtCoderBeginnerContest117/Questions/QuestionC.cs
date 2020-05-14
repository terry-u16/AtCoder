using AtCoderBeginnerContest117.Algorithms;
using AtCoderBeginnerContest117.Collections;
using AtCoderBeginnerContest117.Questions;
using AtCoderBeginnerContest117.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest117.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (pieces, _) = inputStream.ReadValue<int, int>();
            var checkpoints = inputStream.ReadIntArray();

            if (pieces >= checkpoints.Length)
            {
                yield return 0;
                yield break;
            }

            Array.Sort(checkpoints);
            var distances = (checkpoints, checkpoints.Skip(1)).Zip()
                                                              .Select(pair => pair.v2 - pair.v1)
                                                              .OrderBy(i => i)
                                                              .Take(checkpoints.Length - pieces)
                                                              .Sum();

            yield return distances;
        }
    }
}
