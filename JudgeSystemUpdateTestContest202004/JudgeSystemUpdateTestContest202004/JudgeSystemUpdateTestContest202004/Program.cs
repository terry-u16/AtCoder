﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using JudgeSystemUpdateTestContest202004.Questions;
using JudgeSystemUpdateTestContest202004.Extensions;

namespace JudgeSystemUpdateTestContest202004
{
    class Program
    {
        static void Main(string[] args)
        {
            IAtCoderQuestion question = new QuestionD();    // 問題に合わせて書き換え
            var answers = question.Solve(Console.In);
            foreach (var answer in answers)
            {
                Console.WriteLine(answer);
            }
        }
    }
}

namespace JudgeSystemUpdateTestContest202004.Questions
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

namespace JudgeSystemUpdateTestContest202004.Algorithms
{
    public static class BasicAlgorithm
    {
        public static long Gcd(long a, long b)
        {
            if (a <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(a), $"{nameof(b)}は正の整数である必要があります。");
            }
            if (b <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(b), $"{nameof(b)}は正の整数である必要があります。");
            }
            if (a < b)
            {
                (a, b) = (b, a);
            }

            while (b != 0)
            {
                (a, b) = (b, a % b);
            }
            return a;
        }
    }
}
#region Extensions

    namespace JudgeSystemUpdateTestContest202004.Extensions
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

        // Supports primitive type only.
        internal static T1 ReadValue<T1>(this TextReader reader) => (T1)Convert.ChangeType(reader.ReadLine(), typeof(T1));

        internal static (T1, T2) ReadValue<T1, T2>(this TextReader reader, char separator = ' ')
        {
            var inputs = ReadStringArray(reader, separator);
            var v1 = (T1)Convert.ChangeType(inputs[0], typeof(T1));
            var v2 = (T2)Convert.ChangeType(inputs[1], typeof(T2));
            return (v1, v2);
        }

        internal static (T1, T2, T3) ReadValue<T1, T2, T3>(this TextReader reader, char separator = ' ')
        {
            var inputs = ReadStringArray(reader, separator);
            var v1 = (T1)Convert.ChangeType(inputs[0], typeof(T1));
            var v2 = (T2)Convert.ChangeType(inputs[1], typeof(T2));
            var v3 = (T3)Convert.ChangeType(inputs[2], typeof(T3));
            return (v1, v2, v3);
        }

        internal static (T1, T2, T3, T4) ReadValue<T1, T2, T3, T4>(this TextReader reader, char separator = ' ')
        {
            var inputs = ReadStringArray(reader, separator);
            var v1 = (T1)Convert.ChangeType(inputs[0], typeof(T1));
            var v2 = (T2)Convert.ChangeType(inputs[1], typeof(T2));
            var v3 = (T3)Convert.ChangeType(inputs[2], typeof(T3));
            var v4 = (T4)Convert.ChangeType(inputs[3], typeof(T4));
            return (v1, v2, v3, v4);
        }

        internal static (T1, T2, T3, T4, T5) ReadValue<T1, T2, T3, T4, T5>(this TextReader reader, char separator = ' ')
        {
            var inputs = ReadStringArray(reader, separator);
            var v1 = (T1)Convert.ChangeType(inputs[0], typeof(T1));
            var v2 = (T2)Convert.ChangeType(inputs[1], typeof(T2));
            var v3 = (T3)Convert.ChangeType(inputs[2], typeof(T3));
            var v4 = (T4)Convert.ChangeType(inputs[3], typeof(T4));
            var v5 = (T5)Convert.ChangeType(inputs[4], typeof(T5));
            return (v1, v2, v3, v4, v5);
        }

        internal static (T1, T2, T3, T4, T5, T6) ReadValue<T1, T2, T3, T4, T5, T6>(this TextReader reader, char separator = ' ')
        {
            var inputs = ReadStringArray(reader, separator);
            var v1 = (T1)Convert.ChangeType(inputs[0], typeof(T1));
            var v2 = (T2)Convert.ChangeType(inputs[1], typeof(T2));
            var v3 = (T3)Convert.ChangeType(inputs[2], typeof(T3));
            var v4 = (T4)Convert.ChangeType(inputs[3], typeof(T4));
            var v5 = (T5)Convert.ChangeType(inputs[4], typeof(T5));
            var v6 = (T6)Convert.ChangeType(inputs[5], typeof(T6));
            return (v1, v2, v3, v4, v5, v6);
        }

        internal static (T1, T2, T3, T4, T5, T6, T7) ReadValue<T1, T2, T3, T4, T5, T6, T7>(this TextReader reader, char separator = ' ')
        {
            var inputs = ReadStringArray(reader, separator);
            var v1 = (T1)Convert.ChangeType(inputs[0], typeof(T1));
            var v2 = (T2)Convert.ChangeType(inputs[1], typeof(T2));
            var v3 = (T3)Convert.ChangeType(inputs[2], typeof(T3));
            var v4 = (T4)Convert.ChangeType(inputs[3], typeof(T4));
            var v5 = (T5)Convert.ChangeType(inputs[4], typeof(T5));
            var v6 = (T6)Convert.ChangeType(inputs[5], typeof(T6));
            var v7 = (T7)Convert.ChangeType(inputs[6], typeof(T7));
            return (v1, v2, v3, v4, v5, v6, v7);
        }

        internal static (T1, T2, T3, T4, T5, T6, T7, T8) ReadValue<T1, T2, T3, T4, T5, T6, T7, T8>(this TextReader reader, char separator = ' ')
        {
            var inputs = ReadStringArray(reader, separator);
            var v1 = (T1)Convert.ChangeType(inputs[0], typeof(T1));
            var v2 = (T2)Convert.ChangeType(inputs[1], typeof(T2));
            var v3 = (T3)Convert.ChangeType(inputs[2], typeof(T3));
            var v4 = (T4)Convert.ChangeType(inputs[3], typeof(T4));
            var v5 = (T5)Convert.ChangeType(inputs[4], typeof(T5));
            var v6 = (T6)Convert.ChangeType(inputs[5], typeof(T6));
            var v7 = (T7)Convert.ChangeType(inputs[6], typeof(T7));
            var v8 = (T8)Convert.ChangeType(inputs[7], typeof(T8));
            return (v1, v2, v3, v4, v5, v6, v7, v8);
        }

    }
}

#endregion