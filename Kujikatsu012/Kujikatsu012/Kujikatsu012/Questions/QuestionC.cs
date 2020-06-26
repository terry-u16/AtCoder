using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu012.Algorithms;
using Kujikatsu012.Collections;
using Kujikatsu012.Extensions;
using Kujikatsu012.Numerics;
using Kujikatsu012.Questions;
using Kujikatsu012.Graphs;

namespace Kujikatsu012.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/agc007/tasks/agc007_a
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        GridMapRightDown graph;
        
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (height, width) = inputStream.ReadValue<int, int>();
            var map = new char[height][];
            for (int i = 0; i < height; i++)
            {
                map[i] = inputStream.ReadLine().ToCharArray();
            }

            graph = new GridMapRightDown(height, width, map);

            yield return Dfs(new GridNode(0, 0, graph.Width)) ? "Possible" : "Impossible";
        }

        bool Dfs(GridNode current)
        {
            var nextDown = new GridNode(current.Row + 1, current.Column, graph.Width);
            var nextRight = new GridNode(current.Row, current.Column + 1, graph.Width);
            var beforeUp = new GridNode(current.Row - 1, current.Column, graph.Width);
            var beforeLeft = new GridNode(current.Row, current.Column - 1, graph.Width);


            if (current.Row == graph.Height - 1 && current.Column == graph.Width - 1 && (graph.CanEnter(beforeUp) ^ graph.CanEnter(beforeLeft)))
            {
                return true;
            }
            else
            {
                if ((graph.CanEnter(nextDown) ^ graph.CanEnter(nextRight)) && (current == new GridNode(0, 0, graph.Width) || graph.CanEnter(beforeUp) ^ graph.CanEnter(beforeLeft)))
                {
                    if (graph.CanEnter(nextDown))
                    {
                        return Dfs(nextDown);
                    }
                    else
                    {
                        return Dfs(nextRight);
                    }
                }
                else
                {
                    return false;
                }
            }
        }


        class GridMapRightDown : GridGraph
        {
            char[][] _map;

            public GridMapRightDown(int height, int width, char[][] map) : base(height, width, new[] { (1, 0), (0, 1) })
            {
                _map = map;
            }

            public override bool CanEnter(GridNode node)
            {
                return base.CanEnter(node) && _map[node.Row][node.Column] == '#';
            }
        }
    }
}
