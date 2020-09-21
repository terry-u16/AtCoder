using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using ACPC2020Day2.Questions;
using System.Diagnostics;

namespace ACPC2020Day2.Questions
{
    public class QuestionG : AtCoderQuestionBase
    {
        const int INF = 1 << 28;

        public override IEnumerable<object> Solve(TextReader input)
        {            
            var n = int.Parse(input.ReadLine());
            var coord = new Coordinate[n];

            for (int i = 0; i < coord.Length; i++)
            {
                coord[i] = ReadPoint(input);
            }

            var start = coord[0];
            var goal = coord[coord.Length - 1];

            RedBlackTree<Line> verticals, horizontals;
            Initialize(coord, out verticals, out horizontals);

            var distV = new Dictionary<int, int>();
            var distH = new Dictionary<int, int>();
            var toGoalV = new Dictionary<int, int>();
            var toGoalH = new Dictionary<int, int>();
            var toRemove = new Stack<Line>();
            var bfsQueue = new Deque<BfsState>(coord.Length + 10);

            // 各線分 -> goal
            foreach (var vLine in verticals)
            {
                if (vLine.Points.Min <= goal.Y && goal.Y <= vLine.Points.Max)
                {
                    if (vLine.Points.Contains(goal.Y))
                    {
                        toGoalV[vLine.Coord] = 0;
                    }
                    else
                    {
                        toGoalV[vLine.Coord] = 1;
                    }
                }
            }

            foreach (var hLine in horizontals)
            {
                if (hLine.Points.Min <= goal.X && goal.X <= hLine.Points.Max)
                {
                    if (hLine.Points.Contains(goal.X))
                    {
                        toGoalH[hLine.Coord] = 0;
                    }
                    else
                    {
                        toGoalH[hLine.Coord] = 1;
                    }
                }
            }

            // start -> 各線分
            foreach (var vLine in verticals)
            {
                if (vLine.Points.Min <= start.Y && start.Y <= vLine.Points.Max)
                {
                    toRemove.Push(vLine);
                    if (vLine.Points.Contains(start.Y))
                    {
                        distV[vLine.Coord] = 0;
                        bfsQueue.EnqF(new BfsState(0, vLine, Dir.Ver));
                    }
                    else
                    {
                        distV[vLine.Coord] = 1;
                        bfsQueue.EnqL(new BfsState(1, vLine, Dir.Ver));
                    }
                }
            }

            while (toRemove.Count > 0)
            {
                verticals.Remove(toRemove.Pop());
            }

            foreach (var hLine in horizontals)
            {
                if (hLine.Points.Min <= start.X && start.X <= hLine.Points.Max)
                {
                    toRemove.Push(hLine);
                    if (hLine.Points.Contains(start.X))
                    {
                        distH[hLine.Coord] = 0;
                        bfsQueue.EnqF(new BfsState(0, hLine, Dir.Hor));
                    }
                    else
                    {
                        distH[hLine.Coord] = 1;
                        bfsQueue.EnqL(new BfsState(1, hLine, Dir.Hor));
                    }
                }
            }

            while (toRemove.Count > 0)
            {
                verticals.Remove(toRemove.Pop());
            }

            // BFS
            while (bfsQueue.Count > 0)
            {
                var current = bfsQueue.DequeueFirst();

                if (current.LineDirection == Dir.Ver)
                {
                    // | -> ー
                    foreach (var hLine in horizontals)
                    {
                        // 交叉する場合
                        if (Intersects(hLine.Points.Min, hLine.Points.Max, current.Line.Coord, 
                            current.Line.Points.Min, current.Line.Points.Max, hLine.Coord))
                        {
                            toRemove.Push(hLine);
                            var currentDist = distV[current.Line.Coord];
                            // 点を共有している
                            if (current.Line.Points.Contains(hLine.Coord) || hLine.Points.Contains(current.Line.Coord))
                            {
                                bfsQueue.EnqF(new BfsState(currentDist, hLine, Dir.Hor));
                            }
                            else
                            {
                                bfsQueue.EnqL(new BfsState(currentDist + 1, hLine, Dir.Hor));
                            }
                        }
                    }

                    while (toRemove.Count > 0)
                    {
                        horizontals.Remove(toRemove.Pop());
                    }
                }
                else
                {
                    // ー -> |
                    foreach (var vLine in verticals)
                    {
                        // 交叉する場合
                        if (Intersects(current.Line.Points.Min, current.Line.Points.Max, vLine.Coord,
                            vLine.Points.Min, vLine.Points.Max, current.Line.Coord))
                        {
                            toRemove.Push(vLine);
                            var currentDistance = distH[current.Line.Coord];
                            // 点を共有している
                            if (current.Line.Points.Contains(vLine.Coord) || vLine.Points.Contains(current.Line.Coord))
                            {
                                bfsQueue.EnqF(new BfsState(currentDistance, vLine, Dir.Ver));
                            }
                            else
                            {
                                bfsQueue.EnqL(new BfsState(currentDistance + 1, vLine, Dir.Ver));
                            }
                        }
                    }

                    while (toRemove.Count > 0)
                    {
                        horizontals.Remove(toRemove.Pop());
                    }
                }
            }

            var minDistance = INF;

            foreach (var to in toGoalV)
            {
                int d;
                if (distV.TryGetValue(to.Key, out d))
                {
                    minDistance = Math.Min(minDistance, to.Value + d);
                }
            }

            foreach (var to in toGoalH)
            {
                int d;
                if (distH.TryGetValue(to.Key, out d))
                {
                    minDistance = Math.Min(minDistance, to.Value + d);
                }
            }

            if (minDistance < INF)
            {
                yield return minDistance;
            }
            else
            {
                yield return -1;
            }
        }

        private static void Initialize(Coordinate[] coords, out RedBlackTree<Line> vs, out RedBlackTree<Line> hors)
        {
            vs = new RedBlackTree<Line>();
            hors = new RedBlackTree<Line>();

            Array.Sort(coords, (a, b) => a.X - b.X);
            var streak = 0;
            var x = int.MinValue;

            var queue = new Queue<int>();
            for (int i = 0; i < coords.Length; i++)
            {
                if (x == coords[i].X)
                {
                    streak++;
                    queue.Enqueue(coords[i].Y);
                }
                else
                {
                    // 同じX座標に頂点が2個以上あるとき
                    if (streak >= 2)
                    {
                        var line = new Line(x);
                        while (queue.Count > 0)
                        {
                            // Y座標を追加
                            line.Points.Add(queue.Dequeue());
                        }
                        vs.Add(line);
                    }
                    else
                    {
                        queue.Clear();
                    }

                    x = coords[i].X;
                    queue.Enqueue(coords[i].Y);
                    streak = 1;
                }
            }

            if (streak >= 2)
            {
                var line = new Line(x);
                while (queue.Count > 0)
                {
                    // Y座標を追加
                    line.Points.Add(queue.Dequeue());
                }
                vs.Add(line);
            }

            queue.Clear();
            streak = 0;
            var y = int.MinValue;
            Array.Sort(coords, (a, b) => a.Y - b.Y);

            for (int i = 0; i < coords.Length; i++)
            {
                if (y == coords[i].Y)
                {
                    streak++;
                    queue.Enqueue(coords[i].X);
                }
                else
                {
                    // 同じX座標に頂点が2個以上あるとき
                    if (streak >= 2)
                    {
                        var line = new Line(y);
                        while (queue.Count > 0)
                        {
                            // X座標を追加
                            line.Points.Add(queue.Dequeue());
                        }
                        hors.Add(line);
                    }
                    else
                    {
                        queue.Clear();
                    }

                    y = coords[i].Y;
                    queue.Enqueue(coords[i].X);
                    streak = 1;
                }
            }

            if (streak >= 2)
            {
                var line = new Line(y);
                while (queue.Count > 0)
                {
                    // X座標を追加
                    line.Points.Add(queue.Dequeue());
                }
                hors.Add(line);
            }
        }

        private Coordinate ReadPoint(TextReader inputStream)
        {
            var xy = inputStream.ReadLine().Split(' ').Select(int.Parse).ToArray();
            return new Coordinate(xy[0], xy[1]);
        }

        private bool Intersects(int minX, int maxX, int x, int minY, int maxY, int y)
        {
            return minX <= x && x <= maxX && minY <= y && y <= maxY;
        }

        struct Coordinate
        {
            public int X;
            public int Y;

            public Coordinate(int x, int y)
            {
                X = x;
                Y = y;
            }

            public override string ToString()
            {
                return string.Format("({0}, {1})", X, Y);
            }
        }

        struct Line : IComparable<Line>
        {
            public int Coord;
            public RedBlackTree<int> Points;

            public Line(int coordintae)
            {
                Coord = coordintae;
                Points = new RedBlackTree<int>();
            }

            public int CompareTo(Line other)
            {
                return Coord - other.Coord;
            }

            public override string ToString()
            {
                return Coord.ToString();
            }
        }

        struct BfsState
        {
            public int Distance;
            public Line Line;
            public Dir LineDirection;

            public BfsState(int distance, Line line, Dir lineDirection)
            {
                Distance = distance;
                Line = line;
                LineDirection = lineDirection;
            }
        }

        enum Dir
        {
            Ver,
            Hor
        }
    }

    public class Deque<T>
    {
        public int Count;
        private T[] _data;
        private int _first;
        private int _mask;

        public Deque() : this(4) { }

        public Deque(int minCapacity)
        {
            if (minCapacity <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            var capacity = GetPow2Over(minCapacity);
            _data = new T[capacity];
            _first = 0;
            _mask = capacity - 1;
        }

        public void EnqF(T item)
        {
            _first = (_first - 1) & _mask;
            _data[_first] = item;
            Count++;
        }

        public void EnqL(T item)
        {
            _data[(_first + Count++) & _mask] = item;
        }

        public T DequeueFirst()
        {
            if (Count == 0)
            {
                TIOEx("Queueが空です。");
            }

            var value = _data[_first];
            _data[_first++] = default(T);
            _first &= _mask;
            Count--;
            return value;
        }

        private void TIOEx(string message)
        {
            throw new InvalidOperationException(message);
        }

        private int GetPow2Over(int n)
        {
            n--;
            var result = 1;
            while (n != 0)
            {
                n >>= 1;
                result <<= 1;
            }
            return result;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                var offset = (_first + i) & _mask;
                yield return _data[offset];
            }
        }
    }


    public class RedBlackTree<T> : IEnumerable<T> where T : IComparable<T>
    {
        public int Count { get; private set; }

        public bool IsReadOnly => false;

        protected Node _root;

        public T this[int i]
        {
            get
            {
                if (unchecked((uint)i) >= Count)
                {
                    throw new ArgumentOutOfRangeException();
                }

                var current = _root;
                while (true)
                {
                    var leftCount = current.Left != null ? current.Left.Count : 0;

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

        public T Min
        {
            get
            {
                if (_root == null)
                {
                    return default(T);
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

        public T Max
        {
            get
            {
                if (_root == null)
                {
                    return default(T);
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

            Node c = _root;
            Node p = null;
            Node gp = null;  
            Node ggp = null; 

            var order = 0;
            while (c != null)
            {
                c.Count++;
                order = item.CompareTo(c.Item);

                if (c.Is4Node)
                {
                    c.Split4Node();
                    if (Node.INNOR(p))
                    {
                        IBal(c, ref p, gp, ggp);
                    }
                }

                ggp = gp;
                gp = p;
                p = c;
                c = order <= 0 ? c.Left : c.Right;
            }

            var newNode = new Node(item, NodeColor.Red);
            if (order <= 0)
            {
                p.Left = newNode;
            }
            else
            {
                p.Right = newNode;
            }

            if (p.IsRed)
            {
                IBal(newNode, ref p, gp, ggp);
            }

            _root.Color = NodeColor.Black; 
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

        public bool Remove(T item)
        {
            var found = false;
            Node c = _root;
            var p = new Stack<Node>(2 * Log2(Count + 1));
            p.Push(null); // 番兵

            while (c != null)
            {
                p.Push(c);
                var order = item.CompareTo(c.Item);
                if (order == 0)
                {
                    found = true;
                    break;
                }
                else
                {
                    c = order < 0 ? c.Left : c.Right;
                }
            }

            if (!found)
            {
                return false;
            }

            if (c.Left != null && c.Right != null)
            {
                p.Push(c.Right);
                var mn = GetMinNode(c.Right, p);

                c.Item = mn.Item;
                c = mn;
            }

            p.Pop();
            Count--;
            foreach (var node in p)
            {
                if (node != null)
                {
                    node.Count--;
                }
            }
            var parent = p.Peek();
            RCOR(parent, c, c.Left ?? c.Right);

            if (c.IsRed)
            {
                return true;
            }

            c = c.Left == null ? c.Left : c.Right;

            while ((parent = p.Pop()) != null)
            {
                Node newParent;
                var toFix = DB(c, parent, out newParent);
                RCOR(p.Peek(), parent, newParent);

                if (!toFix)
                {
                    break;
                }
                c = newParent;
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

        private void IBal(Node c, ref Node p, Node gp, Node ggp)
        {
            Debug.Assert(p != null);
            Debug.Assert(gp != null);

            var pior = gp.Right == p;
            var cior = p.Right == c;

            Node newchild;
            if (pior == cior)
            {
                newchild = cior ? gp.RotL() : gp.RotR();
            }
            else
            {
                newchild = cior ? gp.RotLR() : gp.RotRL();
                p = ggp;
            }

            gp.Color = NodeColor.Red;
            newchild.Color = NodeColor.Black;

            RCOR(ggp, gp, newchild);
        }

        private bool DB(Node c, Node p, out Node np)
        {
            var sibling = p.GetSibling(c);
            if (sibling.IsBlack)
            {
                if (Node.INNOR(sibling.Left) || Node.INNOR(sibling.Right))
                {
                    var pc = p.Color;
                    var src = Node.INNOR(sibling.Left) ? sibling.Left : sibling.Right;
                    var cior = p.Right == c;
                    var srcir = sibling.Right == src;

                    if (cior != srcir)
                    {
                        p.Color = NodeColor.Black;
                        sibling.Color = pc;
                        src.Color = NodeColor.Black;
                        np = cior ? p.RotR() : p.RotL();
                    }
                    else
                    {
                        // 2回転
                        p.Color = NodeColor.Black;
                        src.Color = pc;
                        np = cior ? p.RotLR() : p.RotRL();
                    }

                    return false;
                }
                else
                {
                    var needToFix = p.IsBlack;
                    p.Color = NodeColor.Black;
                    sibling.Color = NodeColor.Red;
                    np = p;
                    return needToFix;
                }
            }
            else
            {
                if (c == p.Right)
                {
                    np = p.RotR();
                }
                else
                {
                    np = p.RotL();
                }

                p.Color = NodeColor.Red;
                sibling.Color = NodeColor.Black;
                Node newChildOfParent;
                DB(c, p, out newChildOfParent);
                RCOR(np, p, newChildOfParent);
                return false;
            }
        }

        private void RCOR(Node parent, Node child, Node newChild)
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

        protected enum NodeColor : byte
        {
            Black,
            Red
        }

        protected sealed class Node
        {
            public T Item;
            public Node Left;
            public Node Right;
            public NodeColor Color;
            public int Count;

            public bool IsBlack
            {
                get
                {
                    return Color == NodeColor.Black;
                }
            }

            public bool IsRed
            {
                get
                {
                    return Color == NodeColor.Red;
                }
            }

            public bool Is2Node
            {
                get
                {
                    return IsBlack && INOB(Left) && INOB(Right);
                }
            }

            public bool Is4Node
            {
                get
                {
                    return INNOR(Left) && INNOR(Right);
                }
            }

            private void Update()
            {
                Count = GetCount(Left) + GetCount(Right) + 1;
            }

            public static bool INNB(Node node)
            {
                return node != null && node.IsBlack;
            }

            public static bool INNOR(Node node)
            {
                return node != null && node.IsRed;
            }

            public static bool INOB(Node node)
            {
                return node == null || node.IsBlack;
            }

            private static int GetCount(Node node)
            {
                return node?.Count ?? 0;    // C# 6.0 or later
            }

            public Node(T item, NodeColor color)
            {
                Item = item;
                Color = color;
                Count = 1;
            }

            public void Split4Node()
            {
                Color = NodeColor.Red;
                Left.Color = NodeColor.Black;
                Right.Color = NodeColor.Black;
            }
            public Node RotL()
            {
                var child = Right;
                Right = child.Left;
                child.Left = this;
                Update();
                child.Update();
                return child;
            }

            public Node RotR()
            {
                var child = Left;
                Left = child.Right;
                child.Right = this;
                Update();
                child.Update();
                return child;
            }

            public Node RotLR()
            {
                var c = Left;
                var gc = c.Right;

                Left = gc.Right;
                gc.Right = this;
                c.Right = gc.Left;
                gc.Left = c;
                Update();
                c.Update();
                gc.Update();
                return gc;
            }

            public Node RotRL()
            {
                var c = Right;
                var gc = c.Left;

                Right = gc.Left;
                gc.Left = this;
                c.Left = gc.Right;
                gc.Right = c;
                Update();
                c.Update();
                gc.Update();
                return gc;
            }

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

            public Node GetSibling(Node node)
            {
                return node == Left ? Right : Left;
            }

            public void Merge2Nodes()
            {
                Color = NodeColor.Black;
                Left.Color = NodeColor.Red;
                Right.Color = NodeColor.Red;
            }
        }
    }

}
