using System;

namespace AGC047Debugger
{
    class Program
    {
        static void Main(string[] args)
        {
            var queries = int.Parse(Console.ReadLine());
            var v = new int[100];
            v[0] = 0;
            v[1] = 0;

            for (int q = 0; q < queries; q++)
            {
                var op = Console.ReadLine().Split(' ');
                var kind = op[0][0];
                var left = int.Parse(op[1]);
                var right = int.Parse(op[2]);
                var to = int.Parse(op[3]);

                if (kind == '+')
                {
                    v[to] = v[left] + v[right];
                }
                else
                {
                    v[to] = v[left] < v[right] ? 1 : 0;
                }

                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        Console.Write($"{v[i * 10 + j],+4}");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }
    }
}
