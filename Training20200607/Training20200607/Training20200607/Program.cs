﻿// ここにQuestionクラスをコピペ
using Training20200607.Questions;
using Training20200607.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Training20200607
{
    class Program
    {
        static void Main(string[] args)
        {
            IAtCoderQuestion question = new QuestionA();    // 問題に合わせて書き換え
            var answers = question.Solve(Console.In);
            foreach (var answer in answers)
            {
                Console.WriteLine(answer);
            }
        }
    }
}

#region Base Classes

namespace Training20200607.Questions
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

#region Extensions

namespace Training20200607.Extensions
{
    internal static class TextReaderExtensions
    {
        internal static int ReadInt(this TextReader reader) => int.Parse(ReadString(reader));
        internal static long ReadLong(this TextReader reader) => long.Parse(ReadString(reader));
        internal static double ReadDouble(this TextReader reader) => double.Parse(ReadString(reader));
        internal static string ReadString(this TextReader reader) => reader.ReadLine();

        internal static int[] ReadIntArray(this TextReader reader, char separator = ' ') => ReadStringArray(reader, separator).Select(int.Parse).ToArray();
        internal static long[] ReadLongArray(this TextReader reader, char separator = ' ') => ReadStringArray(reader, separator).Select(long.Parse).ToArray();
        internal static double[] ReadDoubleArray(this TextReader reader, char separator = ' ') => ReadStringArray(reader, separator).Select(double.Parse).ToArray();
        internal static string[] ReadStringArray(this TextReader reader, char separator = ' ') => reader.ReadLine().Split(separator);
    }
}

#endregion