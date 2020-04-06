using AtCoderTypicalContest001.Questions;
using AtCoderTypicalContest001.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderTypicalContest001.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        char[,] maze;
        bool[,] seen;
        int h = 0;
        int w = 0;

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var hw = inputStream.ReadIntArray();
            h = hw[0];
            w = hw[1];
            maze = new char[w, h];
            seen = new bool[w, h];
            Tuple<int, int> start = null;
            Tuple<int, int> goal = null;

            for (int row = 0; row < h; row++)
            {
                var rowChar = inputStream.ReadLine().ToCharArray();

                for (int column = 0; column < w; column++)
                {
                    maze[column, row] = rowChar[column];

                    if (rowChar[column] == 's')
                    {
                        start = new Tuple<int, int>(column, row);
                    }
                    else if (rowChar[column] == 'g')
                    {
                        goal = new Tuple<int, int>(column, row);
                    }
                }
            }

            Search(start.Item1, start.Item2);

            if (seen[goal.Item1, goal.Item2])
            {
                yield return "Yes";
            }
            else
            {
                yield return "No";
            }
        }

        void Search(int x, int y)
        {
            bool isOutOfMaze = x < 0 || x >= w || y < 0 || y >= h;
            if (isOutOfMaze || maze[x, y] == '#' || seen[x, y])
            {
                return;
            }

            seen[x, y] = true;

            Search(x + 1, y);
            Search(x, y + 1);
            Search(x - 1, y);
            Search(x, y - 1);
        }
    }
}
