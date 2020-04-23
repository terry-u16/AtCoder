using Yorukatsu023.Questions;
using Yorukatsu023.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu023.Questions
{
    /// <summary>
    /// ABC097 D
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nm = inputStream.ReadIntArray();
            var n = nm[0];
            var m = nm[1];

            var p = inputStream.ReadIntArray().Select(i => i - 1).ToArray();
            var groups = p.Select(i => new UnionFindNode<int>(i)).ToArray();

            for (int i = 0; i < m; i++)
            {
                var xy = inputStream.ReadIntArray();
                var x = xy[0] - 1;
                var y = xy[1] - 1;
                groups[x].Unite(groups[y]);
            }

            var count = Enumerable.Range(0, n).Count(i => groups[i].IsInSameGroup(groups[p[i]]));
            yield return count;
        }
    }

    // See https://kumikomiya.com/competitive-programming-with-c-sharp/
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
