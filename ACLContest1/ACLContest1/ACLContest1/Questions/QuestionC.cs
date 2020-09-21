using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ACLContest1.Algorithms;
using ACLContest1.Collections;
using ACLContest1.Numerics;
using ACLContest1.Questions;
using System.Diagnostics;
using System.Numerics;
using System.Reflection;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
using AtCoder;
using AtCoder.Internal;
using Math = System.Math;

namespace ACLContest1.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            const int MaxFlow = 100;
            var height = io.ReadInt();
            var width = io.ReadInt();

            var map = new char[height][];

            for (int i = 0; i < map.Length; i++)
            {
                map[i] = io.ReadString().ToCharArray();
            }

            int result = 0;
            var toFlow = 0;
            var additionalFlow = 0;

            var fromVss = new Dictionary<int, int>();
            var toVtt = new Dictionary<int, int>();

            // ラスト4つはs, t, S', T'
            var graph = new McfGraphInt(height * width + 4);
            int vS = height * width;
            int vT = height * width + 1;
            var vSS = height * width + 2;
            var vTT = height * width + 3;

            for (int row = 0; row < height; row++)
            {
                for (int column = 0; column < width; column++)
                {
                    var me = GetVertexIndex(row, column);
                    if (map[row][column] == 'o')
                    {
                        toFlow++;
                        graph.AddEdge(vS, me, 1, 0);
                    }
                    
                    if (map[row][column] != '#')
                    {
                        graph.AddEdge(me, vT, 1, 0);

                        if (InMap(row + 1, column) && map[row + 1][column] != '#')
                        {
                            var you = GetVertexIndex(row + 1, column);

                            if (fromVss.ContainsKey(you))
                            {
                                fromVss[you] += MaxFlow;
                            }
                            else
                            {
                                fromVss[you] = MaxFlow;
                            }

                            graph.AddEdge(you, me, MaxFlow, 1);

                            if (toVtt.ContainsKey(me))
                            {
                                toVtt[me] += MaxFlow;
                            }
                            else
                            {
                                toVtt[me] = MaxFlow;
                            }

                            additionalFlow += MaxFlow;
                            result -= MaxFlow;
                        }

                        if (InMap(row, column + 1) && map[row][column + 1] != '#')
                        {
                            var you = GetVertexIndex(row, column + 1);

                            if (fromVss.ContainsKey(you))
                            {
                                fromVss[you] += MaxFlow;
                            }
                            else
                            {
                                fromVss[you] = MaxFlow;
                            }

                            graph.AddEdge(you, me, MaxFlow, 1);

                            if (toVtt.ContainsKey(me))
                            {
                                toVtt[me] += MaxFlow;
                            }
                            else
                            {
                                toVtt[me] = MaxFlow;
                            }

                            additionalFlow += MaxFlow;
                            result -= MaxFlow;
                        }
                    }
                }
            }

            foreach (var (you, f) in fromVss)
            {
                graph.AddEdge(vSS, you, f, 0);
            }

            foreach (var (me, f) in toVtt)
            {
                graph.AddEdge(me, vTT, f, 0);
            }

            graph.AddEdge(vSS, vS, toFlow, 0);
            graph.AddEdge(vT, vTT, toFlow, 0);

            var (flow, cost) = graph.Flow(vSS, vTT, toFlow + additionalFlow);
            result += cost;
            io.WriteLine(-result);

            int GetVertexIndex(int row, int column) => row * width + column;
            bool InMap(int row, int column) => unchecked((uint)row < height && (uint)column < width);
        }
    }
}
