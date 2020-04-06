using AtCoderBeginnersSelectionReview.Questions;
using AtCoderBeginnersSelectionReview.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnersSelectionReview.Questions
{
    public class ABC085B : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            
            var hashSet = new HashSet<int>();
            
            for (int i = 0; i < n; i++)
            {
                hashSet.Add(inputStream.ReadInt());
            }

            yield return hashSet.Count;
        }
    }
}
