using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200805.Algorithms;
using Training20200805.Collections;
using Training20200805.Extensions;
using Training20200805.Numerics;
using Training20200805.Questions;

namespace Training20200805.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/agc041/tasks/agc041_b
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (problems, judges, votes, toSelected) = inputStream.ReadValue<int, int, int, int>();
            var scores = inputStream.ReadIntArray();
            Array.Sort(scores);
            yield return scores.Length - SearchExtensions.BoundaryBinarySearch(i => Check(i), scores.Length, -1);

            bool Check(int problem)
            {
                var newScore = scores[problem] + judges;
                var others = new List<int>();
                var passed = 0;
                for (int i = scores.Length - 1; i >= 0; i--)
                {
                    if (i != problem)
                    {
                        if (passed >= toSelected - 1)
                        {
                            if (scores[i] > newScore)
                            {
                                return false;
                            }
                            else
                            {
                                others.Add(scores[i]);
                            }
                        }
                        else
                        {
                            passed++;
                        }
                    }
                }

                long lastVotes = votes - passed - 1;
                long voted = 0;

                for (int i = 0; i < others.Count; i++)
                {
                    voted += Math.Min(newScore - others[i], judges);
                }

                return voted >= judges * lastVotes;
            }
        }
    }
}
