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
            var rand = new Random();

            var n = 500000;
            writer.WriteLine(1);
            writer.WriteLine(n);
            writer.WriteLine(5);

            var random = new Random();

            for (int i = 2; i <= n; i++)
            {
                writer.WriteLine($"{i - 1} {i} {random.Next(5000)}");
            }
        }

        static void WriteOutput(TextWriter writer)
        {

        }
    }
}
