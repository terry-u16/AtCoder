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
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            _ = inputStream.ReadInt();
            var l = inputStream.ReadIntArray();
            Array.Sort(l);
            Array.Reverse(l);
            var canComposePolygon = l[0] < l.Skip(1).Sum();
            yield return canComposePolygon ? "Yes" : "No";
        }
    }
}
