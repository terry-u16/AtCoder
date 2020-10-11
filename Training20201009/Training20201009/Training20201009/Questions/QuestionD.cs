using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20201009.Algorithms;
using Training20201009.Collections;
using Training20201009.Numerics;
using Training20201009.Questions;
using System.Numerics;
using System.Runtime.Intrinsics.X86;
using AtCoder.Internal;

namespace Training20201009.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var n = io.ReadInt();

            var trie = new Trie('a', 'z');
            var s = new string[n];

            for (int i = 0; i < s.Length; i++)
            {
                s[i] = string.Concat(io.ReadString().Reverse());
                trie.Add(s[i]);
            }

            long count = 0;

            foreach (var si in s)
            {
                count += GetCount(si);
            }

            io.WriteLine(count);

            int GetCount(string s)
            {
                Span<int> lasts = stackalloc int[26];
                var count = 0;

                foreach (var c in s)
                {
                    lasts[c - 'a']++;
                }

                var current = trie.Root;
                foreach (var c in s)
                {
                    for (int i = 0; i < current.Children.Length; i++)
                    {
                        if (lasts[i] > 0 && current.Children[i] != null && current.Children[i].Acceptable)
                        {
                            count++;
                        }
                    }
                    current = current.Children[c - 'a'];
                    lasts[c - 'a']--;
                }

                return count - 1;
            }
        }
    }

    public class Trie
    {
        private Stack<Node> _nodeStack = new Stack<Node>();

        /// <summary>
        /// 最大の文字サイズ。英小文字なら26。
        /// </summary>
        public int MaxChar { get; }
        public char StartChar { get; }
        public char EndChar { get; }
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
        public Trie(char inclusiveStartChar, char inclusiveEndChar)
        {
            if (inclusiveStartChar > inclusiveEndChar)
            {
                throw new ArgumentException();
            }

            StartChar = inclusiveStartChar;
            EndChar = inclusiveEndChar;
            MaxChar = inclusiveEndChar - inclusiveStartChar + 1;
            Root = new Node(MaxChar);
        }

        public bool Add(string s) => Add(s.AsSpan());

        public bool Add(ReadOnlySpan<char> s)
        {
            var current = Root;
            _nodeStack.Clear();
            _nodeStack.Push(current);

            foreach (var c in s)
            {
                var index = c - StartChar;
                current = current._children[index] ??= new Node(MaxChar);
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
                var index = c - StartChar;

                if (current._children[index] == null)
                {
                    return false;
                }
                else
                {
                    current = current._children[index];
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
                var index = c - StartChar;

                if (current._children[index] == null)
                {
                    return result;
                }
                else
                {
                    current = current._children[index];

                    if (current.Acceptable)
                    {
                        result.Add(s.Slice(0, i));
                    }
                }
            }

            return result;
        }

        public void Clear() => Root = new Node(MaxChar);

        public class Node
        {
            // 親クラス以外には見えないようにしたいけど厳しい……
            internal readonly Node[] _children;
            public ReadOnlySpan<Node> Children => _children;
            public int Count { get; internal set; }
            public bool Acceptable { get; internal set; }

            public Node(int maxChar)
            {
                _children = new Node[maxChar];
            }
        }
    }
}
