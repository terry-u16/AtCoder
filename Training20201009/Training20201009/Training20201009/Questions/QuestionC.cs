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
using System.Buffers;

namespace Training20201009.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var n = io.ReadInt();
            var queries = io.ReadInt();
            var uf = new UnionFind(n);

            for (int q = 0; q < queries; q++)
            {
                var type = io.ReadInt();
                var u = io.ReadInt();
                var v = io.ReadInt();

                if (type == 0)
                {
                    uf.Unite(u, v);
                }
                else
                {
                    io.WriteLine(uf.IsInSameGroup(u, v) ? 1 : 0);
                }
            }
        }

        // See https://kumikomiya.com/competitive-programming-with-c-sharp/
        public class UnionFind
        {
            private int[] _parentsOrSizes;
            public int Count => _parentsOrSizes.Length;
            public int Groups { get; private set; }

            public UnionFind(int count)
            {
                _parentsOrSizes = new int[count];
                _parentsOrSizes.AsSpan().Fill(-1);
                Groups = _parentsOrSizes.Length;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Unite(int a, int b)
            {
                var x = FindRoot(a);
                var y = FindRoot(b);

                if (x == y)
                {
                    return false;
                }
                else
                {
                    if (-_parentsOrSizes[x] < _parentsOrSizes[y])
                    {
                        (x, y) = (y, x);
                    }

                    _parentsOrSizes[x] += _parentsOrSizes[y];
                    _parentsOrSizes[y] = x;
                    Groups--;
                    return true;
                }
            }

            public bool IsInSameGroup(int a, int b) => FindRoot(a) == FindRoot(b);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int FindRoot(int index)
            {
                if (unchecked((uint)index >= (uint)_parentsOrSizes.Length))
                {
                    ThrowArgumentException();
                }

                return FindRecursive(index);

                int FindRecursive(int index)
                {
                    if (_parentsOrSizes[index] < 0)
                    {
                        return index;
                    }
                    else
                    {
                        return _parentsOrSizes[index] = FindRecursive(_parentsOrSizes[index]);
                    }
                }
            }

            public int GetGroupSizeOf(int index) => -_parentsOrSizes[FindRoot(index)];

            public int[][] GetAllGroups()
            {
                var resultIndices = ArrayPool<int>.Shared.Rent(_parentsOrSizes.Length);
                var index = 0;
                var results = new int[Groups][];

                for (int i = 0; i < _parentsOrSizes.Length; i++)
                {
                    if (_parentsOrSizes[i] < 0)
                    {
                        results[index] = new int[-_parentsOrSizes[i]];
                        resultIndices[i] = index++;
                    }
                }

                var counts = new int[results.Length];

                for (int i = 0; i < _parentsOrSizes.Length; i++)
                {
                    var group = resultIndices[FindRoot(i)];
                    results[group][counts[group]++] = i;
                }

                ArrayPool<int>.Shared.Return(resultIndices);

                return results;
            }

            private void ThrowArgumentException() => throw new ArgumentException();
        }
    }
}
