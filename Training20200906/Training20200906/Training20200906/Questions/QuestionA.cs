using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200906.Algorithms;
using Training20200906.Collections;
using Training20200906.Extensions;
using Training20200906.Numerics;
using Training20200906.Questions;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Training20200906.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc177/tasks/abc177_f
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (height, width) = inputStream.ReadValue<int, int>();
            var currentAndStarts = new RedBlackTree<CurrentAndStart>();
            var walkDistances = new RedBlackTree<int>();
            for (int i = 0; i < width; i++)
            {
                currentAndStarts.Add(new CurrentAndStart(i, i));
                walkDistances.Add(0);
            }

            for (int row = 0; row < height; row++)
            {
                var (l, r) = inputStream.ReadValue<int, int>();
                l--;

                var toRemove = new Stack<CurrentAndStart>();
                var maxStart = -1;
                foreach (var currentAndStart in currentAndStarts.EnumerateRange(l, r + 1))
                {
                    maxStart = Math.Max(maxStart, currentAndStart.Start);
                    walkDistances.Remove(currentAndStart.Current - currentAndStart.Start);
                    toRemove.Push(currentAndStart);
                }

                while (toRemove.Count > 0)
                {
                    currentAndStarts.Remove(toRemove.Pop());
                }

                if (maxStart >= 0 && r < width)
                {
                    walkDistances.Add(r - maxStart);
                    currentAndStarts.Add(new CurrentAndStart(r, maxStart));
                }

                if (walkDistances.Count > 0)
                {
                    yield return walkDistances.Min + row + 1;
                }
                else
                {
                    yield return -1;
                }
            }
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct CurrentAndStart : IComparable<CurrentAndStart>
        {
            public int Current { get; }
            public int Start { get; }

            public CurrentAndStart(int current, int start)
            {
                Current = current;
                Start = start;
            }

            public void Deconstruct(out int current, out int start) => (current, start) = (Current, Start);
            public override string ToString() => $"{nameof(Current)}: {Current}, {nameof(Start)}: {Start}";

            public int CompareTo([AllowNull] CurrentAndStart other) => Current - other.Current;
            public static implicit operator CurrentAndStart(int i) => new CurrentAndStart(i, 0);
        }

        /// <summary>
        /// <para>Red-Black tree which allows duplicated values (like multiset).</para>
        /// <para>Based on .NET Runtime https://github.com/dotnet/runtime/blob/master/src/libraries/System.Collections/src/System/Collections/Generic/SortedSet.cs </para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// 
        /// .NET Runtime
        ///   Copyright (c) .NET Foundation and Contributors
        ///   Released under the MIT license
        ///   https://github.com/dotnet/runtime/blob/master/LICENSE.TXT
        public class RedBlackTree<T> : ICollection<T>, IReadOnlyCollection<T> where T : IComparable<T>
        {
            public int Count { get; private set; }

            public bool IsReadOnly => false;

            protected Node _root;

            public T this[Index index]
            {
                get
                {
                    var i = index.GetOffset(Count);
                    if (unchecked((uint)i) >= Count)
                    {
                        throw new ArgumentOutOfRangeException(nameof(index));
                    }

                    var current = _root;
                    while (true)
                    {
                        var leftCount = current.Left?.Count ?? 0;
                        if (leftCount == i)
                        {
                            return current.Item;
                        }
                        else if (leftCount > i)
                        {
                            current = current.Left;
                        }
                        else
                        {
                            i -= leftCount + 1;
                            current = current.Right;
                        }
                    }
                }
            }

            /// <summary>
            /// 最小の要素を返します。要素が空の場合、default値を返します。
            /// </summary>
            public T Min
            {
                get
                {
                    if (_root == null)
                    {
                        return default;
                    }
                    else
                    {
                        var current = _root;
                        while (current.Left != null)
                        {
                            current = current.Left;
                        }
                        return current.Item;
                    }
                }
            }

            /// <summary>
            /// 最大の要素を返します。要素が空の場合、default値を返します。
            /// </summary>
            public T Max
            {
                get
                {
                    if (_root == null)
                    {
                        return default;
                    }
                    else
                    {
                        var current = _root;
                        while (current.Right != null)
                        {
                            current = current.Right;
                        }
                        return current.Item;
                    }
                }
            }

            #region ICollection<T> members

            public void Add(T item)
            {
                if (_root == null)
                {
                    _root = new Node(item, NodeColor.Black);
                    Count = 1;
                    return;
                }

                Node current = _root;
                Node parent = null;
                Node grandParent = null;        // 親、祖父はRotateで直接いじる
                Node greatGrandParent = null;   // 曾祖父はRotate後のつなぎ替えで使う（2回Rotateすると曾祖父がcurrentの親になる）

                var order = 0;
                while (current != null)
                {
                    current.Count++;    // 部分木サイズ++
                    order = item.CompareTo(current.Item);

                    if (current.Is4Node)
                    {
                        // 4-node (RBR) の場合は2-node x 2 (BRB) に変更
                        current.Split4Node();
                        if (Node.IsNonNullRed(parent))
                        {
                            // Splitの結果親と2連続でRRになったら修正
                            InsertionBalance(current, ref parent, grandParent, greatGrandParent);
                        }
                    }

                    greatGrandParent = grandParent;
                    grandParent = parent;
                    parent = current;
                    current = order <= 0 ? current.Left : current.Right;
                }

                var newNode = new Node(item, NodeColor.Red);
                if (order <= 0)
                {
                    parent.Left = newNode;
                }
                else
                {
                    parent.Right = newNode;
                }

                if (parent.IsRed)
                {
                    // Redの親がRedのときは修正
                    InsertionBalance(newNode, ref parent, grandParent, greatGrandParent);
                }

                _root.Color = NodeColor.Black;  // rootは常にBlack（Red->Blackとなったとき木全体の黒高さが1増える）
                Count++;
            }

            public void Clear()
            {
                _root = null;
                Count = 0;
            }

            public bool Contains(T item)
            {
                var current = _root;
                while (current != null)
                {
                    var order = item.CompareTo(current.Item);
                    if (order == 0)
                    {
                        return true;
                    }
                    else
                    {
                        current = order <= 0 ? current.Left : current.Right;
                    }
                }
                return false;
            }

            public void CopyTo(T[] array, int arrayIndex)
            {
                foreach (var value in this)
                {
                    array[arrayIndex++] = value;
                }
            }

            public bool Remove(T item)
            {
                // .NET RuntimeのSortedSet<T>はややトリッキーな実装をしている。
                // 値の検索を行う際、検索パスにある全ての2-nodeを3-nodeまたは4-nodeに変更しつつ進んでいくのだが、
                // 各ノードに部分木のサイズを持たせたい場合、実装が難しくなるため、一般的な実装を用いることとする。
                // （削除が失敗した場合はサイズが変わらず、成功した場合のみサイズが変更となるため、パスを保存しておきたいのだが、
                // 　木を回転させながら検索を行うと木の親子関係が変化するため、パスも都度変更となってしまう。）

                var found = false;
                Node current = _root;
                var parents = new Stack<Node>(2 * Log2(Count + 1));  // 親ノードのスタック
                parents.Push(null); // 番兵

                while (current != null)
                {
                    parents.Push(current);
                    var order = item.CompareTo(current.Item);
                    if (order == 0)
                    {
                        found = true;
                        break;
                    }
                    else
                    {
                        current = order < 0 ? current.Left : current.Right;
                    }
                }

                if (!found)
                {
                    // 見付からなければreturn
                    return false;
                }

                // 子を2つ持つ場合
                if (current.Left != null && current.Right != null)
                {
                    // 右部分木の最小ノードを探す
                    parents.Push(current.Right);
                    var minNode = GetMinNode(current.Right, parents);

                    // この最小値の値だけもらってしまい、あとはこの最小値ノードを削除することを考えればよい
                    current.Item = minNode.Item;
                    current = minNode;
                }

                // 通ったパス上にある部分木のサイズを全て1だけデクリメント
                parents.Pop();  // これは今から消すので不要
                Count--;
                foreach (var node in parents)
                {
                    if (node != null)
                    {
                        node.Count--;
                    }
                }

                // 切り離した部分をくっつける。子を2つ持つ場合については上で考えたため、子を0or1つ持つ場合を考えればよい
                // 二分木の黒高さが全て等しいという条件より、片方だけ2個以上伸びているということは起こり得ない
                var parent = parents.Peek();
                ReplaceChildOrRoot(parent, current, current.Left ?? current.Right);  // L/Rのどちらかnullでない方。どちらもnullならnullが入る

                // 削除するノードが赤の場合は修正不要
                if (current.IsRed)
                {
                    return true;
                }

                // つなぎ替えられた方の子
                current = current.Left ?? current.Right;

                while ((parent = parents.Pop()) != null)
                {
                    var toFix = DeleteBalance(current, parent, out var newParent);
                    ReplaceChildOrRoot(parents.Peek(), parent, newParent);

                    if (!toFix)
                    {
                        break;
                    }
                    current = newParent;
                }

                if (_root != null)
                {
                    _root.Color = NodeColor.Black;
                }
                return true;
            }

            private static Node GetMinNode(Node current, Stack<Node> parents)
            {
                while (current.Left != null)
                {
                    current = current.Left;
                    parents.Push(current);
                }
                return current;
            }

            public IEnumerator<T> GetEnumerator()
            {
                if (_root != null)
                {
                    var stack = new Stack<Node>(2 * Log2(Count + 1));
                    PushLeft(stack, _root);

                    while (stack.Count > 0)
                    {
                        var current = stack.Pop();
                        yield return current.Item;
                        PushLeft(stack, current.Right);
                    }
                }
            }

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();

            #endregion

            /// <summary>
            /// [<c>inclusiveMin</c>, <c>exclusiveMax</c>)を満たす要素を昇順に列挙します。
            /// </summary>
            /// <param name="inclusiveMin">区間の最小値（それ自身を含む）</param>
            /// <param name="exclusiveMax">区間の最大値（それ自身を含まない）</param>
            /// <returns></returns>
            public IEnumerable<T> EnumerateRange(T inclusiveMin, T exclusiveMax)
            {
                if (_root != null)
                {
                    var stack = new Stack<Node>(2 * Log2(Count + 1));
                    var current = _root;
                    while (current != null)
                    {
                        var order = current.Item.CompareTo(inclusiveMin);
                        if (order >= 0)
                        {
                            stack.Push(current);
                            current = current.Left;
                        }
                        else
                        {
                            current = current.Right;
                        }
                    }

                    while (stack.Count > 0)
                    {
                        current = stack.Pop();
                        var order = current.Item.CompareTo(exclusiveMax);
                        if (order >= 0)
                        {
                            yield break;
                        }
                        else
                        {
                            yield return current.Item;
                            PushLeft(stack, current.Right);
                        }
                    }
                }
            }

            private static void PushLeft(Stack<Node> stack, Node node)
            {
                while (node != null)
                {
                    stack.Push(node);
                    node = node.Left;
                }
            }

            private static int Log2(int n)
            {
                int result = 0;
                while (n > 0)
                {
                    result++;
                    n >>= 1;
                }
                return result;
            }

            // After calling InsertionBalance, we need to make sure `current` and `parent` are up-to-date.
            // It doesn't matter if we keep `grandParent` and `greatGrandParent` up-to-date, because we won't
            // need to split again in the next node.
            // By the time we need to split again, everything will be correctly set.
            private void InsertionBalance(Node current, ref Node parent, Node grandParent, Node greatGrandParent)
            {
                Debug.Assert(parent != null);
                Debug.Assert(grandParent != null);

                var parentIsOnRight = grandParent.Right == parent;
                var currentIsOnRight = parent.Right == current;

                Node newChildOfGreatGrandParent;
                if (parentIsOnRight == currentIsOnRight)
                {
                    // LL or RRなら1回転でOK
                    newChildOfGreatGrandParent = currentIsOnRight ? grandParent.RotateLeft() : grandParent.RotateRight();
                }
                else
                {
                    // LR or RLなら2回転
                    newChildOfGreatGrandParent = currentIsOnRight ? grandParent.RotateLeftRight() : grandParent.RotateRightLeft();
                    // 1回転ごとに1つ上に行くため、2回転させると曾祖父が親になる
                    // リンク先「挿入操作」を参照 http://wwwa.pikara.ne.jp/okojisan/rb-tree/index.html
                    parent = greatGrandParent;
                }

                // 祖父は親の子（1回転）もしくは自分の子（2回転）のいずれかになる
                // この時点で色がRRBもしくはBRRになっているため、BRBに修正
                // リンク先「挿入操作」を参照 http://wwwa.pikara.ne.jp/okojisan/rb-tree/index.html
                grandParent.Color = NodeColor.Red;
                newChildOfGreatGrandParent.Color = NodeColor.Black;

                ReplaceChildOrRoot(greatGrandParent, grandParent, newChildOfGreatGrandParent);
            }

            private bool DeleteBalance(Node current, Node parent, out Node newParent)
            {
                // 削除パターンは大きく分けて4つ
                // See: http://wwwa.pikara.ne.jp/okojisan/rb-tree/index.html

                // currentはもともと黒なので（黒でなければ修正する必要がないため）、兄弟はnullにはなり得ない
                var sibling = parent.GetSibling(current);
                if (sibling.IsBlack)
                {
                    if (Node.IsNonNullRed(sibling.Left) || Node.IsNonNullRed(sibling.Right))
                    {
                        var parentColor = parent.Color;
                        var siblingRedChild = Node.IsNonNullRed(sibling.Left) ? sibling.Left : sibling.Right;
                        var currentIsOnRight = parent.Right == current;
                        var siblingRedChildIsRight = sibling.Right == siblingRedChild;

                        if (currentIsOnRight != siblingRedChildIsRight)
                        {
                            // 1回転
                            parent.Color = NodeColor.Black;
                            sibling.Color = parentColor;
                            siblingRedChild.Color = NodeColor.Black;
                            newParent = currentIsOnRight ? parent.RotateRight() : parent.RotateLeft();
                        }
                        else
                        {
                            // 2回転
                            parent.Color = NodeColor.Black;
                            siblingRedChild.Color = parentColor;
                            newParent = currentIsOnRight ? parent.RotateLeftRight() : parent.RotateRightLeft();
                        }

                        return false;
                    }
                    else
                    {
                        var needToFix = parent.IsBlack;
                        parent.Color = NodeColor.Black;
                        sibling.Color = NodeColor.Red;
                        newParent = parent;
                        return needToFix;
                    }
                }
                else
                {
                    if (current == parent.Right)
                    {
                        newParent = parent.RotateRight();
                    }
                    else
                    {
                        newParent = parent.RotateLeft();
                    }

                    parent.Color = NodeColor.Red;
                    sibling.Color = NodeColor.Black;
                    DeleteBalance(current, parent, out var newChildOfParent);  // 再帰は1回限り
                    ReplaceChildOrRoot(newParent, parent, newChildOfParent);
                    return false;
                }
            }

            /// <summary>
            /// 親ノードの子を新しいものに差し替える。ただし親がいなければrootとする。
            /// </summary>
            /// <param name="parent"></param>
            /// <param name="child"></param>
            /// <param name="newChild"></param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private void ReplaceChildOrRoot(Node parent, Node child, Node newChild)
            {
                if (parent != null)
                {
                    parent.ReplaceChild(child, newChild);
                }
                else
                {
                    _root = newChild;
                }
            }

            #region Debugging

            [Conditional("DEBUG")]
            internal void PrintTree() => PrintTree(_root, 0);

            [Conditional("DEBUG")]
            private void PrintTree(Node node, int depth)
            {
                const int Space = 6;
                if (node != null)
                {
                    PrintTree(node.Right, depth + 1);
                    if (node.IsRed)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(string.Concat(Enumerable.Repeat(' ', Space * depth)));
                        Console.WriteLine($"{node.Item} ({node.Count})");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(string.Concat(Enumerable.Repeat(' ', Space * depth)));
                        Console.WriteLine($"{node.Item} ({node.Count})");
                    }
                    PrintTree(node.Left, depth + 1);
                }
            }

            [Conditional("DEBUG")]
            internal void AssertCorrectRedBrackTree() => AssertCorrectRedBrackTree(_root);

            private int AssertCorrectRedBrackTree(Node node)
            {
                if (node != null)
                {
                    // Redが2つ繋がっていないか？
                    Debug.Assert(!(node.IsRed && Node.IsNonNullRed(node.Left)));
                    Debug.Assert(!(node.IsRed && Node.IsNonNullRed(node.Right)));

                    // 左右の黒高さは等しいか？
                    var left = AssertCorrectRedBrackTree(node.Left);
                    var right = AssertCorrectRedBrackTree(node.Right);
                    Debug.Assert(left == right);
                    if (node.IsBlack)
                    {
                        left++;
                    }
                    return left;
                }
                else
                {
                    return 0;
                }
            }

            #endregion

            protected enum NodeColor : byte
            {
                Black,
                Red
            }

            [DebuggerDisplay("Item = {Item}, Size = {Count}")]
            protected sealed class Node
            {
                public T Item { get; set; }
                public Node Left { get; set; }
                public Node Right { get; set; }
                public NodeColor Color { get; set; }
                /// <summary>部分木のサイズ</summary>
                public int Count { get; set; }

                public bool IsBlack => Color == NodeColor.Black;
                public bool IsRed => Color == NodeColor.Red;
                public bool Is2Node => IsBlack && IsNullOrBlack(Left) && IsNullOrBlack(Right);
                public bool Is4Node => IsNonNullRed(Left) && IsNonNullRed(Right);

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                private void UpdateCount() => Count = GetCountOrDefault(Left) + GetCountOrDefault(Right) + 1;
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public static bool IsNonNullBlack(Node node) => node != null && node.IsBlack;
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public static bool IsNonNullRed(Node node) => node != null && node.IsRed;
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public static bool IsNullOrBlack(Node node) => node == null || node.IsBlack;
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                private static int GetCountOrDefault(Node node) => node?.Count ?? 0;    // C# 6.0 or later

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public Node(T item, NodeColor color)
                {
                    Item = item;
                    Color = color;
                    Count = 1;
                }

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public void Split4Node()
                {
                    Color = NodeColor.Red;
                    Left.Color = NodeColor.Black;
                    Right.Color = NodeColor.Black;
                }

                // 各種Rotateでは位置関係だけ修正する。色までは修正しない。
                // 親になったノード（部分木の根）を返り値とする。
                // childとかgrandChildとかは祖父（Rotate前の3世代中一番上）目線での呼び方
                public Node RotateLeft()
                {
                    // 右の子が自分の親になる
                    var child = Right;
                    Right = child.Left;
                    child.Left = this;
                    UpdateCount();
                    child.UpdateCount();
                    return child;
                }

                public Node RotateRight()
                {
                    // 左の子が自分の親になる
                    var child = Left;
                    Left = child.Right;
                    child.Right = this;
                    UpdateCount();
                    child.UpdateCount();
                    return child;
                }

                public Node RotateLeftRight()
                {
                    var child = Left;
                    var grandChild = child.Right;

                    Left = grandChild.Right;
                    grandChild.Right = this;
                    child.Right = grandChild.Left;
                    grandChild.Left = child;
                    UpdateCount();
                    child.UpdateCount();
                    grandChild.UpdateCount();
                    return grandChild;
                }

                public Node RotateRightLeft()
                {
                    var child = Right;
                    var grandChild = child.Left;

                    Right = grandChild.Left;
                    grandChild.Left = this;
                    child.Left = grandChild.Right;
                    grandChild.Right = child;
                    UpdateCount();
                    child.UpdateCount();
                    grandChild.UpdateCount();
                    return grandChild;
                }

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public void ReplaceChild(Node child, Node newChild)
                {
                    if (Left == child)
                    {
                        Left = newChild;
                    }
                    else
                    {
                        Right = newChild;
                    }
                }

                /// <summary>
                /// 兄弟を取得する。
                /// </summary>
                /// <param name="node"></param>
                /// <returns></returns>
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public Node GetSibling(Node node) => node == Left ? Right : Left;

                /// <summary>
                /// 左右の2-nodeを4-nodeにマージする。
                /// </summary>
                public void Merge2Nodes()
                {
                    Color = NodeColor.Black;
                    Left.Color = NodeColor.Red;
                    Right.Color = NodeColor.Red;
                }
            }
        }
    }
}
