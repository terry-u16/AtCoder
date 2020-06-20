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
            clipboard.SetText($"new StreamReader(@\"{inputPath}\")");
        }

        static void WriteInput(TextWriter writer)
        {
            const int N = 100000;
            
            writer.WriteLine($"{N} {(long)N * N - 1}");
            writer.WriteLine(string.Join(" ", Enumerable.Repeat(100000, N)));
        }

        static void WriteOutput(TextWriter writer)
        {

        }
    }
}
