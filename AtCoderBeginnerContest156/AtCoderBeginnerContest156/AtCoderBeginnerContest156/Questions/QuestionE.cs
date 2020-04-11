using AtCoderBeginnerContest156.Questions;
using AtCoderBeginnerContest156.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest156.Questions
{
    public class QuestionE : AtCoderQuestionBase
    {
        int[] counts;
        int[] fac;
        

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nk = inputStream.ReadIntArray();
            var n = nk[0];
            var k = nk[1];

            counts = new int[n];
            fac = new int[n];

            throw new NotImplementedException();
        }

        void Search()
        {
            int current = 0;

        }
    }
}
