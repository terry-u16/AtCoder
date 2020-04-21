using System;
using Xunit;
using Yorukatsu021.Questions;
using System.Collections.Generic;
using System.Linq;

namespace Yorukatsu021.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"1234
150
100", @"84")]
        [InlineData(@"1000
108
108", @"28")]
        [InlineData(@"579
123
456", @"0")]
        [InlineData(@"7477
549
593", @"405")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
5 2 4", @"3")]
        [InlineData(@"4
631 577 243 199", @"0")]
        [InlineData(@"10
2184 2126 1721 1800 1024 2528 3360 1945 1280 1776", @"39")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4
3 4 2 1", @"1")]
        [InlineData(@"3
1 1000 1", @"0")]
        [InlineData(@"7
218 786 704 233 645 728 389", @"23")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4 4 1
2 1
1 3
3 2
3 4
4 1", @"0 1 0 1")]
        [InlineData(@"5 10 0
1 2
1 3
1 4
1 5
3 2
2 4
2 5
4 3
5 3
4 5", @"0 0 0 0 0")]
        [InlineData(@"10 9 3
10 1
6 7
8 2
2 5
8 4
7 3
10 9
6 4
5 8
2 6
7 5
3 1", @"1 3 5 4 3 3 3 3 1 0")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"7
abcdbbd
6
2 3 6
1 5 z
2 1 1
1 4 a
1 7 d
2 1 7", @"3
1
5")]
        [InlineData(@"7
abcdefg
2
1 3 d
2 1 4", @"3")]

        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }


        [Theory]
        [InlineData(@"7
abcdbbd
6
2 3 6
1 5 z
2 1 1
1 4 a
1 7 d
2 1 7", @"3
1
5")]
        [InlineData(@"7
abcdefg
2
1 3 d
2 1 4", @"3")]

        public void QuestionE_SortedSetTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE_SortedSet();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        //[Theory]
        //[InlineData(@"", @"")]
        public void QuestionFTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionF();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        IEnumerable<string> SplitByNewLine(string input) => input?.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None) ?? new string[0];
    }
}
