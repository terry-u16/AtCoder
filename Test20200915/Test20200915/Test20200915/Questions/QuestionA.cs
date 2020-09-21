using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Test20200915.Extensions;
using Test20200915.Questions;
using System.Diagnostics;
using System.Runtime.Intrinsics.X86;
using System.Numerics;
using AtCoder;
using ModInt = AtCoder.StaticModInt<AtCoder.Mod998244353>;

namespace Test20200915.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/practice2/tasks/practice2_f
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
            //var n = io.ReadInt();
            //var m = io.ReadInt();
            var a = new int[100000];// io.ReadIntArray(n);
            var b = new int[100000];// io.ReadIntArray(m);
            var c = AtCoder.Math.Convolution(a, b);
            io.WriteLine(c);

            return Enumerable.Empty<object>();
        }

        public class IOManager : IDisposable
        {
            private readonly StreamReader _reader;
            private readonly StreamWriter _writer;
            private bool _disposedValue;
            private Queue<ReadOnlyMemory<char>> _stringQueue;

            const char ValidFirstChar = '!';
            const char ValidLastChar = '~';

            public IOManager(Stream input, Stream output)
            {
                _reader = new StreamReader(input);
                _writer = new StreamWriter(output) { AutoFlush = false };
                _stringQueue = new Queue<ReadOnlyMemory<char>>();
            }

            public ReadOnlySpan<char> ReadCharSpan()
            {
                while (_stringQueue.Count == 0)
                {
                    var line = _reader.ReadLine().AsMemory().Trim();
                    var s = line.Span;

                    if (s.Length > 0)
                    {
                        var begin = 0;
                        for (int i = 0; i < s.Length; i++)
                        {
                            if (begin < 0 && IsValidChar(s[i]))
                            {
                                begin = i;
                            }
                            else if (!IsValidChar(s[i]))
                            {
                                _stringQueue.Enqueue(line[begin..i]);
                                begin = -1;
                            }
                        }
                        _stringQueue.Enqueue(line[begin..line.Length]);
                    }
                }

                return _stringQueue.Dequeue().Span;
            }

            public string ReadString() => ReadCharSpan().ToString();

            public int ReadInt() => (int)ReadLong();

            public long ReadLong()
            {
                long result = 0;
                bool isPositive = true;

                int i = 0;
                var s = ReadCharSpan();
                if (s[i] == '-')
                {
                    isPositive = false;
                    i++;
                }

                while (i < s.Length)
                {
                    result = result * 10 + (s[i++] - '0');
                }

                return isPositive ? result : -result;
            }

            public double ReadDouble() => double.Parse(ReadCharSpan());
            public decimal ReadDecimal() => decimal.Parse(ReadCharSpan());

            public int[] ReadIntArray(int n)
            {
                var a = new int[n];
                for (int i = 0; i < a.Length; i++)
                {
                    a[i] = ReadInt();
                }
                return a;
            }

            public long[] ReadLongArray(int n)
            {
                var a = new long[n];
                for (int i = 0; i < a.Length; i++)
                {
                    a[i] = ReadLong();
                }
                return a;
            }

            public double[] ReadDoubleArray(int n)
            {
                var a = new double[n];
                for (int i = 0; i < a.Length; i++)
                {
                    a[i] = ReadDouble();
                }
                return a;
            }

            public decimal[] ReadDecimalArray(int n)
            {
                var a = new decimal[n];
                for (int i = 0; i < a.Length; i++)
                {
                    a[i] = ReadDecimal();
                }
                return a;
            }

            public void WriteLine<T>(T value) => _writer.WriteLine(value.ToString());

            public void WriteLine<T>(IEnumerable<T> values, char separator)
            {
                var e = values.GetEnumerator();
                if (e.MoveNext())
                {
                    _writer.Write(e.Current.ToString());

                    while (e.MoveNext())
                    {
                        _writer.Write(separator);
                        _writer.Write(e.Current.ToString());
                    }
                }

                _writer.WriteLine();
            }

            public void Flush() => _writer.Flush();

            private static bool IsValidChar(char c) => ValidFirstChar <= c && c <= ValidLastChar;

            protected virtual void Dispose(bool disposing)
            {
                if (!_disposedValue)
                {
                    if (disposing)
                    {
                        _reader.Dispose();
                        _writer.Flush();
                        _writer.Dispose();
                    }

                    _disposedValue = true;
                }
            }

            public void Dispose()
            {
                Dispose(disposing: true);
                GC.SuppressFinalize(this);
            }
        }
    }
}
