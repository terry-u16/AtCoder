using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesRound606Div2.Questions;

namespace CodeforcesRound606Div2.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public override void Solve(IOManager io)
        {
            var tests = io.ReadInt();

            for (int t = 0; t < tests; t++)
            {
                SolveEach(io);
            }
        }

        private static void SolveEach(IOManager io)
        {
            var n = io.ReadInt();
            var counts = new int[2, 2];
            var s = new char[n][];

            var words = new Trie();

            for (int i = 0; i < s.Length; i++)
            {
                s[i] = io.ReadString().ToCharArray();
                var first = s[i][0] - '0';
                var last = s[i][^1] - '0';
                words.Add(s[i]);
                counts[first, last]++;
            }

            if (counts[0, 0] > 0 && counts[1, 1] > 0 && counts[0, 1] == 0 && counts[1, 0] == 0)
            {
                io.WriteLine(-1);
            }
            else if (Math.Abs(counts[0, 1] - counts[1, 0]) <= 1)
            {
                io.WriteLine(0);
            }
            else
            {
                var inv = false;

                if (counts[0, 1] < counts[1, 0])
                {
                    (counts[0, 0], counts[1, 1]) = (counts[1, 1], counts[0, 0]);
                    (counts[0, 1], counts[1, 0]) = (counts[1, 0], counts[0, 1]);
                    inv = true;
                }

                var queue = new Queue<int>();

                for (int i = 0; i < s.Length; i++)
                {
                    var first = s[i][0] - '0';
                    var last = s[i][^1] - '0';

                    if (inv)
                    {
                        first = (~first) & 1;
                        last = (~last) & 1;
                    }

                    if (first == 0 && last == 1)
                    {
                        s[i].AsSpan().Reverse();

                        if (!words.Contains(s[i]))
                        {
                            counts[0, 1]--;
                            counts[1, 0]++;
                            queue.Enqueue(i + 1);
                            if (Math.Abs(counts[0, 1] - counts[1, 0]) <= 1)
                            {
                                io.WriteLine(queue.Count);
                                io.WriteLine(queue, ' ');
                                return;
                            }
                        }
                    }
                }

                io.WriteLine(-1);
            }
        }

        public class Trie
        {
            private Stack<Node> _nodeStack = new Stack<Node>();

            /// <summary>
            /// 最大の文字サイズ。英小文字なら26。
            /// </summary>
            public int Count => Root.Count;

            public Node Root { get; private set; }

            /// <summary>
            /// <see cref="Trie"/>クラスのインスタンスを作成します。
            /// <example>
            /// <code>
            /// var trie = new <see cref="Trie"/>('a', 'z');
            /// </code>
            /// </example>
            /// </summary>
            public Trie()
            {
                Root = new Node();
            }

            public bool Add(string s) => Add(s.AsSpan());

            public bool Add(ReadOnlySpan<char> s)
            {
                var current = Root;
                _nodeStack.Clear();
                _nodeStack.Push(current);

                foreach (var c in s)
                {
                    if (current._children.TryGetValue(c, out var next))
                    {
                        current = next;
                    }
                    else
                    {
                        next = new Node();
                        current._children[c] = next;
                        current = next;
                    }
                    _nodeStack.Push(current);
                }

                if (current.Acceptable)
                {
                    return false;
                }
                else
                {
                    current.Acceptable = true;
                    while (_nodeStack.Count > 0)
                    {
                        _nodeStack.Pop().Count++;
                    }
                    return true;
                }
            }

            /// <summary>
            /// 指定した単語<paramref name="s"/>が含まれるかどうかを調べます。
            /// </summary>
            /// <param name="s">検索文字列</param>
            /// <param name="isPrefix">検索文字列自体が登録されていなくても、登録単語のprefixであればよいならばtrue, そうでないならfalse。</param>
            public bool Contains(string s, bool isPrefix = false) => Contains(s.AsSpan(), isPrefix);

            /// <summary>
            /// 指定した単語<paramref name="s"/>が含まれるかどうかを調べます。
            /// </summary>
            /// <param name="s">検索文字列</param>
            /// <param name="isPrefix">検索文字列自体が登録されていなくても、登録単語のprefixであればよいならばtrue, そうでないならfalse。</param>
            public bool Contains(ReadOnlySpan<char> s, bool isPrefix = false)
            {
                var current = Root;
                foreach (var c in s)
                {
                    if (current._children.TryGetValue(c, out var next))
                    {
                        current = next;
                    }
                    else
                    {
                        return false;
                    }
                }

                return current.Acceptable || isPrefix;
            }

            /// <summary>
            /// <paramref name="s"/>の空でないprefixのうち、登録されているものの一覧を取得します。
            /// </summary>
            /// <param name="s">検索文字列</param>
            public List<ReadOnlyMemory<char>> GetAllPrefix(string s) => GetAllPrefix(s.AsMemory());

            /// <summary>
            /// <paramref name="s"/>の空でないprefixのうち、登録されているものの一覧を取得します。
            /// </summary>
            /// <param name="s">検索文字列</param>
            public List<ReadOnlyMemory<char>> GetAllPrefix(ReadOnlyMemory<char> s)
            {
                var current = Root;
                var result = new List<ReadOnlyMemory<char>>();
                var i = 0;

                foreach (var c in s.Span)
                {
                    i++;

                    if (current._children.TryGetValue(c, out var next))
                    {
                        current = next;

                        if (current.Acceptable)
                        {
                            result.Add(s.Slice(0, i));
                        }
                    }
                    else
                    {
                        return result;
                    }
                }

                return result;
            }

            public void Clear() => Root = new Node();

            public class Node
            {
                // 親クラス以外には見えないようにしたいけど厳しい……
                internal readonly SortedDictionary<char, Node> _children;
                public int Count { get; internal set; }
                public bool Acceptable { get; internal set; }

                public Node()
                {
                    _children = new SortedDictionary<char, Node>();
                }
            }
        }
    }
}
