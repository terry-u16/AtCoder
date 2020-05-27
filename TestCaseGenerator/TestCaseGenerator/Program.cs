using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestCaseGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            const string inputFilePath = "input.txt";
            const string outputFilePath = "output.txt";

            using var inputWriter = new StreamWriter(inputFilePath, false, Encoding.UTF8);
            using var outputWriter = new StreamWriter(outputFilePath, false, Encoding.UTF8);
            WriteInput(inputWriter);
            WriteOutput(outputWriter);
        }

        static void WriteInput(TextWriter writer)
        {
            const int N = 100000;
            writer.WriteLine(N);
            int i;
            for (i = 2; i <= N; i++)
            {
                writer.WriteLine(i - 1);
            }
        }

        static void WriteOutput(TextWriter writer)
        {

        }
    }
}
