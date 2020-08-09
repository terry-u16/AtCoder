using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesRound663Div2.Extensions;
using CodeforcesRound663Div2.Questions;

namespace CodeforcesRound663Div2.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            const int Mod = 1000000007;
            var n = inputStream.ReadInt();
            long result = 1;

            for (int i = 1; i <= n; i++)
            {
                result *= i;
                result %= Mod;
            }

            long subtract = 1;

            for (int i = 1; i <= n - 1; i++)
            {
                subtract *= 2;
                subtract %= Mod;
            }

            result = (result + Mod - subtract) % Mod; 

            yield return result;
        }
    }
}
