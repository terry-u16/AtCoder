using System;
using System.IO;
using HTTF2021Elimination;
using HTTF2021Elimination.Questions;

namespace FileTester
{
    class Program
    {
        static void Main(string[] args)
        {
            IAtCoderQuestion question = new QuestionA();

            using var input = new FileStream("../../../input/input.txt", FileMode.Open, FileAccess.Read);
            using var output = new FileStream($"../../../output/output{DateTime.Now:yyyyMMdd_HHmmss}.txt", FileMode.Create, FileAccess.Write);

            using var io = new IOManager(input, output);
            question.Solve(io);
        }
    }
}
