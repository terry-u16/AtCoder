﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using AtCoderBeginnerContest161.Questions;
using AtCoderBeginnerContest161.Extensions;

namespace AtCoderBeginnerContest161
{
    class Program
    {
        static void Main(string[] args)
        {
            IAtCoderQuestion question = new QuestionE_Review();    // 問題に合わせて書き換え
            var answers = question.Solve(Console.In);
            foreach (var answer in answers)
            {
                Console.WriteLine(answer);
            }
        }
    }
}

namespace AtCoderBeginnerContest161.Questions
{
    // ここにQuestionクラスをコピペ


    #region Base Classes

    public interface IAtCoderQuestion
    {
        IEnumerable<string> Solve(string input);
        IEnumerable<string> Solve(TextReader inputStream);
    }

    public abstract class AtCoderQuestionBase : IAtCoderQuestion
    {
        public IEnumerable<string> Solve(string input)
        {
            var stream = new MemoryStream(Encoding.Unicode.GetBytes(input));
            var reader = new StreamReader(stream, Encoding.Unicode);

            return Solve(reader);
        }

        public abstract IEnumerable<string> Solve(TextReader inputStream);
    }

    #endregion
}

#region Extensions

namespace AtCoderBeginnerContest161.Extensions
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