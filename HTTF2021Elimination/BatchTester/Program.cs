using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using HTTF2021Elimination;
using HTTF2021Elimination.Questions;

namespace BatchTester
{
    class Program
    {
        static void Main(string[] args)
        {
            var costs = new int[51, 100];

            for (int initialTemp = 0; initialTemp <= 25; initialTemp++)
            {
                var temp = (double)initialTemp / 2;
                Parallel.For(0, 100, i =>
                {
                    var file = new FileStream($"../../../testCase/testCase_{i}.txt", FileMode.Open, FileAccess.Read);
                    using var io = new IOManager(file, Console.OpenStandardOutput());

                    var sw = new Stopwatch();
                    sw.Start();

                    var cards = new Coordinate[100];
                    for (int cardNo = 0; cardNo < cards.Length; cardNo++)
                    {
                        cards[cardNo] = new Coordinate(io.ReadInt(), io.ReadInt());
                    }

                    var solver = new Solver(cards, temp);
                    solver.Annealing(sw);

                    var result = solver.GetResult();
                    var cost = result.Count(c => c == 'U' || c == 'L' || c == 'D' || c == 'R');
                    costs[initialTemp, i] = cost;
                });

                Console.WriteLine($"Temp {initialTemp} completed.");
            }

            using var output = new StreamWriter("../../../result.csv");

            for (int initialTemp = 0; initialTemp <= 25; initialTemp++)
            {
                output.Write($"{(double)initialTemp / 2},");
                for (int i = 0; i < 100; i++)
                {
                    output.Write($"{costs[initialTemp, i]},");
                }
                output.WriteLine();
            }
        }
    }
}
