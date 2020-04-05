using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Atcoder.AtCoderBeginnerContest101.Extensions;

namespace Atcoder.AtCoderBeginnerContest101.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override string Solve(TextReader inputStream)
        {
            var n = inputStream.ReadLong();

            if (n % S(n) == 0)
            {
                return "Yes";
            }
            else
            {
                return "No";
            }
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
    }
}
