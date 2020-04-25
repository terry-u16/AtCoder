using AtCoderBeginnerContest137.Questions;
using AtCoderBeginnerContest137.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Security.Cryptography.X509Certificates;

namespace AtCoderBeginnerContest137.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var kx = inputStream.ReadIntArray();
            var k = kx[0];
            var x = kx[1];
            yield return string.Join(" ", Enumerable.Range(x - k + 1, 2 * k - 1));
        }
    }
}
