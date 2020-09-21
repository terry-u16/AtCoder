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
            var n = io.ReadInt();
            var m = io.ReadInt();
            var a = io.ReadIntArray(n);
            var b = io.ReadIntArray(m);
            var c = AtCoder.Math.Convolution(a, b);
            io.WriteLine(c);

            return Enumerable.Empty<object>();
        }

        public class IOManager : IDisposable
        {
            private readonly StreamReader _reader;
            private readonly StreamWriter _writer;
            private bool _disposedValue;

            const char ValidFirstChar = '!';
            const char ValidLastChar = '~';

            public IOManager(Stream input, Stream output)
            {
                _reader = new StreamReader(input);
                _writer = new StreamWriter(output) { AutoFlush = false };
            }

            public char ReadChar()
            {
                Skip();
                return (char)_reader.Read();
            }

            public string ReadString()
            {
                var builder = new StringBuilder();
                int c;
                Skip();

                while (IsValidChar(c = _reader.Read()))
                {
                    builder.Append((char)c);
                }

                return builder.ToString();
            }

            public string ReadLine()
            {
                Skip();
                return _reader.ReadLine();
            }

            public int ReadInt() => (int)ReadLong();

            public long ReadLong()
            {
                long result = 0;
                bool isPositive = true;
                Skip();
                int c = _reader.Read();

                if (c == '-')
                {
                    isPositive = false;
                    c = _reader.Read();
                }

                do
                {
                    result = result * 10 + (c - '0');
                } while (IsValidChar(c = _reader.Read()));

                return isPositive ? result : -result;
            }

            public double ReadDouble() => double.Parse(ReadString());
            public decimal ReadDecimal() => decimal.Parse(ReadString());

            // C#のバージョンが上がったらね……。
            // private Span<char> ReadCharSpan(Span<char> buffer)

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

            public void WriteLine<T>(T[] value, char delimiter = ' ')
            {
                for (int i = 0; i < value.Length - 1; i++)
                {
                    _writer.Write(value[i].ToString());
                    _writer.Write(delimiter);
                }
                _writer.WriteLine(value[value.Length - 1].ToString());
            }

            public void Flush() => _writer.Flush();

            private static bool IsValidChar(int c) => ValidFirstChar <= c && c <= ValidLastChar;

            private static void ThrowInvalidOperationException(string s) => throw new InvalidOperationException();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private void Skip()
            {
                while (!IsValidChar(_reader.Peek()))
                {
                    if (_reader.EndOfStream)
                    {
                        ThrowInvalidOperationException("End of file.");
                    }
                    _reader.Read();
                }
            }

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
