using Yorukatsu026.Questions;
using Yorukatsu026.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu026.Questions
{
    /// <summary>
    /// ABC095 C
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var abcxy = inputStream.ReadIntArray();
            var aPrice = abcxy[0];
            var bPrice = abcxy[1];
            var abPrice = abcxy[2];
            var aNeeded = abcxy[3];
            var bNeeded = abcxy[4];

            var aCount = 0;
            var bCount = 0;
            var abCount = 0;

            if (aPrice + bPrice <= 2 * abPrice)
            {
                aCount = aNeeded;
                bCount = bNeeded;
            }
            else
            {
                abCount = 2 * Math.Min(aNeeded, bNeeded);

                if (aNeeded > abCount / 2 && aPrice < 2 * abPrice)
                {
                    aCount = aNeeded - abCount / 2;
                }
                else if (bNeeded > abCount / 2 && bPrice < 2 * abPrice)
                {
                    bCount = bNeeded - abCount / 2;
                }
                else
                {
                    abCount = 2 * Math.Max(aNeeded, bNeeded);
                }
            }

            yield return aPrice * aCount + bPrice * bCount + abPrice * abCount;
        }
    }
}
