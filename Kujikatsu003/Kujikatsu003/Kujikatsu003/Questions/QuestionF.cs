using Kujikatsu003.Questions;
using Kujikatsu003.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Kujikatsu003.Questions
{
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var candidates = Enumerable.Range(1, 30000).Where(i => i % 2 == 0 || i % 3 == 0).ToArray();

            if (n == 3)
            {
                yield return "2 5 63";
                yield break;
            }
            else if (n == 4)
            {
                yield return "2 5 20 63";
                yield break;
            }
            else if (n == 5)
            {
                yield return "2 5 20 30 63";
                yield break;
            }
            else
            {
                var answer = candidates.Take(n).ToList();
                var mod = answer.Sum() % 6;
                Tsujitsuma(answer);
                yield return string.Join(" ", answer);
            }
        }

        void Tsujitsuma(List<int> vs)
        {
            var mod = vs.Sum() % 6;
            var max = vs.Max();

            switch (mod)
            {
                case 2:
                    vs.Remove(8);
                    vs.Add(GetNext(max, 0));
                    break;
                case 3:
                    vs.Remove(9);
                    vs.Add(GetNext(max, 0));
                    break;
                case 5:
                    vs.Remove(9);
                    vs.Add(GetNext(max, 4));
                    break;
                default:
                    break;
            }
        }

        int GetNext(int n, int mod) => Enumerable.Range(n + 1, 10000).First(i => i % 6 == mod);
    }
}
