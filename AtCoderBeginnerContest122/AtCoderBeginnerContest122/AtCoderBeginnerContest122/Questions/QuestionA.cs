using AtCoderBeginnerContest122.Questions;
using AtCoderBeginnerContest122.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest122.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var b = inputStream.ReadLine()[0];

            switch (b)
            {
                case 'A':
                    yield return 'T';
                    break;
                case 'T':
                    yield return 'A';
                    break;
                case 'C':
                    yield return 'G';
                    break;
                case 'G':
                    yield return 'C';
                    break;
                default:
                    break;
            }
        }
    }
}
