using Yorukatsu018.Questions;
using Yorukatsu018.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu018.Questions
{
    /// <summary>
    /// ABC075 C 復習
    /// </summary>
    public class QuestionD_UnionFind : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nm = inputStream.ReadIntArray();
            var n = nm[0];
            var m = nm[1];
            var inputs = new int[m][];

            for (int i = 0; i < m; i++)
            {
                var ab = inputStream.ReadIntArray().Select(x => x - 1).ToArray();
                inputs[i] = ab;
            }

            var bridgesCount = 0;

            foreach (var except in inputs)
            {
                var nodes = Enumerable.Range(0, n).Select(i => new UnionFindNode<int>(i)).ToArray();
                foreach (var input in inputs.Where(p => !p.SequenceEqual(except)))
                {
                    nodes[input[0]].Unite(nodes[input[1]]);
                }
                if (nodes.Any(node => !node.IsInSameGroup(nodes[0])))
                {
                    bridgesCount++;
                }
            }

            yield return bridgesCount;
        }
    }

    public class UnionFindNode<T>
    {
        private int _height;        // rootのときのみ有効
        private int _groupSize;     // 同上
        private UnionFindNode<T> _parent;
        public T Item { get; }

        public UnionFindNode(T item)
        {
            _height = 0;
            _groupSize = 1;
            _parent = this;
            Item = item;
        }

        private UnionFindNode<T> FindRoot()
        {
            if (_parent != this) // not ref equals
            {
                var root = _parent.FindRoot();
                _parent = root;
            }

            return _parent;
        }

        public int GetGroupSize() => FindRoot()._groupSize;

        public void Unite(UnionFindNode<T> other)
        {
            var thisRoot = this.FindRoot();
            var otherRoot = other.FindRoot();

            if (thisRoot == otherRoot)
            {
                return;
            }

            if (thisRoot._height < otherRoot._height)
            {
                thisRoot._parent = otherRoot;
                otherRoot._groupSize += thisRoot._groupSize;
                otherRoot._height = Math.Max(thisRoot._height + 1, otherRoot._height);
            }
            else
            {
                otherRoot._parent = thisRoot;
                thisRoot._groupSize += otherRoot._groupSize;
                thisRoot._height = Math.Max(otherRoot._height + 1, thisRoot._height);
            }
        }

        public bool IsInSameGroup(UnionFindNode<T> other) => this.FindRoot() == other.FindRoot();

        public override string ToString() => $"{Item} root:{FindRoot().Item}";
    }
}
