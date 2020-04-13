using EducationalDPContest.Questions;
using EducationalDPContest.Extensions;
using EducationalDPContest.Algorithms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EducationalDPContest.Questions
{
    public class QuestionH : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var hw = inputStream.ReadIntArray();
            var h = hw[0];
            var w = hw[1];
            var maze = new char[h][];

            for (int i = 0; i < h; i++)
            {
                maze[i] = inputStream.ReadLine().ToCharArray();
            }

            var pathCount = CreateInitializedArray(h, w, maze);

            pathCount[0, 0] = new Modular(1);
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    if (maze[i][j] != '#')
                    {
                        var up = i != 0 ? pathCount[i - 1, j] : new Modular(0);
                        var left = j != 0 ? pathCount[i, j - 1] : new Modular(0);
                        UpdateWhenLarge(ref pathCount[i, j], up + left);
                    }
                }
            }

            yield return pathCount[h - 1, w - 1].Value;
        }

        Modular[,] CreateInitializedArray(int h, int w, char[][] maze)
        {
            var pathCount = new Modular[h, w];

            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    pathCount[i, j] = new Modular(0);
                }
            }
            return pathCount;
        }
    }
}
