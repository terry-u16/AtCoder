using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Training20200620.Algorithms;
using Training20200620.Collections;
using Training20200620.Extensions;
using Training20200620.Numerics;
using Training20200620.Questions;

namespace Training20200620.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc015/tasks/abc015_4
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var maxWidth = inputStream.ReadInt();
            var (screenShotCount, maxScreenShotCount) = inputStream.ReadValue<int, int>();

            var screenShots = new ScreenShot[screenShotCount];
            for (int i = 0; i < screenShotCount; i++)
            {
                var (a, b) = inputStream.ReadValue<int, int>();
                screenShots[i] = new ScreenShot(a, b);
            }

            var importantness = new int[screenShotCount + 1, maxScreenShotCount + 1, maxWidth + 1];

            for (int ss = 0; ss < screenShotCount; ss++)
            {
                for (int taken = 0; taken <= maxScreenShotCount; taken++)
                {
                    for (int w = 0; w <= maxWidth; w++)
                    {
                        AlgorithmHelpers.UpdateWhenLarge(ref importantness[ss + 1, taken, w], importantness[ss, taken, w]);

                        var nextWidth = w + screenShots[ss].Width;
                        if (nextWidth <= maxWidth && taken < maxScreenShotCount)
                        {
                            AlgorithmHelpers.UpdateWhenLarge(ref importantness[ss + 1, taken + 1, nextWidth], importantness[ss, taken, w] + screenShots[ss].Importantness);
                        }
                    } 
                }
            }

            var maxImportantness = 0;
            for (int ss = 0; ss <= maxScreenShotCount; ss++)
            {
                for (int w = 0; w <= maxWidth; w++)
                {
                    AlgorithmHelpers.UpdateWhenLarge(ref maxImportantness, importantness[screenShotCount, ss, w]);
                }
            }

            yield return maxImportantness;
        }

        struct ScreenShot
        {
            public int Width { get; }
            public int Importantness { get; }

            public ScreenShot(int width, int importantness)
            {
                Width = width;
                Importantness = importantness;
            }

            public override string ToString() => $"{nameof(Width)}: {Width}, {nameof(Importantness)}: {Importantness}";
        }
    }
}
