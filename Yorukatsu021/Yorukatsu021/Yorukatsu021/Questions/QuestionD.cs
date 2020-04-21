using Yorukatsu021.Questions;
using Yorukatsu021.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu021.Questions
{
    /// <summary>
    /// ABC157 D
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nmk = inputStream.ReadIntArray();
            var n = nmk[0];
            var m = nmk[1];
            var k = nmk[2];
            var people = Enumerable.Range(0, n).Select(i => new UnionFindNode<int>(i)).ToArray();

            var frientCount = new int[n];
            var blockCount = new int[n];

            for (int i = 0; i < m; i++)
            {
                var ab = inputStream.ReadIntArray().Select(j => j - 1).ToArray();
                var a = ab[0];
                var b = ab[1];
                people[a].Unite(people[b]);
                frientCount[a]++;
                frientCount[b]++;
            }

            for (int i = 0; i < k; i++)
            {
                var cd = inputStream.ReadIntArray().Select(j => j - 1).ToArray();
                var c = cd[0];
                var d = cd[1];
                if (people[c].IsInSameGroup(people[d]))
                {
                    blockCount[c]++;
                    blockCount[d]++;
                }
            }

            yield return string.Join(" ", Enumerable.Range(0, n).Select(i => people[i].GetGroupSize() - frientCount[i] - blockCount[i] - 1));   // 自分も引く
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
