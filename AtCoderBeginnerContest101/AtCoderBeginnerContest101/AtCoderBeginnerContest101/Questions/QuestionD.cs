using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Atcoder.AtCoderBeginnerContest101.Extensions;

namespace Atcoder.AtCoderBeginnerContest101.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override string Solve(TextReader inputStream)
        {
            var k = inputStream.ReadInt();
            long previousSunuke = 0;
            double previousIPerSi = 1;

            for (int i = 0; i < k; i++)
            {
                long diffCandidate;
                long nextSunukeCandidate;
                long nextSi;
                long nextDiffCandidate;
                double iPerSi;
                
                diffCandidate = GetDiff(previousIPerSi);

                while (true)
                {
                    nextSunukeCandidate = previousSunuke + diffCandidate;
                    nextSi = S(nextSunukeCandidate);
                    iPerSi = (double)nextSunukeCandidate / nextSi;
                    nextDiffCandidate = GetDiff(iPerSi);

                    if (diffCandidate >= nextDiffCandidate)
                    {
                        break;
                    }
                    diffCandidate = nextDiffCandidate;
                }

                Console.WriteLine(nextSunukeCandidate);
                previousSunuke = nextSunukeCandidate;
                previousIPerSi = iPerSi;
            }

            return string.Empty;
        }

        long S(long n)
        {
            long sum = 0;
            while (n != 0)
            {
                sum += n % 10;
                n /= 10;
            }

            return sum;
        }

        long GetDiff(double iPerSi)
        {
            var power = (long)Math.Ceiling(Math.Log10(iPerSi) - double.Epsilon);
            return (long)Math.Pow(10L, power);
        }
    }
}
