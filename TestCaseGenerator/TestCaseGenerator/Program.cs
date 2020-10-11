using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextCopy;

namespace TestCaseGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            const string inputFileName = "input.txt";
            const string outputFileName = "output.txt";

            using var inputWriter = new StreamWriter(inputFileName, false, Encoding.UTF8);
            using var outputWriter = new StreamWriter(outputFileName, false, Encoding.UTF8);
            WriteInput(inputWriter);
            WriteOutput(outputWriter);

            var inputPath = Path.Combine(Environment.CurrentDirectory, inputFileName);
            var clipboard = new Clipboard();
            clipboard.SetText($"new FileStream(@\"{inputPath}\", FileMode.Open, FileAccess.Read)");
        }

        static void WriteInput(TextWriter writer)
        {
            const int N = 500000;
            const int Q = 500000;
            const int Mod = 998244353;

            var rand = new Random();

            writer.WriteLine($"{N} {Q}");

            for (int i = 0; i < N; i++)
            {
                writer.WriteLine(rand.Next(Mod));
            }

            for (int i = 0; i < Q; i++)
            {
                var l = rand.Next(N + 1);
                var r = rand.Next(N + 1);
                if (l > r)
                {
                    (l, r) = (r, l);
                }

                if (l == N)
                {
                    l--;
                }


                if (rand.Next(2) == 0)
                {
                    var b = rand.Next(Mod - 1) + 1;
                    var c = rand.Next(Mod);
                    writer.WriteLine($"0 {l} {r} {b} {c}");
                }
                else
                {
                    writer.WriteLine($"1 {l} {r}");
                }
            }
        }

        static void WriteOutput(TextWriter writer)
        {

        }
    }
}
