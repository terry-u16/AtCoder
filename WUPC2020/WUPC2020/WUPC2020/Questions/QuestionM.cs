using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using WUPC2020.Extensions;
using WUPC2020.Questions;

namespace WUPC2020.Questions
{
    public class QuestionM : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var brightness = inputStream.ReadIntArray();
            var graph = Enumerable.Repeat(0, n).Select(_ => new List<int>()).ToArray();

            for (int i = 0; i < n - 1; i++)
            {
                var ab = inputStream.ReadIntArray();
                var a = ab[0] - 1;
                var b = ab[1] - 1;
                graph[a].Add(b);
                graph[b].Add(a);
            }

            var rerooting = new Rerooting<BeautifulnessAndBrightness>(graph, brightness.Select(b => new BeautifulnessAndBrightness(0, b)).ToArray());

            var result = rerooting.Solve();

            for (int i = 0; i < result.Length; i++)
            {
                yield return result[i].Beautifulness;
            }
        }
        struct BeautifulnessAndBrightness : ITreeDpState<BeautifulnessAndBrightness>
        {
            public long Beautifulness;
            public long Brightness;

            public BeautifulnessAndBrightness(long length, long brightness)
            {
                Beautifulness = length;
                Brightness = brightness;
            }

            public BeautifulnessAndBrightness Identity
            {
                get
                {
                    return new BeautifulnessAndBrightness();
                }
            }

            public BeautifulnessAndBrightness AddRoot()
            {
                return new BeautifulnessAndBrightness(Beautifulness + Brightness, Brightness);
            }

            public BeautifulnessAndBrightness Add(BeautifulnessAndBrightness other)
            {
                return this + other;
            }

            public BeautifulnessAndBrightness Subtract(BeautifulnessAndBrightness other)
            {
                return this - other;
            }

            public override string ToString()
            {
                return string.Format("Beautifulness:{0}, Brightness:{1}", Beautifulness, Brightness);
            }

            public static BeautifulnessAndBrightness operator +(BeautifulnessAndBrightness a, BeautifulnessAndBrightness b)
            {
                return new BeautifulnessAndBrightness(a.Beautifulness + b.Beautifulness, a.Brightness + b.Brightness);
            }

            public static BeautifulnessAndBrightness operator -(BeautifulnessAndBrightness a, BeautifulnessAndBrightness b)
            {
                return new BeautifulnessAndBrightness(a.Beautifulness - b.Beautifulness, a.Brightness - b.Brightness);
            }
        }

        public interface ITreeDpState<T>
        {
            T Identity { get; }
            T Add(T other);
            T Subtract(T other);
            T AddRoot();
        }

        public class Rerooting<T> where T : ITreeDpState<T>
        {
            readonly List<int>[] _graph;
            readonly T[] _dp;

            public Rerooting(List<int>[] graph, T[] init)
            {
                _graph = graph;
                _dp = init;
            }

            public T[] Solve()
            {
                Dfs(0, -1);
                Reroot(0, -1);
                return _dp;
            }

            private T Dfs(int current, int parent)
            {
                foreach (var next in _graph[current])
                {
                    if (next == parent)
                    {
                        continue;
                    }

                    _dp[current] = _dp[current].Add(Dfs(next, current));
                }
                return _dp[current].AddRoot();
            }

            private void Reroot(int current, int parent)
            {
                foreach (var next in _graph[current])
                {
                    if (next == parent)
                    {
                        continue;
                    }

                    var d = _dp[current].Subtract(_dp[next].AddRoot());
                    _dp[next] = _dp[next].Add(d.AddRoot());
                    Reroot(next, current);
                }
            }
        }
    }
}
