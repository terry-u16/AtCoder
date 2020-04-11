using AtCoderBeginnerContest157.Questions;
using AtCoderBeginnerContest157.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest157.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var card = new int[3][];
            var opened = new bool[3, 3];
            for (int i = 0; i < 3; i++)
            {
                card[i] = inputStream.ReadIntArray();
            }

            var n = inputStream.ReadInt();

            for (int i = 0; i < n; i++)
            {
                var b = inputStream.ReadInt();

                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        if (card[j][k] == b)
                        {
                            opened[j, k] = true;
                        }
                    }
                }
            }

            yield return IsBingo(opened) ? "Yes" : "No";
        }

        bool IsBingo(bool[,] card)
        {
            for (int i = 0; i < 3; i++)
            {
                if (Enumerable.Range(0, 3).All(j => card[i, j]))
                {
                    return true;
                }
                if (Enumerable.Range(0, 3).All(j => card[j, i]))
                {
                    return true;
                }
            }

            if (Enumerable.Range(0, 3).All(i => card[i, i] || card[2 - i, i]))
            {
                return true;
            }
            return false;
        }
    }
}
