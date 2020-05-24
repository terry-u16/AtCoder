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

            WriteInput(new StreamWriter(inputFilePath, false, Encoding.UTF8));
            WriteOutput(new StreamWriter(outputFilePath, false, Encoding.UTF8));
        }

        static void WriteInput(TextWriter writer)
        {
            writer.WriteLine(500);
            writer.WriteLine(string.Join(" ", Enumerable.Range(1, 500 * 500)));
        }

        static void WriteOutput(TextWriter writer)
        {

        }
    }
}
