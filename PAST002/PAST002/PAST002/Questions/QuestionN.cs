using PAST002.Algorithms;
using PAST002.Collections;
using PAST002.Questions;
using PAST002.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PAST002.Questions
{
    /// <summary>
    /// この方法だとTLE/MLEする
    /// </summary>
    public class QuestionN : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (sitesCount, queriesCount) = inputStream.ReadValue<int, int>();
            var sites = new Site[sitesCount];

            for (int i = 0; i < sites.Length; i++)
            {
                var (x, y, d, c) = inputStream.ReadValue<int, int, int, int>();
                sites[i] = new Site(x, y, d, c);
            }

            var (xCompressed, yCompressed) = Compress(sites);

            var costs = new long[xCompressed.Length, yCompressed.Length];
            foreach (var site in sites)
            {
                var x1 = ToCompressedCoordinate(xCompressed, site.X);
                var x2 = ToCompressedCoordinate(xCompressed, site.X + site.Length + 1);
                var y1 = ToCompressedCoordinate(yCompressed, site.Y);
                var y2 = ToCompressedCoordinate(yCompressed, site.Y + site.Length + 1);
                costs[x1, y1] += site.Cost;
                costs[x1, y2] -= site.Cost;
                costs[x2, y1] -= site.Cost;
                costs[x2, y2] += site.Cost;
            }

            Imos(costs);

            for (int q = 0; q < queriesCount; q++)
            {
                var (x, y) = inputStream.ReadValue<int, int>();
                var xComp = ToCompressedCoordinate(xCompressed, x);
                var yComp = ToCompressedCoordinate(yCompressed, y);
                yield return costs[xComp, yComp];
            }
        }

        void Imos(long[,] array)
        {
            var w = array.GetLength(0);
            var h = array.GetLength(1);

            for (int y = 0; y + 1 < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    array[x, y + 1] += array[x, y];
                }
            }

            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x + 1 < w; x++)
                {
                    array[x + 1, y] += array[x, y];
                }
            }
        }

        int ToCompressedCoordinate(int[] compressedCoordinates, int coordinate) => BoundaryBinarySearch<int>(compressedCoordinates, i => i <= coordinate, compressedCoordinates.Length, -1);

        private static int BoundaryBinarySearch<T>(ReadOnlySpan<T> span, Predicate<T> predicate, int ng, int ok)
        {
            // めぐる式二分探索
            // Span.BinarySearchだとできそうでできない（lower_boundがダメ）
            while (Math.Abs(ok - ng) > 1)
            {
                int mid = (ok + ng) / 2;

                if (predicate(span[mid]))
                {
                    ok = mid;
                }
                else
                {
                    ng = mid;
                }
            }
            return ok;
        }


        (int[] x, int[] y) Compress(Site[] sites)
        {
            var xPositions = new HashSet<int>();
            var yPositions = new HashSet<int>();

            xPositions.Add(int.MinValue);
            xPositions.Add(int.MaxValue);
            yPositions.Add(int.MinValue);
            yPositions.Add(int.MaxValue);

            foreach (var site in sites)
            {
                xPositions.Add(site.X);
                xPositions.Add(site.X + site.Length + 1);
                yPositions.Add(site.Y);
                yPositions.Add(site.Y + site.Length + 1);
            }

            var xComp = xPositions.ToArray();
            var yComp = yPositions.ToArray();
            Array.Sort(xComp);
            Array.Sort(yComp);
            return (xComp, yComp);
        }

        readonly struct Site
        {
            public int X { get; }
            public int Y { get; }
            public int Length { get; }
            public int Cost { get; }

            public Site(int x, int y, int length, int cost)
            {
                X = x;
                Y = y;
                Length = length;
                Cost = cost;
            }
        }
    }
}
