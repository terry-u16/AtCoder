using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ACPC2020Day2.Questions;

namespace ACPC2020Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            IAtCoderQuestion question = new QuestionG();
            var answers = question.Solve(Console.In);

            var writer = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
            Console.SetOut(writer);
            foreach (var answer in answers)
            {
                Console.WriteLine(answer);
            }
            Console.Out.Flush();
        }
    }
}

#region Base Class

namespace ACPC2020Day2.Questions
{

    public interface IAtCoderQuestion
    {
        IEnumerable<object> Solve(string input);
        IEnumerable<object> Solve(TextReader inputStream);
    }

    public abstract class AtCoderQuestionBase : IAtCoderQuestion
    {
        public IEnumerable<object> Solve(string input)
        {
            var stream = new MemoryStream(Encoding.Unicode.GetBytes(input));
            var reader = new StreamReader(stream, Encoding.Unicode);

            return Solve(reader);
        }

        public abstract IEnumerable<object> Solve(TextReader inputStream);
    }
}

#endregion

